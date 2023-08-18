using System;
using System.Collections.Generic;

namespace GEngine
{
    public class EventMgr:Singleton<EventMgr>
    {
        public delegate void CoreEventDelegate<T, T1>(CoreEvent<T,T1> e);
        public delegate void CoreEventDelegate<T>(CoreEvent<T> e);
        private readonly Dictionary<int, Delegate> m_Delegates = new Dictionary<int, Delegate>();

        public void AddEventListener<T>(int type, CoreEventDelegate<T> listener)
        {
            if (m_Delegates.TryGetValue(type,out var d))
            {
                m_Delegates[type] = Delegate.Combine(d, listener);
            }
            else
            {
                m_Delegates[type] = listener;
            }
        }
        
        public void AddEventListener<T,T1>(int type, CoreEventDelegate<T,T1> listener)
        {
            if (m_Delegates.TryGetValue(type,out var d))
            {
                m_Delegates[type] = Delegate.Combine(d, listener);
            }
            else
            {
                m_Delegates[type] = listener;
            }
        }
        
        public void RemoveEventListener<T>(int type, CoreEventDelegate<T> listener)
        {
            if (m_Delegates.TryGetValue(type,out var d))
            {
                Delegate curDel = Delegate.Remove(d, listener);
                if (curDel == null)
                {
                    m_Delegates.Remove(type);
                }
                else
                {
                    m_Delegates[type] = curDel;
                }
            }
        }
        
        public void RemoveEventListener<T,T1>(int type, CoreEventDelegate<T,T1> listener)
        {
            if (m_Delegates.TryGetValue(type,out var d))
            {
                Delegate curDel = Delegate.Remove(d, listener);
                if (curDel == null)
                {
                    m_Delegates.Remove(type);
                }
                else
                {
                    m_Delegates[type] = curDel;
                }
            }
        }

        public void DispatchEvent<T>(CoreEvent<T> e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(e.ToString());
            }

            if (m_Delegates.TryGetValue(e.EventType,out var d))
            {
                CoreEventDelegate<T> callback = d as CoreEventDelegate<T>;
                if (callback != null)
                {
                    callback(e);
                }
            }
        }
        
        public void DispatchEvent<T,T1>(CoreEvent<T,T1> e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(e.ToString());
            }

            if (m_Delegates.TryGetValue(e.EventType,out var d))
            {
                CoreEventDelegate<T,T1> callback = d as CoreEventDelegate<T,T1>;
                if (callback != null)
                {
                    callback(e);
                }
            }
        }
    }
}
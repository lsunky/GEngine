using System.Collections.Generic;
using UnityEngine;

namespace GEngine
{
    public static class SingletonMgr
    {
        private static readonly List<CSingleton> _singletons = new List<CSingleton>();
        private static GameObject _monoSingletonGo;
        private static readonly List<CMonoSingleton> _monoSingletons = new List<CMonoSingleton>();

        public static GameObject MonoSingletonGo
        {
            get
            {
                if (_monoSingletonGo == null)
                {
                    _monoSingletonGo = new GameObject("MonoSingleton");
                    // DontDestroyOnLoad(_monoSingletonGo);
                }

                return _monoSingletonGo;
            }
        }

        public static bool Add(CSingleton instance)
        {
            if (instance == null || _singletons.Contains(instance))
            {
                return false;
            }

            instance.Init();
            _singletons.Add(instance);
            return true;
        }

        public static bool Add(CMonoSingleton instance)
        {
            if (instance == null || _monoSingletons.Contains(instance))
            {
                return false;
            }
            
            instance.Init();
            _monoSingletons.Add(instance );
            return true;
        }

        public static void Remove(CSingleton instance)
        {
            if (instance == null)
            {
                return;
            }

            _singletons.Remove(instance);
            instance.UnInit();
        }
        
        public static void Remove(CMonoSingleton instance)
        {
            if (instance == null)
            {
                return;
            }

            _monoSingletons.Remove(instance);
            instance.UnInit();
        }

        public static void Clear()
        {
            for (int i = 0,length = _singletons.Count; i < length; i++)
            {
                _singletons[i].UnInit();
            }
            _singletons.Clear();
            
            for (int i = 0,length = _monoSingletons.Count; i < length; i++)
            {
                _monoSingletons[i].UnInit();
            }
            _monoSingletons.Clear();

            if (_monoSingletonGo != null)
            {
                GameObject.Destroy(_monoSingletonGo);
            }
        }
    }

    
    public abstract class CSingleton
    {
        public abstract void Init();
        public abstract void UnInit();
    }
    
    public abstract class CMonoSingleton:MonoBehaviour
    {
        public abstract void Init();
        public abstract void UnInit();
    }
}
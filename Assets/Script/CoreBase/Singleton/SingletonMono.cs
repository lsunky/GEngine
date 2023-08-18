using System;
using UnityEngine;

namespace GEngine
{
    public class SingletonMono<T> : CMonoSingleton where T : CMonoSingleton
    {
        private static T  s_instance;

        public static T Instance
        {
            get
            {
                if (s_instance == null)
                {
                    CreateInstance();
                }

                return s_instance;
            }
        }
        
        public static void CreateInstance()
        {
            if (s_instance == null)
            {
                s_instance = SingletonMgr.MonoSingletonGo.AddComponent<T>();
                SingletonMgr.Add(s_instance);
            }
        }

        public static void DestroyInstance()
        {
            if (s_instance == null)
            {
                return;
            }
            
            SingletonMgr.Remove(s_instance);
        }

        public bool HasInstance => s_instance != null;
        public override void Init() => OnInit();

        public override void UnInit() => OnUnInit();

        protected virtual void OnInit() { }

        protected virtual void OnUnInit() { }
    }
}



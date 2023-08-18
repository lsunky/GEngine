namespace GEngine
{
    public class Singleton<T>:CSingleton where T : CSingleton, new()
    {
        private static T s_instance;
        
        public static T Instance
        {
            get
            {
                CreateInstance();
                return s_instance;
            }
        }
        public static void CreateInstance()
        {
            if (s_instance == null)
            {
                s_instance = new T();
                (s_instance as Singleton<T>).Init();
                SingletonMgr.Add(s_instance);
            }
        }

        protected virtual void OnInit() { }

        protected virtual void OnUnInit() { }


        public bool HasInstance => s_instance != null;

        public static void DestroyInstance()
        {
            if (s_instance != null)
            {
                SingletonMgr.Remove(s_instance);
                s_instance = null;
            }
        }

        public override void Init() => OnInit();

        public override void UnInit() => OnUnInit();
    }
}


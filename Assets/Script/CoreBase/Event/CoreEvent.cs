namespace GEngine
{
    public class CoreEvent<T>
    {
        public int EventType { get; private set; }
        public T Data { get; set; }
        public object Param { get; set; }
        public object Param2 { get; set; }

        public CoreEvent(int type, T data)
        {
            this.EventType = type;
            this.Data = data;
        }
    }
    
    public class CoreEvent<T,T1>
    {
        public int EventType { get; private set; }
        public T Data { get; set; }
        public T1 Data1 { get; set; }
        public object Param { get; set; }
        public object Param2 { get; set; }

        public CoreEvent(int type, T data, T1 data1)
        {
            this.EventType = type;
            this.Data = data;
            this.Data1 = data1;
        }
    }
}
namespace GEngine
{
    public interface IUpdate
    {
        void Update();
    }
    
    public interface IFixedUpdate
    {
        void FixedUpdate();
    }

    public interface ILateUpdate
    {
        void LateUpdate();
    }
}
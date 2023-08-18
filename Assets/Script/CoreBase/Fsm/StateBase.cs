using UnityEditor;

namespace GEngine
{
    public abstract class StateBase<T> where T:System.Enum
    {
        protected T m_StateType;
        protected FSM<T, StateBase<T>> m_Fsm;
        T GetStateType() => m_StateType;

        public void Init(T type, FSM<T, StateBase<T>> fsm)
        {
            this.m_StateType = type;
            this.m_Fsm = fsm;
        }

        protected void ChangToState(T nextState,object obj = null)
        {
            m_Fsm.Change(nextState,obj);
        }

        public void Enter(object obj = null)
        {
            OnEnter(obj);
        }

        protected abstract void OnEnter(object obj);

        public void Exit()
        {
            OnExit();
        }

        protected virtual void OnExit()
        {
        }

        public void Update()
        {
            OnUpdate();
        }

        protected virtual void OnUpdate()
        {
        }

        public void FixedUpdate()
        {
            OnFixedUpdate();
        }
        
        protected virtual void OnFixedUpdate()
        {
        }
        
        public void LateUpdate()
        {
            OnLateUpdate();
        }
        
        protected virtual void OnLateUpdate()
        {
            
        }
        public void Destroy()
        {
            OnDestroy();
        }
        
        protected virtual void OnDestroy()
        {
            
        }
    }
}
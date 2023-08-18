using System.Collections.Generic;

namespace GEngine
{
    public class FSM<T,U> where T : System.Enum where U : StateBase<T>
    {
        public StateBase<T> curState { get; private set; }
        public System.Enum curStateEnum { get; private set; }
        protected Dictionary<T, U> _dicStates;

        public FSM(Dictionary<T, U> dic)
        {
            this._dicStates = dic;
            foreach (var item in dic)
                item.Value.Init(item.Key,this as FSM<T,StateBase<T>>);
        }

        public void Destroy()
        {
            foreach (var state in _dicStates.Values)
            {
                state.Destroy();
            }
            _dicStates.Clear();
            _dicStates = null;
        }

        public void Change(T estate, object obj = null)
        {
            this.curState?.Exit();
            this.curState = _dicStates[estate];
            this.curStateEnum = estate;
            this.curState.Enter(obj);
        }

        public void Update()
        {
            this.curState?.Update();
        }

        public void FixedUpdate()
        {
            this.curState?.FixedUpdate();
        }

        public void LateUpdate()
        {
            this.curState?.LateUpdate();
        }
    }
}



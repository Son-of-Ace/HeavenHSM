using UnityEngine;

namespace HeavenHSM {
    public abstract class HSMBaseState<TContext, TFactory> 
        where TContext : HSMStateMachine<TContext, TFactory> 
        where TFactory : StateFactory
    {
        protected readonly string StateName;
        
        protected TContext Ctx { get; }
        protected TFactory Factory { get; }
        
        protected HSMBaseState(TContext currentContext, TFactory stateFactory) {
            Ctx = currentContext;
            Factory = stateFactory;
            StateName = GetType().Name.Replace("State", "");
        }
        
        protected bool IsRootState = false;
        private HSMBaseState<TContext, TFactory> _currentSubState;
        private HSMBaseState<TContext, TFactory> _currentSuperState;

        public abstract void EnterState();
        protected abstract void ExitState();
        protected abstract void UpdateState();
        protected abstract void UpdateStateFixed();
        public abstract void CheckSwitchStates();
        public abstract void InitializeSubState();
        public virtual void OnTriggerEnter(Collider other) {}
        public virtual void OnTriggerStay(Collider other) {}
        public virtual void OnTriggerExit(Collider other) {}

        public void UpdateStates() {
            UpdateState();
            _currentSubState?.UpdateStates(); 
        }

        public void UpdateStatesFixed() {
            UpdateStateFixed();
            _currentSubState?.UpdateStatesFixed();
        }

        public void SwitchState(HSMBaseState<TContext, TFactory> newState) {
            ExitState();
            newState?.EnterState();

            if (IsRootState) {
                Ctx.CurrentState = newState;
            } else {
                _currentSuperState?.SetSubState(newState);
            }
        }
        
        protected void SetSubState(HSMBaseState<TContext, TFactory> newSubState) {
            _currentSubState = newSubState;
            newSubState?.SetSuperState(this);
        }

        private void SetSuperState(HSMBaseState<TContext, TFactory> newSuperState) {
            _currentSuperState = newSuperState;
        }
    }
}

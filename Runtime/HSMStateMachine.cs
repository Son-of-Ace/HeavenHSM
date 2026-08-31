using System.Reflection;
using UnityEngine;

namespace HeavenHSM {
    public abstract class HSMStateMachine<TContext, TFactory> : MonoBehaviour 
        where TContext : HSMStateMachine<TContext, TFactory>
        where TFactory : StateFactory
    {
        public HSMBaseState<TContext, TFactory> CurrentState;

        protected virtual void Awake() {
            Debug.Log($"{MethodBase.GetCurrentMethod()?.Name} was called on {GetType().Name}");
        }

        protected virtual void Start() {
            Debug.Log($"{MethodBase.GetCurrentMethod()?.Name} was called on {GetType().Name}");
        }

        protected virtual void OnEnable() {
            Debug.Log($"{MethodBase.GetCurrentMethod()?.Name} was called on {GetType().Name}");
        }

        protected virtual void OnDisable() {
            Debug.Log($"{MethodBase.GetCurrentMethod()?.Name} was called on {GetType().Name}");
        }

        protected virtual void Update() {
            
        }

        protected virtual void FixedUpdate() {
            
        }
    }
}

using UnityEngine;

namespace HeavenHSM {
    /// <summary>
    /// Hierarchical State Machine Interface
    /// - This Interface implements some of the common Methods used in an HSM.
    /// </summary>
    public interface IHSM {
        public abstract void SetVelocity(Vector3 v);
        public abstract void SetVelocityX(float v);
        public abstract void SetVelocityY(float v);
        public abstract void SetVelocityZ(float v);
    }
}
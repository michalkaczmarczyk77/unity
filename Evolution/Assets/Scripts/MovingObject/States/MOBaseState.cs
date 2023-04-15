using UnityEngine;

public abstract class MOBaseState
{
    public abstract void EnterState(MOStateManager objectContext);
    public abstract void ExitState(MOStateManager objectContext);
    public abstract void UpdateState(MOStateManager objectContext);
    public abstract void OnCollisionEnter(MOStateManager objectContext, Collision2D collision);

}

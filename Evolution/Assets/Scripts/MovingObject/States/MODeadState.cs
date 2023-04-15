
using Unity.VisualScripting;
using UnityEngine;

public class MODeadState : MOBaseState
{

    public override void EnterState(MOStateManager objectContext)
    {
        EventManager.TriggerEvent("MO:DEAD");
        objectContext.destroy();
    }

    public override void ExitState(MOStateManager objectContext)
    {
    }

    public override void OnCollisionEnter(MOStateManager objectContext, Collision2D collision)
    {
    }

    public override void UpdateState(MOStateManager objectContext)
    {
    }
}

public class MOExpiredState : MODeadState
{

    public override void EnterState(MOStateManager objectContext)
    {
        EventManager.TriggerEvent("MO:EXPIRED");
    }

}

using UnityEngine;
using UnityEngine.Analytics;

public class MOLivingState : MOBaseState
{
    public override void EnterState(MOStateManager objectContext)
    {
        EventManager.TriggerEvent("MO:BORN");

        switch (objectContext.Gender)
        {
            case 0:
                objectContext.GetComponent<SpriteRenderer>().color = new Color(Color.yellow.r, Color.yellow.g, Color.yellow.b, Color.yellow.a);
                break;
            case 1:
                objectContext.GetComponent<SpriteRenderer>().color = new Color(Color.cyan.r, Color.cyan.g, Color.cyan.b, Color.cyan.a);
                break;
        }

        //objectContext.GetComponent<SpriteRenderer>().color = new Color(71, 91, 15);
    }

    public override void ExitState(MOStateManager objectContext)
    {
    }

    public override void OnCollisionEnter(MOStateManager objectContext, Collision2D collision)
    {
    }

    public override void UpdateState(MOStateManager objectContext)
    {
        objectContext.Age += Time.deltaTime;

        if(objectContext.Age >= objectContext.LiveTime)
        {
            objectContext.SwitchState(objectContext.StateDead);
        }
    }
}

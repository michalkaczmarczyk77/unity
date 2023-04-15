using System;
using Unity.VisualScripting;
using UnityEngine;
using static EventManager;

public class MOFallingState : MOBaseState
{
    private int liveTime = 0;
    private float age = 0f;

    public override void EnterState(MOStateManager objectContext)
    {
        EventManager.TriggerEvent("MO:SPAWNED");
        liveTime = (int)Mathf.Round(UnityEngine.Random.Range(20, 40));
    }

    public override void ExitState(MOStateManager objectContext)
    {
    }

    public override void UpdateState(MOStateManager objectContext)
    {
        age += Time.deltaTime;

        if (age >0 && age >= liveTime)
        {
            objectContext.SwitchState(objectContext.StateExpired);
        }
    }

    public override void OnCollisionEnter(MOStateManager objectContext, Collision2D collision)
    {
        if (!objectContext.isCollided)
        {
            GameObject other = collision.gameObject;

            if (other != null)
            {
                switch (other.tag)
                {
                    case var s when other.tag.Contains("Spawner"):
                        OnSpawnerCollisionEnter(objectContext, collision);
                    break;
                    case var s when other.tag.Contains("Trap"):
                        OnTrapCollisionEnter(objectContext, collision);
                        break;
                }
            }
        }
    }

    private void OnSpawnerCollisionEnter(MOStateManager objectContext, Collision2D collision)
    {
        objectContext.explosion.transform.position = objectContext.transform.position;
        objectContext.explosion.Emit(100);

        for (int i = 0; i < Mathf.Round(UnityEngine.Random.Range(1, 3)); i++)
        {
            objectContext.clone();
        }

        objectContext.isCollided = true;
        objectContext.SwitchState(objectContext.StateLiving);
    }

    private void OnTrapCollisionEnter(MOStateManager objectContext, Collision2D collision)
    {
        //Debug.Log("Trapped!!!");
    }

}

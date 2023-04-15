using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private float shootTime = 0f;
    public bool armored = true;

    public float shootTimeToLive = 5f;

    public void Update()
    {

        if ( armored==false && (Time.fixedUnscaledTime - shootTime >= 5f) )
        {
            Debug.Log(Time.fixedUnscaledTime - shootTime);
            armored = true;
            shootTime = 0;
        }
    }

    public virtual void Shoot()
    {
        if(armored)
        {
            shootTime = Time.fixedUnscaledTime;
            armored = false;
            Debug.Log("Weapon: Strzał Strzał...!!!###");
        }
    }

}

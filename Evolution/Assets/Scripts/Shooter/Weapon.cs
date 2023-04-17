using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    private float shootTime = 0f;
    public bool armored = true;

    public float coolDown = 15f;

    public void Update()
    {

        if ( armored==false && (Time.fixedUnscaledTime - shootTime >= coolDown) )
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
            PerformShoot();
        }
    }

    public abstract void PerformShoot();

}

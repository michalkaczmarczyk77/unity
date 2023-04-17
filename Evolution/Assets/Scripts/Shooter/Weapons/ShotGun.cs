using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Weapon
{
    private void Start()
    {
        coolDown = 5f;
    }

    public override void PerformShoot()
    {
        Debug.Log("ShotGun: Boom Boom tra tata!!!");
    }

}

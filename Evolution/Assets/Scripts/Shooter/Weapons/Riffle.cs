using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riffle : Weapon
{
    public override void Shoot()
    {
        if(armored) Debug.Log("Riffle: Boom Boom tra tata!!!");
        base.Shoot();
    }
}

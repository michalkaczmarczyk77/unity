using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riffle : Weapon
{

    private void Start()
    {
        coolDown = 15f;
    }

    public override void PerformShoot()
    {
        Debug.Log("Riffle: Bammmmmmm!!!");
    }
}

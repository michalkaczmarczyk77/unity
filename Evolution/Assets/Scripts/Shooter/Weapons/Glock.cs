using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glock : Weapon
{

    private void Start()
    {
        coolDown = 1f;
    }

    public override void PerformShoot()
    {
        Debug.Log("Glock: piff paff!!!");
    }

}

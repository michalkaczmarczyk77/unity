using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory : Inventory
{

    private void Start()
    {
        InitializeInventory("Weapon");
    }

    private void Update()
    {
        if (Input.anyKeyDown) checkButtons();
    }

    private void checkButtons()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && getItemCount() >= 1)
        {
            setActiveItem(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && getItemCount() >= 2)
        {
            setActiveItem(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && getItemCount() >= 3)
        {
            setActiveItem(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && getItemCount() >= 4)
        {
            setActiveItem(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5) && getItemCount() >= 5)
        {
            setActiveItem(4);
        }
    }

    public void Shoot()
    {
        //getActiveItem().SendMessage("Shoot");
        getActiveItem().GetComponent<Weapon>().Shoot();
    }   
}

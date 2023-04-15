using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
/*
 * Let's check how the GIT works
 */
public class Shooter : MonoBehaviour
{

    private EquipmentController equipment;
    //TODO: Add read only property
    //public EquipmentController Equipment {

    // Start is called before the first frame update
    void Start()
    {
        equipment = transform.GetComponentInChildren<EquipmentController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            equipment.getWeaponInventory().Shoot();
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Number of weapons: " + equipment.Weapons.NumberOfInventoryItems);
        Debug.Log("Number of tools  : " + equipment.Tools.NumberOfInventoryItems);
    }

}

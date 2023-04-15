using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentController : MonoBehaviour
{
    private WeaponInventory weaponInventory;
    private ToolInventory toolInventory;

    // Start is called before the first frame update
    void Start()
    {
        weaponInventory = transform.GetComponentInChildren<WeaponInventory>();
        toolInventory = transform.GetComponentInChildren<ToolInventory>();

        //Debug.Log("Weapon Inventory: "+weaponInventory.tag);
        //toolInventory = transform.Find("Tools");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void updateEquipment()
    {
        
    }

    public WeaponInventory getWeaponInventory()
    {
        return weaponInventory;
    }

    public ToolInventory getToolInventory()
    {
        return toolInventory;
    }
}

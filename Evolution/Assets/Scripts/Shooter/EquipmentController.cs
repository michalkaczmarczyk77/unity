using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentController : MonoBehaviour
{
    private WeaponInventory weaponInventory;
    private ToolInventory toolInventory;

    public WeaponInventory Weapons  {
        get { return weaponInventory; }
    }

    public ToolInventory Tools
    {
        get { return toolInventory; }
    }

    // Start is called before the first frame update
    void Start()
    {
        weaponInventory = transform.GetComponentInChildren<WeaponInventory>();
        toolInventory = transform.GetComponentInChildren<ToolInventory>();
    }

    private void updateEquipment()
    {
        weaponInventory.refresh(); ;
        toolInventory.refresh();
    }
}

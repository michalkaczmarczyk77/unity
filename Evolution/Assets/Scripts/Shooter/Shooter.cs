using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Shooter : MonoBehaviour
{

    private EquipmentController equipment;

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
}

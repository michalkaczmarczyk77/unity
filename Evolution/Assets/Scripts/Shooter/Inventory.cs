using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<GameObject> inventoryItems;
    private GameObject activeItem;
    private int activeItemId;
    private string itemClassName;

    public void InitializeInventory(string iClassName)
    {
        itemClassName = iClassName;
        refresh();
    }

    public List<GameObject> getItems()
    {
        return inventoryItems;
    }

    public int getItemCount()
    {
        return inventoryItems.Count;
    }

    public GameObject getActiveItem()
    {
        return activeItem;
    }
    public void setActiveItem(int newItemId)
    {
        inventoryItems[activeItemId].SetActive(false);
        inventoryItems[newItemId].SetActive(true);

        activeItemId = newItemId;
        activeItem = inventoryItems[activeItemId];    
    }

    public void refresh()
    {
        inventoryItems = new List<GameObject>();

        for (int i = 0; i < transform.childCount; i++)
        {
            var item = transform.GetChild(i);

            if(item.tag == itemClassName)
            {
                inventoryItems.Add(item.gameObject);
            }
        }

        activeItemId= 0;
        activeItem = inventoryItems[activeItemId];
    }

}

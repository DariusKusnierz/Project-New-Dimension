using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    ItemSlot[] itemsSlot;

    Inventory inventory;
    void Start()
    {
        inventory = Inventory.instance;
        inventory.OnInventoryChanged += Refresh;
        itemsSlot = GetComponentsInChildren<ItemSlot>();
    }

    void Refresh()
    {
        for (int i = 0; i < itemsSlot.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                itemsSlot[i].AddItem(inventory.items[i]);
            }
            else
            {
                itemsSlot[i].RemoveItem();
            }
        }
    }
}

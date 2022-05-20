using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    ItemSlot[] itemsSlots;

    Inventory inventory;
    void Start()
    {
        inventory = Inventory.instance;
        inventory.OnInventoryChanged += Refresh;
        itemsSlots = GetComponentsInChildren<ItemSlot>();
        gameObject.SetActive(false);
    }

    void Refresh()
    {
        for (int i = 0; i < itemsSlots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                itemsSlots[i].AddItem(inventory.items[i]);
            }
            else
            {
                itemsSlots[i].RemoveItem();
            }
        }
    }
}

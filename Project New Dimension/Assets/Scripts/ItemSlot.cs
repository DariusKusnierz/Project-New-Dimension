using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Image itemIcon;
    Item item;
    public void AddItem(Item newItem)
    {
        item = newItem;
        itemIcon.sprite = item.icon;
        itemIcon.enabled = true;
    }

    public void RemoveItem()
    {
        item = null;
        itemIcon.sprite = null;
        itemIcon.enabled = false;
    }
    
    public void StartRemoving()
    {
        Inventory.instance.RemoveItem(item);
    }
}

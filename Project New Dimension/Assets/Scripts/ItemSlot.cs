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
        Debug.Log("Ikona przedmiotu aktywna " + gameObject.name);
    }

    public void RemoveItem()
    {
        item = null;
        itemIcon.sprite = null;
        itemIcon.enabled = false;
        Debug.Log("Usuniêto ikonê przedmiotu " + gameObject.name);
    }
    
    public void StartRemoving()
    {
        Inventory.instance.RemoveItem(item);
    }
}

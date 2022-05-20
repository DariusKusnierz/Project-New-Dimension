using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Image itemIcon;

    public void AddItem(Item item)
    {
        itemIcon.sprite = item.icon;
        itemIcon.enabled = true;
    }

    public void RemoveItem()
    {
        itemIcon.sprite = null;
        itemIcon.enabled = false;
    }
}

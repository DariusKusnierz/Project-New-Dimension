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
        //Debug.Log("Od?wierzanie plecaka");
        for (int i = 0; i < itemsSlots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                itemsSlots[i].AddItem(inventory.items[i]);
                //Debug.Log("Umieszczono przedmiot w plecaku");
            }
            else
            {
                itemsSlots[i].RemoveItem();
                //Debug.LogWarning(i);
            }
            //Debug.Log(i);
        }
    }

    public void disableCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}

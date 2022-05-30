using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null) return;

        instance = this;
    }
    #endregion

    [SerializeField]
    int maxItems = 6;

    public event Action OnInventoryChanged;

    public List<Item> items = new List<Item>();

    public void AddItem(Item item)
    {
        if (items.Count >= maxItems) return;
        items.Add(item);
        //Debug.Log("Dodano przedmiot");
        if(OnInventoryChanged != null) OnInventoryChanged.Invoke();
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);

        if (OnInventoryChanged != null) OnInventoryChanged.Invoke();
    }
}

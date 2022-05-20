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

    public List<GameObject> items = new List<GameObject>();

    public void AddItem(GameObject item)
    {
        if (items.Count >= maxItems) return;
        items.Add(item);

        if(OnInventoryChanged != null) OnInventoryChanged.Invoke();
    }

    public void RemoveItem(GameObject item)
    {
        items.Remove(item);
    }
}

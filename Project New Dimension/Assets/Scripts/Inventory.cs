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

    public List<GameObject> items = new List<GameObject>();

    public void AddItem(GameObject item)
    {
        if (items.Count >= maxItems) return;
        items.Add(item);
    }

    public void RemoveItem(GameObject item)
    {
        items.Remove(item);
    }
}

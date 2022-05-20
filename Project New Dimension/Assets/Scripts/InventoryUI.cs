using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;
    void Start()
    {
        inventory = Inventory.instance;
        inventory.OnInventoryChanged += Refresh;
    }

    void Refresh()
    {

    }
}

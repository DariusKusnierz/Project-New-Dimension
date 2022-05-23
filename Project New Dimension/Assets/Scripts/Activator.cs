using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    Item item;
    void Start()
    {
        item = GetComponent<Item>();
    }

    // TODO - aktywacja po najechaniu myszk� i wci�ni�ciu przycisku np. F

    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "Player") return;

        Inventory.instance.AddItem(item);
        Destroy(gameObject);
    }
}

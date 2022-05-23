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

    // TODO - aktywacja po najechaniu myszk¹ i wciœniêciu przycisku np. F

    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "Player") return;

        Inventory.instance.AddItem(item);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Item : MonoBehaviour
{
    public string itemName = "Name";
    public Sprite icon;
    public bool isConsumable = false;
}

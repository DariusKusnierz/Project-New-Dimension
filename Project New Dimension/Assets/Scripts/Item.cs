using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Item : MonoBehaviour
{
    public string itemName = "Name";
    public Sprite icon;
    public bool isConsumable = false;
    public int hp = 1;
    public GameObject objectOfItem;

    public void UseItem(HP owner)
    {
        if (isConsumable)
        {
            owner.AddHP(hp);
        }
        else
        {
            WeaponSlot.instance.ChangeWeapon(this);
        }
    }
}

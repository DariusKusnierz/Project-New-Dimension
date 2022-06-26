using System.Collections;
using System.Collections.Generic;
using System.Windows;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSlot : MonoBehaviour
{
    #region Singleton
    public static WeaponSlot instance;
    private void Awake()
    {
        if (instance != null) return;
        instance = this;
    }
    #endregion

    public Image itemIcon;
    public Sprite basicIcon;
    Item item;

    [SerializeField]
    GameObject playerHand;

    GameObject weapon;

    public void ChangeWeapon(Item newItem)
    {
        if (itemIcon.sprite != basicIcon)
        {
            Inventory.instance.AddItem(newItem);
            return;
        }

        item = newItem;
        itemIcon.sprite = item.icon;

        playerHand.GetComponent<Collider>().enabled = false;

        weapon = Instantiate(item.objectOfItem);

        weapon.transform.parent = playerHand.transform;
        weapon.transform.localPosition = playerHand.transform.localPosition;
        weapon.transform.localRotation = playerHand.transform.localRotation;
    }

    public void RemoveWeapon()
    {
        if (itemIcon.sprite == basicIcon) return;

        Inventory.instance.AddItem(item);

        item = null;
        itemIcon.sprite = basicIcon;
        Destroy(weapon);
        playerHand.GetComponent<Collider>().enabled = true;
    }  
}
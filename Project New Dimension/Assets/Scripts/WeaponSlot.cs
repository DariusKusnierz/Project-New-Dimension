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
    public bool HasWeapon()
    {
        if (itemIcon.sprite != basicIcon)
            return true;

        return false;
    }

    public void ChangeWeapon(Item newItem)
    {
        if (HasWeapon())
        {
            Inventory.instance.AddItem(newItem);
            return;
        }

        item = newItem;
        itemIcon.sprite = item.icon;

        playerHand.GetComponent<Collider>().enabled = false;

        weapon = Instantiate(item.objectOfItem);

        weapon.transform.parent = playerHand.transform;
        //weapon.transform.localPosition = playerHand.transform.localPosition;
        //weapon.transform.localRotation = playerHand.transform.localRotation;

        weapon.transform.localPosition = new Vector3(-0.0438f, 0.0162f, -0.0158f);
        weapon.transform.localRotation = Quaternion.Euler(158.322f,-16.84f, -74.346f);
    }

    public void RemoveWeapon()
    {
        if (!HasWeapon()) return;

        Inventory.instance.AddItem(item);

        item = null;
        itemIcon.sprite = basicIcon;
        Destroy(weapon);
        playerHand.GetComponent<Collider>().enabled = true;
    }
    
}
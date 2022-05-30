using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLoot : MonoBehaviour
{
    public Loot[] loot; 
    public void dropLoot()
    {
        GameObject item;

        for (int i = 0; i < loot.Length ; i++)
        {
            if(Random.Range(0,1) < loot[i].dropChance)
            {
                item = Instantiate(loot[i].item);
                item.transform.position = transform.position;
                item.transform.rotation = transform.rotation;
                item.GetComponent<Rigidbody>().AddForce(Vector3.up * 50f);
                    //.AddForce(new Vector3(Random.Range(2.5f, 2f), 5 * 100f, Random.Range(2.5f, 2f)));
            }
        }
    }
}

[System.Serializable]
public class Loot
{
    public GameObject item;
    public float dropChance;
}

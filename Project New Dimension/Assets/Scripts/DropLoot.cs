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
            if(Random.Range(0,1) <= loot[i].dropChance)
            {
                item = Instantiate(loot[i].item);
                item.transform.position = transform.position;
                item.GetComponent<Rigidbody>()
                    .AddForce(new Vector3(Random.Range(0.5f, 1f), 1, Random.Range(0.5f, 1f)));
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

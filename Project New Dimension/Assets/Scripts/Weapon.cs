using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Weapon : MonoBehaviour
{
    public GameObject owner;
    public int hpToTake = 2;
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(gameObject.name + " widzi " + other.name);
        if(other.name != owner.name && other.GetComponent<HP>())
        {
            other.GetComponent<HP>().TakeHP(hpToTake);
            //Debug.Log("ATACK!!! on " + other.name);
        }
        
        
    }
}

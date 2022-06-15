using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Weapon : MonoBehaviour
{
    public GameObject owner;
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(gameObject.name + " widzi " + other.name);
        if(other.name != owner.name && other.GetComponent<HP>())
        {
            other.GetComponent<HP>().TakeHP();
            //Debug.Log("ATACK!!! on " + other.name);
        }
        
        
    }
}

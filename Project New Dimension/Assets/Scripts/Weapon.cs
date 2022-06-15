using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Weapon : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(gameObject.name + " widzi " + other.name);
        other.GetComponent<HP>().TakeHP();
        Debug.Log("ATACK!!! on " + other.name);
        
    }
}

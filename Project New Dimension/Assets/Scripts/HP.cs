using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    [SerializeField]
    int health = 1;
    
    public void AddHP(int points)
    {
        health += points;
    }

    public void TakeHP()
    {
        health -= 2;

        if(health <= 0)
        {
            KillObject();
        }
    }

    void KillObject()
    {
        //TODO
    }
}

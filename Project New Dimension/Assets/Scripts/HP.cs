using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    [SerializeField]
    int health = 1;

    public event Action OnHealthChange;
    
    public void AddHP(int points)
    {
        health += points;

        OnHealthChange.Invoke();
    }

    public void TakeHP()
    {
        health -= 2;

        if(gameObject.name == "Player")
        {
            OnHealthChange.Invoke();
        }

        if (health <= 0)
        {
            KillObject();
        }
    }

    void KillObject()
    {
        //TODO
    }

    public int GetValueHP()
    {
        return health;
    }
}

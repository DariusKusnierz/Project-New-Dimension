using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    [SerializeField]
    int health = 1;

    [SerializeField]
    GameObject deathParticle;

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
        Destroy(gameObject, 0.5f);
        GameObject particle = Instantiate(deathParticle);

        particle.transform.position = transform.position;
        particle.transform.rotation = transform.rotation;
    }

    public int GetValueHP()
    {
        return health;
    }
}

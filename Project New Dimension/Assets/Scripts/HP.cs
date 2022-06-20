using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    Finishing finish;

    [SerializeField]
    int health = 1;

    [SerializeField]
    GameObject deathParticle;

    public event Action OnHealthChange;

    private void Start()
    {
        finish = Finishing.instance;
    }

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
            if (gameObject.name == "Player")
            {
                rotatePlayerAfterDead();
                Finish(false);
            } 
            else if (gameObject.name == "zuggi")
            {
                rotateAfterDead();
                Finish(true);
            }
            else
            {
                KillObject();
            }
        }
    }

    public void TakeHP(int hp)
    {
        health -= hp;

        if (gameObject.name == "Player")
        {
            OnHealthChange.Invoke();
        }

        if (health <= 0)
        {
            if (gameObject.name == "Player")
            {
                rotatePlayerAfterDead();
                Finish(false);
            }
            else if (gameObject.name == "zuggi")
            {
                rotateAfterDead();
                Finish(true);
            }
            else
            {
                KillObject();
            }
        }
    }

    void KillObject()
    {
        Destroy(gameObject, 0.5f);
        gameObject.GetComponent<DropLoot>().dropLoot();

        GameObject particle = Instantiate(deathParticle);

        particle.transform.position = transform.position;
        particle.transform.rotation = transform.rotation;
    }

    void Finish(bool win)
    {
        Debug.Log("Koñczymy!!!");
        Cursor.lockState = CursorLockMode.Confined;
        finish.gameObject.SetActive(true);
        Time.timeScale = 0;
        
        if (win)
            finish.setWin();
        else
            finish.setFail();
    }

    public int GetValueHP()
    {
        return health;
    }

    void rotateAfterDead()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90f));
    }

    void rotatePlayerAfterDead()
    {
        GetComponentInChildren<Animator>().gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90f));
    }
}

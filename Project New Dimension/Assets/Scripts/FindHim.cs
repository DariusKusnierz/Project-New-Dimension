using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class FindHim : MonoBehaviour
{
    Quests quests;

    [SerializeField]
    string questName;

    private void Start()
    {
        quests = Quests.instance;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            quests.updateQuest(questName);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainQuest : MonoBehaviour
{
    Quests quests;

    void Start()
    {
        quests = Quests.instance;
    }
    
    void Update()
    {
        if(quests.getQuestsList().FindAll(x => x.isComplete==true).Count >= 3)
        {
            /*TO DO
             * 
             * Przemie�ci� obiekt zagradzaj�cy jaskini�
             * 
             * Przemie�ci� �piocha obok jakini
             * 
             * Ustawi� �cie�k� dialogow� dla kr�la
             * 
             */
        }
    }
}

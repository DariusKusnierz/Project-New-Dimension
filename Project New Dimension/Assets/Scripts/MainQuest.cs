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
             * Przemieœciæ obiekt zagradzaj¹cy jaskiniê
             * 
             * Przemieœciæ Œpiocha obok jakini
             * 
             * Ustawiæ œcie¿kê dialogow¹ dla króla
             * 
             */
        }
    }
}

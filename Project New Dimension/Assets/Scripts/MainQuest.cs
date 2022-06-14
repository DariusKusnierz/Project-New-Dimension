using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Dialogues))]
public class MainQuest : MonoBehaviour
{
    Quests quests;

    [SerializeField]
    GameObject spioch;

    [SerializeField]
    GameObject trashBeforeCave;

    [SerializeField]
    List<string> questDialogueLines;


    void Start()
    {
        quests = Quests.instance;
        
        foreach (var item in quests.getQuestsList())
        {
            item.onQuestsChange += () =>
            {
                if (quests.getQuestsList().FindAll(x => x.isComplete == true).Count >= 3)
                {
                    spioch.transform.position = new Vector3(-26.65f, 0.47f, 41.45f);
                    spioch.transform.rotation = Quaternion.Euler(0, 104.599f, 0);

                    trashBeforeCave.transform.position = new Vector3(-29.81f, 3.572128f, 23.63418f);
                    trashBeforeCave.transform.rotation = Quaternion.Euler(17.42f, 166.465f, -256.796f);

                    GetComponent<Dialogues>().basicDialogue = questDialogueLines;
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
            };
        }
    }
    
    void active()
    {
        if(quests.getQuestsList().FindAll(x => x.isComplete==true).Count >= 3)
        {
            spioch.transform.position = new Vector3(-26.65f, 0.47f, 41.45f);
            spioch.transform.rotation = new Quaternion(0, 104.599f, 0, 0);
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestsUI : MonoBehaviour
{
    Quests quests;
    List<Quest> listOfQuests;

    [SerializeField]
    GameObject questSlotPrefab;
    GameObject questSlot;
    void Start()
    {
        quests = Quests.instance;

        listOfQuests = quests.getQuestsList();

        foreach (var quest in listOfQuests)
        {
            questSlot = Instantiate(questSlotPrefab);
            questSlot.transform.SetParent(gameObject.transform);
            questSlot.GetComponentInChildren<Text>().text = quest.description;
            quest.onQuestsChange += () => {
                foreach (var item in gameObject.GetComponentsInChildren<Text>())
                {
                    if (item.text == quest.description)
                    {
                        item.GetComponentInParent<Toggle>().isOn = quest.isComplete;
                        break;
                    }
                }
            };
        }
    }
}

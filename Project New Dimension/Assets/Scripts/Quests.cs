using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quests : MonoBehaviour
{
    #region Singleton
    public static Quests instance;

    private void Awake()
    {
        if (instance != null) return;

        instance = this;
    }
    #endregion

    [SerializeField]
    List<Quest> allQuests;
    Inventory inventory;

    private void Start()
    {
        inventory = Inventory.instance;

        foreach (var item in allQuests.FindAll(x => x.killQuest==true))
        {
            StartCoroutine(checkingKillQuest(item));
        }

        foreach (var item in allQuests.FindAll(x => x.collectQuest==true))
        {
            StartCoroutine(checkingCollectingQuest(item));
        }
    }

    public void updateQuest(string name)
    {
        Quest questToChange = allQuests.Find(x => x.nameQuest == name);
        questToChange.gainProgress();
    }

    IEnumerator checkingKillQuest(Quest quest)
    {
        while (!quest.isComplete)
        {
            quest.checkActivitiOfObjects();
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator checkingCollectingQuest(Quest quest)
    {
        while (!quest.isComplete)
        {
            quest.checkIfCollectedItems(inventory.items);
            yield return new WaitForSeconds(1f);
        }
        for (int i = 0; i < quest.goal; i++)
        {
            Item itemToRemove = inventory.items.Find(x => x.itemName == quest.collect.itemName);
            inventory.RemoveItem(itemToRemove);
        }
    }

    public List<Quest> getQuestsList()
    {
        return allQuests;
    }
}

[System.Serializable]
public class Quest
{
    public string nameQuest;
    public string description;
    public int actualProgress;
    public int goal;
    public bool isComplete = false;
    public GameObject[] questObject;
    public bool killQuest = false;
    public bool collectQuest = false;
    public Item collect;

    public event Action onQuestsChange;
    
    public void gainProgress()
    {
        if (!isComplete)
        {
            actualProgress++;
            onQuestsChange.Invoke();

            if (actualProgress >= goal)
                isComplete = true;
        }
    }
    public void checkActivitiOfObjects()
    {
        int objects = goal;
        foreach (var item in questObject)
        {
            if (item == null)
                objects--;
        }
        
        if (objects <= goal - actualProgress)
        {
            actualProgress = goal - objects;
            onQuestsChange.Invoke();

            if (goal <= actualProgress)
                isComplete = true;
        }
    }

    public void checkIfCollectedItems(List<Item> items)
    {
        actualProgress = items.FindAll(x => x.itemName == collect.itemName).Count;
        onQuestsChange.Invoke();

        if (goal <= actualProgress)
            isComplete = true;
    }
}
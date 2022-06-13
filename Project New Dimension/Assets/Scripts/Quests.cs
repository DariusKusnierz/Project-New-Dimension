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

    public event Action onQuestsChange;

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class Quest
{
    public string nameQuest;
    public int actualProgress;
    public int goal;
    public bool isComplete = false;
    public GameObject questObject;

    public void gainProgress()
    {
        if (!isComplete)
        {
            actualProgress++;

            if (actualProgress >= goal)
                isComplete = true;
        }
    }
}
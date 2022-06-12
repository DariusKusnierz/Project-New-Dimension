using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    #region Singleton
    public static DialogueUI instance;

    private void Awake()
    {
        if (instance != null) return;

        instance = this;
    }

    #endregion

    Text textInDialogue;
    float timeToNext = 1.5f;

    private void Start()
    {
        textInDialogue = GetComponentInChildren<Text>();
        gameObject.SetActive(false);
    }

    public void activeDialogue(bool display)
    {
        gameObject.SetActive(display);
    }

   /* public void displayText(List<string> text)
    {
        activeDialogue(true);
        textInDialogue.text = text[0];
        Debug.Log("Pierwszy: " + text[0]);
        Debug.Log("Iloœæ: " + text.Count);

        StartCoroutine(startDisplayingText(text));
    }

    public void displayText(List<string> text, int index)
    {
        Debug.Log("Kolejny: " + text[index]);
        textInDialogue.text = text[index];

        StartCoroutine(startDisplayingText(text, index));

    }
    public IEnumerator startDisplayingText(List<string> text)
    {
        bool keepDisplaying = true;

        while (timeToNext > 0)
        {
            timeToNext -= 0.5f;
            yield return new WaitForSeconds(0.5f);
        }

        while (keepDisplaying)
        {
            if (Input.anyKeyDown)
            {
                if (text.Count > 1)
                    displayText(text, 1);
                else
                    activeDialogue(false);
                timeToNext = 1.5f;
                keepDisplaying = false;
            }
        }
        yield return null;
    }

    public IEnumerator startDisplayingText(List<string> text, int index)
    {
        bool keepDisplaying = true;

        while (timeToNext > 0)
        {
            timeToNext -= 0.5f;
            yield return new WaitForSeconds(0.5f);
        }

        while (keepDisplaying)
        {
            if (Input.anyKeyDown)
            {
                if (text.Count > index + 1)
                    displayText(text, index + 1);
                else
                    activeDialogue(false);
                timeToNext = 1.5f;
                keepDisplaying = false;
            }
        }
        yield return null;
    }*/
}

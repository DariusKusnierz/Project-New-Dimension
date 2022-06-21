using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogues : MonoBehaviour
{
    DialogueUI dialogueUI;
    TalkCloud talkCloud;

    public List<string> basicDialogue;
    bool isTalking = false;

    void Start()
    {
        dialogueUI = DialogueUI.instance;
        talkCloud = TalkCloud.instance;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Player" && !isTalking)
        {
            talkCloud.showCloud(gameObject.transform, collision.transform);

            if (Input.GetKeyDown(KeyCode.Q))
            {
                isTalking = true;
                dialogueUI.displayText(basicDialogue);
            }
        }

        if (!dialogueUI.isActiveAndEnabled)
            isTalking = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player" && isTalking)
        {
            dialogueUI.activeDialogue(false);
        }

        talkCloud.hideCloud();
    }
}

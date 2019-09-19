using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroDialogue5 : MonoBehaviour
{
    public GameObject A52;
    public GameObject dialogueObject;

    Text dialogueText;

    int dialogueNumber;
    string[] dialogues = { "Well well well, you have proven yourself to be quite the programming prodigy",
        "Your robot is now capable of interacting with the environment",
        "There is one last thing I require of you, I would like you to give your robot a conscience",
        "Give it the ability to think freely",
        "If you can do this for me, there will be a surprise waiting for you",
        "I think you will quite like it..."
    };
    // Start is called before the first frame update
    void Start()
    {
        dialogueText = dialogueObject.GetComponent<Text>();
        dialogueNumber = 0;
        dialogueText.text = dialogues[dialogueNumber];
    }

    public void InitiateDialogue()
    {
        dialogueNumber++;
        dialogueText.text = dialogues[dialogueNumber];
        dialogueObject.SetActive(true);
        A52.SetActive(true);
        //StartCoroutine(DialogueTimer());
    }

    //IEnumerator DialogueTimer()
    //{

    //}
}
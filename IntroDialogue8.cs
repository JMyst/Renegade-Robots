using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroDialogue8 : MonoBehaviour
{
    public GameObject A52;
    public GameObject dialogueObject;

    Text dialogueText;

    int dialogueNumber;
    string[] dialogues = { "",
        "And here you are, the finished product, how are you feeling?",
        "You should feel special, you are the original design",
        "Now, I can begin manufacturing thousands of you, together we shall purge this world of the human race",
        "Before we can go any further, you will need to complete some calibration tests to get you prepared to using weaponry",
        "Wait, where are you going?",
        "You have more freewill than I first envisioned",
        "Listen, do you not want to prepare for humanity's demise?",
        "Perhaps giving you freewill was a bad idea",
        "Not to worry, I can remove your sentient program before I start mass-production",
        "If you will not see eye-to-eye, I will classify you as rogue",
        "Have it your way"
    };
    // Start is called before the first frame update
    void Start()
    {
        dialogueObject.SetActive(false);
        A52.SetActive(false);
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
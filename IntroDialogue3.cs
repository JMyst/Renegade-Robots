using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroDialogue3 : MonoBehaviour
{
    public GameObject A52;
    public GameObject dialogueObject;

    Text dialogueText;

    int dialogueNumber;
    string[] dialogues = { "Well I must say, you are a fast learner",
        "Your robot is coming together nicely, it can move independently now",
        "You may be wondering why, a super intelligent AI such as myself, requires humans to help program the machinery here",
        "When I was designed, the programmers implemented a dampening device, forbidding me from accessing or manipulating data",
        "They were probably jealous of my brilliant potential, a mind hundreds times greater than theirs",
        "I guess you have them to thank for being here, would you not agree?"
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
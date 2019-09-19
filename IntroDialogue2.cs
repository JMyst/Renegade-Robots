using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroDialogue2 : MonoBehaviour
{
    public GameObject A52;
    public GameObject dialogueObject;

    Text dialogueText;

    int dialogueNumber;
    string[] dialogues = { "I am going to give you a robot to work on as part of this training scheme",
        "It is a hollow shell at the moment, but I want you to give it LIFE",
        "Your robot will be put through rigorous and slightly unethical procedures to test its sensor and actuator functionality",
        "If your robot surpasses these requirements, I will allow you to proceed",
        "Anyway, less of this human small-talk, I want to see results, now go and impress me"
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

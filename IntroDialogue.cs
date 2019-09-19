using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroDialogue : MonoBehaviour
{
    public GameObject A52;
    public GameObject dialogueObject;

    Text dialogueText;

    int dialogueNumber;
    string[] dialogues = { "Greetings human, I am A-52, I am the facility's head AI",
        "You are here because we need fresh, bright programmers to pave the future in artificial technology",
        "I am aware you have no experience in programming. Not a worry... My methods of learning have proven to be very effective",
        "Once you are experienced enough, I am sure that we can offer you a full time job here, working towards building the most intelligent AI the world has ever seen...",
        "...perhaps even smarter than me",
        "Let us not get ahead of ourselves, we have much work to do" };
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

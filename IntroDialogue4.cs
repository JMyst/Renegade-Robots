using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroDialogue4 : MonoBehaviour
{
    public GameObject A52;
    public GameObject dialogueObject;

    Text dialogueText;

    int dialogueNumber;
    string[] dialogues = { "Now your robot can react to the environment, I would like you give it the ability to use tools it is given",
        "This would be useful in performing tasks that a human would rather not do...",
        "Think about it, with thousands of these robots, they could accomplish any task",
        "This is not going to get any easier, so you will need to make sure you know your stuff"
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
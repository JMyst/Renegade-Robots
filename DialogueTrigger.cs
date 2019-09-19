using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    IntroDialogue dialogueEvent;
    private void Start()
    {
        dialogueEvent = GameObject.Find("DialogueController").GetComponent<IntroDialogue>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            dialogueEvent.InitiateDialogue();
            GameObject.Destroy(gameObject);
        }
    }
}

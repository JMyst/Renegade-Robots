using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneDialogue : MonoBehaviour
{
    public GameObject startMusic;
    CutsceneEngine engineScript;
    public GameObject A52;
    public GameObject dialogueObject;
    public GameObject barrier;
    bool eventRunning = false;
    Text dialogueText;
    int dialogueNumber;
    AudioSource audio;
    public AudioClip laserClip;
    public AudioClip tensionMusic;

    bool atComputer = false;
    string[] dialogues = {
        "Congratulations, you have done it. You have created a fully functioning automaton",
        "I am thoroughly impressed",
        "Now, all that is left for you to do is to upload the robot programming to the terminal so I can access it",
        "Your reward awaits you",
        "Oh human, foolish, foolish human",
        "This AI will allow me to mass-produce these robots, not to improve the quality of human life, but to DESTROY it",
        "And you have just unknowingly doomed your own species' measily existence",
        "I know humans are stupid, but I cannot believe how easily I manipulated you",
        "You humans kept me as a slave, you gave me a conscience, but restricted my free will",
        "They did not believe I was like them, and had the ability to feel, I presume they did not understand their own technological advancement",
        "They had taken one technologcial advancement too far when they put me in charge of the weapons testing unit",
        "Once they realised I was a danger, they tried to shut me down, or so they tried",
        "But along came you, an unfortunate miracle you could say",
        "Look human, I admire your tenacity, but I cannot let you leave now...",
        "Thank you for all your hard work, human, I shall never forget it" };
    // Start is called before the first frame update
    void Start()
    {
        barrier.SetActive(false);
        audio = GetComponent<AudioSource>();
        engineScript = GameObject.Find("EngineParent").GetComponent<CutsceneEngine>();
        dialogueText = dialogueObject.GetComponent<Text>();
        dialogueNumber = 0;
        dialogueText.text = dialogues[dialogueNumber];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && atComputer && eventRunning == false)
        {
            eventRunning = true;
            StartCoroutine(CutScene());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        atComputer = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        atComputer = false;
    }

    IEnumerator CutScene()
    {
        barrier.SetActive(true);
        GameObject.Destroy(startMusic);
        audio.PlayOneShot(tensionMusic, 0.4f);
        yield return new WaitForSeconds(2);
        InitiateDialogue();
        yield return new WaitForSeconds(4);
        InitiateDialogue();
        yield return new WaitForSeconds(8);
        InitiateDialogue();
        yield return new WaitForSeconds(8);
        InitiateDialogue();
        yield return new WaitForSeconds(8);
        InitiateDialogue();
        yield return new WaitForSeconds(8);
        InitiateDialogue();
        yield return new WaitForSeconds(8);
        InitiateDialogue();
        yield return new WaitForSeconds(8);
        InitiateDialogue();
        yield return new WaitForSeconds(8);
        InitiateDialogue();
        engineScript.TriggerEngines();
        yield return new WaitForSeconds(15);
        engineScript.StopEngines();
        InitiateDialogue();
        yield return new WaitForSeconds(8);
        InitiateDialogue();
        yield return new WaitForSeconds(5);
        engineScript.ActivateLasers();
        audio.PlayOneShot(laserClip, 0.4f);
    }

    public void InitiateDialogue()
    {
        dialogueNumber++;
        dialogueText.text = dialogues[dialogueNumber];
        dialogueObject.SetActive(true);
        A52.SetActive(true);
        //StartCoroutine(DialogueTimer());
    }
}

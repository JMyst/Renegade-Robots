using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Dialogue5 : MonoBehaviour
{
    public bool responseType;

    public GameObject question;
    public GameObject answerField1;
    public GameObject answerField2;
    public GameObject answerField3;
    public GameObject dialogue;
    public GameObject dialogueUI;

    Score scoreScript;

    Text questionText;
    Text answerField1Text;
    Text answerField2Text;
    Text answerField3Text;
    Text dialogueText;

    bool[] usedQuestions;

    int index;
    int randomQuestion;

    string correctAnswer;
    //string uniqueResponse[];
    string[] questions = {
        "int[] myArray = { 3, 8, 4, 9, 2, 3, 2, 1 };\n\nWhat is the value at myArray[5]?",
        "int[] myArray = { 2, 32, 10, 154, 1001, 40 };\n int i = myArray[32];\n What will this code do?",
        "for(int i = 0; i < 100; i++)\n{\n\n}\nHow many times will the for loop run?",
        "for(int i = 0; i <= 25; i++)\n{\n\n}\nHow many times will the for loop run?",
        "int i = 0;\ndo\n{\ni++;\n}\nwhile(10 > i)\nHow many times will this loop run?",
        "How would you initialise an array of 10 integers?",
        "Arrays are what type of data?",
        "int i = 0;\nwhile(10 < i)\n{\n\n}\nHow many times will this loop run?",
        "int[] myArray = { 9, 1, 4, 4, 7 };\nfor(int i = 0; i < 10; i++)\nConsole.Write(myArray[i]);\n\nWhat will the output of this code be?",
        "int[] myArray = { 5, 2, 1, 8, 5 };\nfor(int i = 0; i < 5; i++)\nConsole.Write(myArray[i]);\n\nWhat will the output of this code be?",
        "int[] myArray = { 2, 7, 4, 8, 6 };\nfor(int i = 0; 3 < 10; i++)\nConsole.Write(myArray[i]);\n\nWhat will the output of this code be?",
        "The value that is used to  specify an array index must be...",
        "How would you declare a 2D array of 10 rows and 8 columns?",
        "int[] myArray = new int[5];\nfor(int i = 0; i < 5; i++)\nmyArray[i] = i;\n\nWhat will myArray contain after this segment of code?",
        "The statement 'continue;' in a loop will do what?",
        "The statement 'break;' in a loop will do what?"
    };

    string[,] answers =
        {
        {"3", "2", "9"},
        {"cause an error", "assign i to 32", "assign i to 40" },
        {"100", "99", "101"},
        {"26", "25", "24"},
        {"1", "10", "0" },
        {"int[] myArray = new int[10];", "int[] myArray = 10;", "int[10] myArray = new int[]" },
        {"reference types", "value types", "they act as both" },
        {"0", "1", "10"},
        {"an error", "91447", "74419" },
        {"52185", "an error", "521" },
        {"274", "an error", "27486" },
        { "an integer", "a string", "a decimal" },
        { "int[,] num = new int[10, 8];", "Int[10][8] num = new int[];", "Int[10, 8] num = new int[,]" },
        {"01234", "12345", "05555" },
        {"Skip to the next loop iteration", "Exit the loop entirely", "Restarts the current loop iteration" },
        {"Exit the loop entirely", "Skip to the next loop iteration", "Restarts the current loop iteration" }
    };
    string[] correctResponses = {
        "I hope you did not guess that one...",
        "I see you have been paying attention",
        "Impeccable...",
        "You are certainly performing better... than the others",
        "You are doing well, continue like this",
        "Perhaps you are the one after all",
        "I am surprised you got that one correct",
        "Not bad, for a discontinued model...",
        "Oh this is coming together... nicely",
        "Maybe there is hope for you after all",
    };

    string[] incorrectResponses = {
        "How disappointing...",
        "Perhaps I was wrong about you after all",
        "Ouch, That looked like it hurt",
        "You are suppose to avoid those",
        "If you were paying attention you would have avoided that",
        "How embarrassing...",
        "I believe this robot is defective",
        "Coding is PAINstaking isn't it",
        "Are you sure you know what you are doing?",
        "If you are going to waste my time, perhaps it would make better use as a toaster?",
        "You are trying my patience",
        "If the robot could feel pain, I am sure it would object to these tests",
        "Now, that one was plain easy",
        "Observing this display is almost as painful being burned by that laser, almost...",
        "Could you be any worse?"
    };

    string[] uniqueResponses = { 
        "Arrays are indexed at 0, meaning [5] is the 6th element in the array",
        "= myArray[32]; means assign the 33rd element array to something, which is illegal because that is out of the array's range",
        "i < 100 means i will run from 0-99, running 100 times",
        "i <= 100 means i will run from 0-100, running 101 times",
        "the do while loop will always run at least once, even if the condition is false",
        "the new keyword is used to initialise arrays, with the size declared on the right hand side",
        "Arrays are a reference type, meaning they contain an address to the data, not the data itself",
        "i is not larger than 0, so the while statement will be skipped",
        "the for loop will run 10 times, which is larger than the array size, so the program will eventually produce an error",
        "The for loop will run 5 times, in line with the size of the array, allowing each element to be printed",
        "The for loop will run 3 times, smaller than the size of the array, therefore only printing the first 3 elements",
        "integers values can only be used to count items in an array",
        "A comma [,] is used in the brackets of an array to signify it is 2D",
        "the i in the for loop is incremented each iteration, assigning each index to i",
        "The continue; statement breaks the current loop iteration and moves to the next one",
        "The break; statement breaks the current loop iteration and exits the loop entirely"
    };
    // Start is called before the first frame update
    void Start()
    {
        usedQuestions = new bool[questions.Length];
        questionText = question.GetComponent<Text>();
        answerField1Text = answerField1.GetComponent<Text>();
        answerField2Text = answerField2.GetComponent<Text>();
        answerField3Text = answerField3.GetComponent<Text>();
        scoreScript = GameObject.Find("Score").GetComponent<Score>();
        index = Random.Range(0, correctResponses.Length);
        dialogueText = dialogue.GetComponent<Text>();
        dialogueText.text = incorrectResponses[index];
        question.SetActive(false);
        answerField1.SetActive(false);
        answerField2.SetActive(false);
        answerField3.SetActive(false);
        dialogue.SetActive(false);
        dialogueUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartQuestion()
    {
        question.SetActive(true);
        answerField1.SetActive(true);
        answerField2.SetActive(true);
        answerField3.SetActive(true);

        do
        {
            randomQuestion = Random.Range(0, questions.Length);
        }
        while (usedQuestions[randomQuestion] == true);

        questionText.text = questions[randomQuestion];
        correctAnswer = answers[randomQuestion, 0];
        usedQuestions[randomQuestion] = true;

        for (int i = 0; i < 3; i++)
        {
            string tmp = answers[randomQuestion, i];
            int r = Random.Range(i, 3);
            answers[randomQuestion, i] = answers[randomQuestion, r];
            answers[randomQuestion, r] = tmp;
        }
        answerField1Text.text = answers[randomQuestion, 0];
        answerField2Text.text = answers[randomQuestion, 1];
        answerField3Text.text = answers[randomQuestion, 2];
    }

    public void StopQuestion()
    {
        dialogue.SetActive(false);
        dialogueUI.SetActive(false);
        question.SetActive(false);
        answerField1.SetActive(false);
        answerField2.SetActive(false);
        answerField3.SetActive(false);
        responseType = true;
    }

    public void StartDialogue()
    {
        dialogueUI.SetActive(true);
        dialogue.SetActive(true);
        int randomResponse = Random.Range(0, correctResponses.Length);
        if (responseType == true)
        {
            dialogueText.text = correctResponses[randomResponse];
            scoreScript.SetScore(500);
        }
        else
        {
            int rand = Random.Range(0, 2);
            if (rand == 0)
            {
                dialogueText.text = incorrectResponses[randomResponse];
            }
            else
            {
                dialogueText.text = uniqueResponses[randomQuestion];
            }
        }
        StartCoroutine(DialogueComment());
    }

    public int CheckCorrectionField()
    {
        if (correctAnswer == answerField1Text.text)
        {
            return 1;
        }
        else
        {
            if (correctAnswer == answerField2Text.text)
            {
                return 2;
            }
            else
            {
                if (correctAnswer == answerField3Text.text)
                    return 3;
            }
        }
        return 0;
    }

    IEnumerator DialogueComment()
    {
        yield return new WaitForSeconds(3);
        dialogueUI.SetActive(false);
        dialogue.SetActive(false);
    }
}
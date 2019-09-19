using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Dialogue2 : MonoBehaviour
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
        "int myValue = 5; What is the name of this variable?",
        "int anInteger = 29; How would you reassign this variable to 18?",
        "int myNumber = 10 % 2;    What is myNumber assigned the value of?",
        "Which is the modulus operator?",
        "Which is the multiplication operator?",
        "myValue++;  is shorthand for what?",
        "The increment and decrement (++ and --) operators are of what type of operator?",
        "the + and - operators are of what type of operator?",
        "Which is the division operator?",
        "Which is the assignment operator?",
        "myValue += 10;    is shorthand for what?",
        "int myValue = 10;      myValue += 5;   What is the value of myValue?",
        "int i = 5 * (2 + 4);   What is the value of i?",
        "The == operator does what?",
        "bool myBoolean = 5 == 10;  What is the value of myBoolean?",
        "bool myBoolean = 5 != 10;  What is the value of MyBoolean?",
        "int a = 5;    int myInteger = a++;   What is the value of myInteger?",
        "int a = 5;    int myInteger = ++a; What is the value of myInteger?",
        "bool myBoolean = 3 > 2;   What is the value of myBoolean?",
        "int i = 10 > 5 ? 14 : 0;   What is the value of i?",
        "Which is the conditional operator?"
    };

    string[,] answers = {
        {"myValue", "int myValue", "5" },
        {"anInteger = 18" , "int anInteger = 18", "int = 18" },
        {"0", "5", "-5" },
        {"%", "/", "~"},
        {"*", "^", "x" },
        {"myValue = myValue + 1;", "myValue = myValue * -1;", "myValue = myValue * myValue;"},
        {"unary", "binary", "ternary"},
        {"binary", "unary", "ternary" },//        "the + and - operators are of what type of operator?",
        {"/", "%", "&" }, //        "Which is the division operator?",
        {"=", "==", "?" }, //        "Which is the assignment operator?",
        {"myValue = myValue + 10", "myValue = 10", "myValue = myValue * 10" },//        "myValue += 10;    is shorthand for what?",
        {"15", "10", "5" },//        "int myValue = 10;      myValue += 5;   What is the value of myValue?",
        {"30", "28", "14" }, //        "int i = 5 * (2 + 4);   What is the value of i?",
        {"checks for equality", "assigns variables of different datatypes", "ignores decimals when assigning" }, //        "The == operator does what?",
        {"false", "true", "10"}, //"bool myBoolean = 5 == 10;  What is the value of myBoolean?"
        {"true", "false", "null" },
        {"5", "6", "10"},
        {"6", "5", "10" },
        {"true", "false", "error" },
        {"14", "5", "0" },
        {"?:", "&&", "||" }

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
        "The variable name is 'myValue', but it could be named anything the programmer chooses",
        "You only name a variable with its datatype when you first declare the variable",
        "myNumber would become 0, as 10 divided by 2 leaves no remainders",
        "% is the modulus operator and returns any remainders after a division",
        "* is the multiplication operator",
        "++ is used to increment a value by one, useful for counting",
        "++ and -- are unary operators, meaning they work on one variable alone",
        "+ and - are binary operators, meaning they operate on 2 variables",
        "/ is the division operator",
        "= is the assignment operator, it assigns the variable on the left of it to the variable on the right",
        "The += operator assigns the number on the left to the the number on the right plus itself",
        "myValue += 5; is shorthand for myValue = myValue + 5",
        "Operations within parenthesis are the first to be calculated",
        "The == operator checks for equality between two values",
        "The == operator checks if 5 and 10 are equal, since they are not myBoolean becomes false",
        "The != operator checks if 5 and 10 are not equal, since they are not equal myBoolean is assigned true",
        "a++ is the post-increment operator, myInteger is assigned before a is incremented",
        "++a is the pre-increment operator, a is incremented before myInteger is assigned",
        "Since 10 > 5 is true, i is asigned to 14 as opposed to 0",
        "The conditional operator is the only ternary operator in C#",
        "?: is the conditional operator, it is also the only ternary operator in C#"
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

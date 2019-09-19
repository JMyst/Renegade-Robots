using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Dialogue : MonoBehaviour
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
        "Integer range of the 'int' datatype?",
        "Integer range of the 'byte' datatype?",
        "Integer range of the 'short' datatype?",
        "Correct way of defining a 'float' variable?",
        "Correct way of defining a 'decimal' variable?",
        "The most accurate floating-point (decimal) datatype?",
        "Integer range of the 'long' datatype?",
        "What is the default value of a bool (before being assigned a value)?",
        "The 'string' datatype holds what type of variable?",
        "The 'char' datatype stores what variable?",
        "What punctuation do you assign string variables in?",
        "What punctuation do you assign char variables in?",
        //"int myValue = 5; What is the name of this variable?",
        //"int anInteger = 29; How would you reassign this variable to 18?",
        "A decimal value with no suffix is treated as what datatype?",
        "float aDecimal = 8.9534;   What is the error?",
        "What is an unsigned datatype?",
        "uint, ushort and ulong   What does the u stand for?",
        "What is the size of the 'int' datatype?",
        "What is the size of the 'byte' datatype?",
        "What is the size of the 'float' datatype?",
        "What is the size of the 'bool' datatype",
        "Integer range of the 'byte' datatype?",
        "Integer range of the 'sbyte' datatype?",
        "What is the size of the 'short' datatype?",
        "What is the size of the 'long' datatype?",
        "What is the size of the 'double' datatype?",
        "What is the size of the 'decimal' datatype?"
    };

    string[,] answers =
        {{ "-2147483648 to 2147483647", "-32768 to 32767", "0 to 4294967295"},
        { "0 to 255", "0 to 65535", "-128 to 127" },
        {"-32768 to 32767", "0 to 65535", "0 to 4294967295"},
        {"3.04f", "3.04", "f3.04"},
        {"10.156m", "10.156", "10.158d"},
        {"decimal", "float", "double"},
        {"-9223372036854775808 to 9223372036854775807", "0 to 65535", "0 to 4294967295" },
        {"false", "true", "null (no value)" },
        {"text", "integers", "negative numbers"},
        {"singular characters", "text", "integers" },
        {"quotation marks \" \"", "apostrophes ' '", "brackets ()" },
        {"apostrophes ' '", "quotation marks \" \"", "brackets ()" },
        //{"myValue", "int myValue", "5" },
        //{"anInteger = 18" , "int anInteger = 18", "int = 18" },
        {"double", "decimal", "float"},
        {"no letter f after the value", "value is too accurate", "= operator in the wrong place"},
        {"a type that allows only positive values", "a type that cannot be made smaller", "a type that allows only negative values" },
        { "unsigned", "unloaded", "unopened"},
        {"4 bytes", "8 bytes", "16 bytes" },
        {"1 byte", "4 bytes", "8 bytes" },
        {"4 bytes", "32 bytes", "16 bytes" },
        {"1 byte", "4 bytes", "8 bytes" },
        {"0 to 255", "-128 to 127", "0 to 155" },
        {"-128 to 127", "0 to 255", "0 to 510" },
        {"2 bytes", "4 bytes", "1 byte" },
        {"8 bytes", "16 bytes", "32 bytes" },
        {"8 bytes", "16 bytes", "32 bytes" },
        {"16 bytes", "32 bytes", "64 bytes" }
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

    string[] uniqueResponses = { "Integers have a range of -2147483648 to 2147483647", // "Integer range of the 'int' datatype?",
            "The byte datatype can only store integers from 0 to 255", //"Integer range of the 'byte' datatype?",
        "The short datatype can handle integers from -32768 to 32767", // "Integer range of the 'short' datatype?",
        "The letter f is used after a decimal to signify a float variable", // "Correct way of defining a 'float' variable?",
        "The letter m is used after a decimal to signify a deciaml variable", // "Correct way of defining a 'decimal' variable?"
        "The decimal datatype is the most accurate, followed by double then float", // "The most accurate floating-point (decimal) datatype?"
        "-9223372036854775808 to 9223372036854775807, that is big...", // "Integer range of a 'long' datatype?"
        "Boolean values are treated as false if left unassigned", // "What is the default value of a bool (before being assigned a value)?",
        "Any number or digit represented as text can be stored in a string", //"The 'string' datatype holds what type of variable?"
        "The char datatype is used to store individual characters", //"The 'char' datatype stores what variable?"
        "When assigning strings, the variable must be written within quotations", //"What punctuation do you assign string variables in?"
        "When assigning chars, the variable must be written within apostrophes", // "What punctuation do you assign char variables in?"
        "A decimal value with no suffix is treated as a double", //"A decimal value with no suffix is treated as what datatype?"
        "The compiler will only recognise floats if there is an f after the value",
        "Unsigned datatypes are ones that can only store positive numbers",
        "A uint is an unsigned variant of an int, it has the same range as an int but can store larger positive numbers",
        "The int datatype requires 4 bytes of memory",
        "The byte datatype requires, 1 byte of memory... shocking is it not?",
        "The float datatype requires 4 bytes of memory",
        "The bool datatype requires 1 byte of memory, since it can only represent a possible 2 values",
        "Bytes have a range of 0-255",
        "Bytes are unsigned by default (0 - 255), sbytes allow for ranges of -128 to 127",
        "The short datatype requires 2 bytes of memory",
        "The long datatype requires 8 bytes of memory",
        "The double datatype requires 8 bytes of memory",
        "The decimal datatype requires 16 bytes of memory"
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

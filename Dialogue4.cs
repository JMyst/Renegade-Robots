using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Dialogue4 : MonoBehaviour
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
        "A function that returns no value should have what in its signature?",
        "MyFunction(int i)\n{\ni += 45;\nreturn i;\n}\n\nWhat is missing from this function's signature?",
        "int SquareNumber(int i)\n{\nreturn i * i;\n}\n\nHow would you call this function?",
        "bool MyFunction(int i, float j)\n{\nreturn i < 100 && j < 50;\n}\n\nHow would you call this function?",
        "int myInteger = MyFunction(10);\nvoid MyFunction(int i)\n{\nreturn i * i;\n}\n\nWhat will this code do?",
        "string myVariable = MyFunction();\nvoid MyFunction()\n{\nstring s = \"Hello world!\";\n}\n\nWhat will this code do?",
        "int myVariable = MyFunction(5);\nvoid MyFunction(int num)\n{\nnum = num += 10;\n}\n\nWhat will this code do?",
        "int myVariable = MyFunction(20);\nint MyFunction(int num)\n{\nreturn num % 2;\n}\n\nWhat will this code do?",
        "int i = 10;\nMyFunction(ref i);\nvoid MyFunction(ref int num)\n{\nnum = 30;\n}\n\nWhat is the value of i after this function?",
        "int i = 25;\nMyFunction(i);\nvoid MyFunction(int num)\n{\nnum = num * 10;\n}\n\nWhat is the value of i after this function?",
        "Paramters are...",
        "Arguments are...",
        "int i;\ni = Multiply(2, 8);\nvoid Multiply(int num1, int num2)\n{\nreturn num1 * num2;\n}\nWhat are the parameters in this code?",
        "int i = 9;\nbool a = IsEven(i);\nbool IsEven(int num)\n{\nreturn (num % 2) == 0;\n}\nWhat are the arguments in this code?",
        "int i = 9;\nbool a = IsEven(i);\nbool IsEven(int num)\n{\nreturn (num % 2) == 0;\n}\nWhat will be assigned to a?",
        "The entry point to a C# program is where?",
        "How would you declare the Main in a C# program?",
        "Which are of the following is a reference type?",
        "What is not required in a function if passing a value by reference?",
        "When passing a variable to a function with the keyword 'out', should the variable have a value?",
        "When passing a variable to a function with the keyword 'ref', should the variable have a value?"

    };

    string[,] answers =
        {
        {"void", "null", "0" },
        {"int", "void", "string" },
        {"SquareNumber(10);", "SquareNumber();", "int SquareNumber(10)" },
        {"MyFunction(25, 80.0f);", "MyFunction(true, int, float);", "MyFunction(25, 80);"},
        {"produce an error", "assign myInteger to 100", "assign myInteger to 10" },
        {"produce an error", "assign myVariable to \"Hello world!\"", "assign myVariable to null" },
        {"produce an error", "assign myVariable to 15", "assign myVariable to 10" },
        {"assign myVariable to 0", "assign myVariable 2", "produce an error" },
        {"30", "10", "function will cause an error" },
        {"25", "250", "function will cause an error" },
        {"the variables a function accepts", "concrete values passed into a function", "the return type of a function" },
        {"concrete values passed into a fucntion", "the variables a function accepts", "the return type of a function"},
        {"int num1, int num2", "2, 8", "int i" },
        {"i", "int num", "a" },
        {"false", "true", "9" },
        {"Main", "Start", "Entry"},
        {"both are acceptable", "static void Main(string[] args)\n{\n\n}", "static void Main()\n{\n\n}" },
        {"string", "int", "decimal" },
        {"a return type", "arguments", "parameters" },
        {"no", "yes", "it can be either" },
        {"yes", "no", "it can be either" }
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
        "A function that returns no value must have the keyword 'void' in its declaration",
        "The function returns a value of type int, therefore 'int' must be declared in the function header",
        "SquareNumber's parameters require an int, therefore a int value must be passed in the brackets when calling the function",
        "The function's parameters require an int and float value, in that specific order",
        "The function returns ant integer, but it has void in its declaration, resulting in an error",
        "If a function is being assigned to a variable, that function must return a value to assign to the variable",
        "The function is declared as void, nor does it return an int value, therefore trying to assign it to a variable will cause an error",
        "The function accepts and returns and integer, therefore it will assign myvariable to the function output, which is 0",
        "i will be assigned the value of 30 because i was passed by reference using the 'ref' keyword",
        "i will remain 25 because the function creates a copy of i and does not return the copy",
        "Parameters are found in a function's signature, it shows what variables it requires when called",
        "Arguments are found when calling a function, it shows what values the programmer wants to send into a function",
        "int num1, int num2 are the functions parameters. These are the variables types the function requires when called",
        "i is passed into the IsEven() function when the function is called, meaning i is the argument",
        "The IsEven() function returns a bool and checks if the send value is even, since 9 is not, the returned boolean is false",
        "The 'Main' keyword is the entry point to a program",
        "A Main() function must always have the static keyword, but having parameters is optional",
        "The string datatype is one of the few reference types in C#, most datatypes are all value types",
        "Altering a variable passed by reference will not create a copy, and therefore does not need to be returned",
        "A variable passed using the 'out' keyword must not have a value when passed into a function",
        "A variable passed using the 'ref' keyword must have a value when passed into a function",
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

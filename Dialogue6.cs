using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Dialogue6 : MonoBehaviour
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
        "class MyObject\n{\nint i;\nfloat j;\n}\nHow would you instantiate this class within the Main()?",
        "A function/variable can only be accessed within its own class if it is declared...",
        "A function/variable can be used anywhere outside its own class if it is declared...",
        "What operator is used to access a member of a class?",
        "class MyObject\n{\npublic int i;\n}\nHow would you access i after instantiating an object of class MyObject?",
        "A class has the variable 'static int i;'\nWhat does the static keyword do to this variable?",
        "A class that holds a static function means what?",
        "The 'const' keyword on a variable means what?",
        "Which of the following is a reference type?",
        "How would you declare a constructor for 'class MyObject'?",
        "A constructor with no paramters is known as what?",
        "The constructor of a class is called when",
        "A default constructor takes how many arguments?",
        "Assigning a class to another will do what?"
    };

    string[,] answers = { 
        {"MyObject myObj = new MyObject();", "MyObject new myObj;", "MyObject new myObj = MyObject();" },
        {"private", "protected", "public" },
        {"public", "protected", "private" },
        {".", "-", "~" },
        {"myObj.i", "i.myObject", "myObj~i"},
        {"all class instances share the variable", "the variable can only belong to one instance of the class", "the variable can be accessed from other classes"},
        {"the function is called without need of a class instance", "static functions are not allowed in C#", "class instances share the function",  },
        {"the variable cannot be reassigned", "the variable cannot be used as an argument for a function", "the variable cannot be used to assign other variables" },
        {"class", "struct", "bool" },
        {"public MyObject()\n{\n\n}", "public MyFunction(class myObj)\n{\n\n}", "public Constructor()\n{\n\n}" },
        {"a default constructor", "a copy constructor", "a static constructor" },
        {"a class is initialised", "a class is destroyed", "a class causes a program error" },
        {"0", "1", "3" },
        {"make both classes share the same members", "create a separate copy of that class", "cause an error" }
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
        ""
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

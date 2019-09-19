using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Dialogue3 : MonoBehaviour
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
        "if(a && b)\n\nWhat must a and b be for the if statement to be evaluated?",
        "if(a || b)\n\nWhat must a and b be for the if statement to be evaluated?",
        "bool a = false;\nif(a)\nWill the if statement run?",
        "bool a = false;\nif(!a)\nWill the if statement run?",
        "bool a = false, b = true;\nif(!(a || b))\nWill the if statement run?",
        "bool a = false, b = true;\nif(!(a && b))\nWill the if statement run?",
        "Which is the logical AND operator?",
        "Which is the logical OR operator?",
        "Which is the logical NOT operator?",
        "bool a = true, b = false;\nif(!a && b)\nWill the if statement run?",
        "Which is the logical XOR operator?",
        "if(a ^ b)\nWhat must a and b be for the if statement to be evaluated?",
        "bool a = true, b = true;\nif(!a ^ b)\nWill the if statement run?",
        "bool a = true, c = false;\nif(!(a == c))\nWill the if statement run?",
        "if(!(a == c)) is shorthand for what?"
    };


    string[,] answers = { 
        { "true, true", "true, false", "false, false" },
        {"both are acceptable", "true, false", "true, true" },
        {"no", "yes", "will result in an error" },
        {"yes", "no", "will result in an error" },
        {"no", "yes", "will result in an error" },
        {"yes", "no", "will result in an error" },
        {"&&", "||", "!" },
        {"||", "!", "&&" },
        {"!", "&&", "^" },
        {"no", "yes", "will result in an error" },
        {"^", "!", "?" },
        {"true, false", "false, false", "both are acceptable" },
        {"yes", "no", "will result in an error" },
        {"yes", "no", "will result in an error" },
        {"a != c", "a !| c", "a !& c"}
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
        "The && is a logic operator that checks if all booleans in the if statement are true",
        "The || is a logic operator that checks if at least one boolean in the if statement be true",
        "The variable a alone is shorthand for a == true",
        "The negation operator (!) before a bool variable means == false",
        "The negation operator inverts the OR statement, meaning neither can be true for the if statement to run",
        "The negation operator inverts the AND statement, meaning if a and b are true the if statement will not run",
        "&& is the AND operator, it returns true if both bools either side of it are true",
        "|| is the OR operator, it returns true if any of the two bools either side of it are true",
        "! is the NOT operator, it inverts the result of any other logical operation",
        "Neither statement in the if are true, and they would both need to be for the AND operator to return true",
        "^ is the XOR operator, it stands for exclusive OR",
        "The XOR operator (^) only returns true of only one of the operands it works on is true",
        "the ! operator inverts the variable a making the XOR operator return true",
        "a and c are not equal, but the negation operator makes the result true instead of false",
        "a != c means not equal to, which is shorthand for !(a == c)"
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
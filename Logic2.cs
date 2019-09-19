using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logic2 : MonoBehaviour
{
    int i = -1;
    public GameObject contextObject;
    public GameObject contentObject;
    Text contextText;
    Text contentText;
    SceneController scene;

    string[] contextStrings =
    {
        "Imagine we would like to perform a specific task in C#, but only if certain conditions are met",
        "A real life example would be assigning a student a grade depending on what their test score",
        "To do this, C# uses a unique statement, the if statement. The way in which you write a if statement can be seen above",
        "As you can see, you simply write the special keyword 'if' then a pair of brackets. You put your condition in the bracket",
        "Carrying on with the scores example, here you can see the char variable being assigned an A if the student's score is above 80",
        "If the if statement is true, it will run the next statement in the program, in this case it is grade = 'A';",
        "It is important to note that you do not use semicolons to end an if statement, therefore you should not put semicolons after the brackets",
        "Should the if statement evaluate to false, it will skip the next statement in the program",
        "The statement could also be placed on the same line as the if(), see the example above",
        "This is useful, but what if we wanted to skip/execute multiple statements? Currently, the if will only skip/execute the next statement in the program",
        "Using curly brackets (braces), we can chunk all statements we want to be executed by the if statement. The opening bracket opens after the if statement, and the closing bracket is placed after the statements you wish to include in the if chunk",
        "The use of the brackets can be seen above",
        "As you can see, the brackets group the statements meaning that if the if statement is false the entire block of code will be skipped",
        "Console.WriteLine() is a special function in C#, if you are making a program for a console window, Console.WriteLine() will output text to the console line. As you can see the text inside the console.writeline is in quotation marks, this is because the console prints strings",
        "There is an additional piece of functionality that can be used in conjunction with if statements, this optional functionality is the else keyword",
        "The else keyword is used after an if block and means: should the if return false and not conduct the code block after it, process this code block instead",
        "The example above demonstrates the how to use the else keyword",
        "If the if condition is true, the first code block will run and will skip the block after the else",
        "Likewise, if the if condition is false, the if block will not run allowing the block after the else to run",
        "So in essence, the if block runs if the condition is true, whereas the else runs if the condition is false",
        "If you use a bool variable alone in an if statement such as if(a), that is the same as saying if(a == true)",
        "Likewise, if(!a) is equivalent to if(a == false)",
        "This is a shortcut to save writing == true / == false whenever you want to check if a boolean is true or not",
        "This is the end of Logic Terminal 2"

    };
    // Start is called before the first frame update
    void Start()
    {
        scene = GameObject.Find("SceneManager").GetComponent<SceneController>();
        contextText = contextObject.GetComponent<Text>();
        contentText = contentObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            i++;
            if (i == 2) contentText.text = "if(---your conditions go in here---)";
            if (i == 4) contentText.text =  "char grade;\nint studentScore = 87;\nif(studentScore > 80)\ngrade = 'A';";
            if (i == 8) contentText.text = "char grade;\nint studentScore = 87;\nif(studentScore > 80) grade = 'A';";
            if (i == 10) contentText.text = "char grade;\nint studentScore = 87;\nif(studentScore > 80)\n{\ngrade = 'A';\nConsole.WriteLine(\"This is a smart student!\");\n}";
            if (i == 16) contentText.text = "if(a > b)\n{\nConsole.WriteLine(\"a > b is true!\");\n}\nelse\n{\nConsole.WriteLine(\"a > b is false\");\n}";
            if (i == 20) contentText.text = "";
            if (i == contextStrings.Length)
                scene.LoadNewScene("LabRoom2");
            else
                contextText.text = contextStrings[i];
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (i != 0) i--;
            if (i == 2) contentText.text = "if(---your conditions go in here---)";
            if (i == 4) contentText.text = "char grade;\nint studentScore = 87;\nif(studentScore > 80)\ngrade = 'A';";
            if (i == 8) contentText.text = "char grade;\nint studentScore = 87;\nif(studentScore > 80) grade = 'A';";
            if (i == 10) contentText.text = "char grade;\nint studentScore = 87;\nif(studentScore > 80)\n{\ngrade = 'A';\nConsole.WriteLine(\"This is a smart student!\");\n}";
            if (i == 16) contentText.text = "if(a > b)\n{\nConsole.WriteLine(\"a > b is true!\");\n}\nelse\n{\nConsole.WriteLine(\"a > b is false\");\n}";
            if (i == 20) contentText.text = "";

            contextText.text = contextStrings[i];
        }
    }
}

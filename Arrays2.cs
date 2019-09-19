using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrays2 : MonoBehaviour
{
    int i = -1;
    public GameObject contextObject;
    public GameObject contentObject;
    Text contextText;
    Text contentText;
    SceneController scene;

    string[] contextStrings =
    {
        "Arrays tie in with another important concept of most programming languages, loops",
        "Loops are a recursion tool allowing blocks of code to be run repeatedly, until a certain condition is met",
        "There are 3 main types of loops in C#, 'while loops', 'do-while' loops, and 'for loops'",
        "The while loop is the most simple loop, it consists of a conditional statement (such as the ones found in an if statement) followed by a block of code inside braces",
        "For as long as the conditional statement remains true, the code block will run again",
        "The following example shows how a while loop works",
        "Since 5 is large than 1, the while block will constantly run, printing the line \"While loop printed!\" to the console every time",
        "As stated previously, Console.WriteLine is a special C# statement that allows a program to write lines in a console window, useful for console applications",
        "Loops are useful for repeating code, but not indefinetely. The above shows how we can modify the code to stop repeating after so many iterations",
        "We have declared an integer i outside of the loop, and inside the loop we can increase its value by 1 each loop, eventually i will become equal to 5 and therefore the condition will be false, breaking the loop",
        "If the statement was (5 >= i), the iteration would run until i became the value of 6. This is because >= means larger or equal to, so the condition would still be true of i was 5",
        "The second loop is the do-while loop, it is very similar to the while loop with a slightly different layout",
        "The difference between a do-while and a while is that a do-while will always complete one iteration, even if the condition is false, whereas a while loop will not run at all if the condition is false",
        "In the code above, the conditional statement is false, yet the do-while loop will run once before exiting",
        "The final loop is the 'for loop', it is more sophisticated than the other to and is effective at filtering through arrays",
        "Above shows how we declare a for loop",
        "A for loop consists of 3 segements, declaring a variable, checking the variable against a condition, then changing the variable in some way",
        "Every iteration, the condition will be checked, if it is true, the code wil run. At the end of a loop iteration, variable will be changed in some way",
        "In this comman example, i starts at 0, the loop wil run for as long as i is smaller than 50, but at the end of each itertaion i is incremented by 1",
        "This means the loop will run 50 times",
        "This is useful for assigning/sorting through arrays, this example shows how we could assign any values in an array that are larger than 10 to 0",
        ".Length is a special word that can be used on the end of an array name, it will return the length of the array as an integer",
        "Therefore this loop is saying: keep running this loop until i becomes the same size as the array size",
        "The i is put inside the square brackets of the array in order to get the next element in the array each time",
        "if(myArray[i] > 10) means that if the number inside myArray[i] is larger than 10, we will assign it to 0",
        "There are special keywords that can be used to forcefully exit a loop, these are the continue and break keywords",
        "The break keyword will break the out of a loop and exit it immediately, this example shows that if myBool is true, the break; statement will run exiting the loop",
        "If this happens, any code left in the iteration will be skipped, and no more iterations will run",
        "The continue keyword will break out of the current iteration, but will not exit the loop completely, it will simply jump to the next iteration",
        "By using continue;, the loop will iterate indefinitely, only exiting the current iteration, whereas break; will hard exit the loop",
        "This is the end of Arrays Terminal 2"
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
            if (i == 0) contentText.text = "";
            if (i == 5) contentText.text = "while(5 > 1)\n{\nConsole.WriteLine(\"While loop printed!\");\n}";
            if (i == 8) contentText.text = "int i = 0;\nwhile(5 > i)\n{\ni++;\n}";
            if (i == 11) contentText.text = "do\n{\nConsole.WriteLine(\"do-while loop printed!\");\n}\nwhile(5 > 10)";
            if (i == 15) contentText.text = "for(int i = 0; 50 > i; i++)\n{\n\n}";
            if (i == 20) contentText.text = "for(int i = 0; 50 > myArray.Length; i++)\n{\nif(myArray[i] > 10)\nmyArray[i] = 0;\n}";
            if(i == 26) contentText.text = "myBool = true;\nwhile(10 > 5)\n{\nif(myBool == true)\nbreak;\n}";
            if (i == 28) contentText.text = "myBool = true;\nwhile(10 > 5)\n{\nif(myBool == true)\ncontinue;\n}";
            if (i == 30) contentText.text = "";
            if (i == contextStrings.Length)
                scene.LoadNewScene("labRoom3");
            else
                contextText.text = contextStrings[i];
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (i != 0) i--;
            if (i == 0) contentText.text = "";
            if (i == 5) contentText.text = "while(5 > 1)\n{\nConsole.WriteLine(\"While loop printed!\");\n}";
            if (i == 8) contentText.text = "int i = 0;\nwhile(5 > i)\n{\ni++;\n}";
            if (i == 11) contentText.text = "do\n{\nConsole.WriteLine(\"do-while loop printed!\");\n}\nwhile(5 > 10)";
            if (i == 15) contentText.text = "for(int i = 0; 50 > i; i++)\n{\n\n}";
            if (i == 20) contentText.text = "for(int i = 0; 50 > myArray.Length; i++)\n{\nif(myArray[i] > 10)\nmyArray[i] = 0;\n}";
            if (i == 26) contentText.text = "myBool = true;\nwhile(10 > 5)\n{\nif(myBool == true)\nbreak;\n}";
            if (i == 28) contentText.text = "myBool = true;\nwhile(10 > 5)\n{\nif(myBool == true)\ncontinue;\n}";
            if (i == 30) contentText.text = "";
            contextText.text = contextStrings[i];
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Functions : MonoBehaviour
{
    int i = -1;
    public GameObject contextObject;
    public GameObject contentObject;
    Text contextText;
    Text contentText;
    SceneController scene;

    string[] contextStrings =
    {
        "Every program must have an entry point, this is where the the program first begins running",
        "The entry point to any C# program has a unique name and is called the 'Main'",
        "A program can only have one entry point, the way to declare Main is as follows",
        "When the program runs, any code inside the braces will be executed, from top to bottom",
        "The Main() is a unique function",
        "Functions are separate blocks of code that are intended to do specific tasks",
        "They do not run automatically (like the Main does) and will only run if requested to by the Main",
        "Here is a very basic function, take a look at how one would create one",
        "static functions can only call other static functions, because the Main is always static by default, to be called from the main a function must be declared as static. The static keyword will be explained later",
        "The 'int' at the beginning shows that this function returns an integer. If a function has the keyword return in its body, that means that it will return a value back to the Main",
        "The name of the function is decided by the programmer, this allows other programmers who are working on the same code to understand clearly what a function does, in this case the function name is SquareFunction, accurately describing what the function does",
        "In this example there is a function named 'SquareFunction' that returns i * i",
        "In the brackets you can see 'int i', this is to show that the function is expecting an integer value from the Main to work on",
        "Once it is called, it will use the integer by multiplying it by itself before returning it back to the main",
        "But how would you call this function from the Main?",
        "This example shows how you would call the previous function from the Main",
        "You call a function by using the function name then giving the values you would like to send to the function in brackets",
        "In this situation, the integer value 8 is passed to the function. Note that you must pass a value of the type the function requires. In this example you could not pass a float in the brackets becasue the function requires a int",
        "You may be wondering how it is possible to assign a function to an integer; we can do this because the you are assigning whatever the function returns to myInteger, in this case myInteger would be assigned 64",
        "A function is not required to return a value. If the function does not return a value, the keyword 'void' must be used to signify a non returning function",
        "As you can see, the function body does not return a value, therefore its header has the keyword 'void'",
        "You cannot assign a function to a variable if it does not return a value, therefore calling a void function must be called by itself like in the example shown above",
        "It seems logical to believe that myInt will be passed into the function and modified with the new value of 64, although this is not the case",
        "A very important concept in C# is the idea of value types and reference types",
        "If a value type is passed into a function, a copy of the data is created, therefore the i variable in the function is not the same variable as the myInt found within the Main, it is simply a copy",
        "This is the reason the return keyword is useful, we can return the copy and assign it to our original value",
        "Almost all datatypes in C# are value types, except for a select few such as strings, which are reference types",
        "If a reference type is passed into a function, modifying it WILL alter the original",
        "There is a way to alter the original value in a function without having to return a copy, we can use the keyword 'ref'",
        "In the example above, the function is void and returns no value, but because we have declared the integer as a 'ref', modifying it will affect the original",
        "It is important to remember that if modifying a value this way, the ref keyword must be used both in the function header and when the function is called",
        "When using the ref keyword, the variable must be assigned before passing it into the function, the follow code segment is not allowed and will cause an error",
        "The 'out' keyword works similar to the 'ref' keyword, except it can be used to send unassasigned variables into a function, the code above is acceptable",
        "The difference between ref and out is that: ref variables are required to be assigned but do not have to be altered by the function, whereas out variables are not required to be assigned when being passed to a funcion but must be assigned within that function",
        "One last thing to note is that the values that a function is declared to accept are called 'parameters', whereas the values used when calling a function are known as 'arguments'",
        "The arguments of a function must match the parameters, else there will be errors in the code",
        "The example above shows that Addition's paramters are two values of type int, but in the Main the arguments are 2 float values, this is illegal and will cause an error",
        "If the paramters are (int, float) in that order, and you call the function with arguments of (5, 10.4f), this is acceptable",
        "If the paramters are (int, float) in that order, and you call the function with arguments of (10.4f, 5), this is not acceptable as the argument order must match the paramter order",
        "Lastly, the return type of a function does not need to be the same as the fucntion's parameters. In the example above, this function accepts two integers and returns a boolean value depending on if the first argument is larger than the second. 10 is larger than 7, therefore the bool will return and assign myBool to be true",
        "This is the end of Functions Terminal 1"
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
            if (i == 2) contentText.text = "static void Main()\n{\n\n}";
            if (i == 7) contentText.text = "int SquareFunction(int i)\n{\nreturn i * i;\n}";
            if (i == 15) contentText.text = "static void Main()\n{\nint myInteger = SquareFunction(8);\n}";
            if (i == 19) contentText.text = "static void SquareFunction(int i)\n{\ni = i * i;\n}";
            if (i == 21) contentText.text = "static void Main()\n{\nint myInt = 8;\nSquareFunction(myInt);\n}\n\nstatic void SquareFunction(int i)\n{\ni = i * i;\n}";
            if (i == 29) contentText.text = "static void Main()\n{\nint myInt = 8;\nSquareFunction(ref myInt);\n}\n\nstatic void SquareFunction(ref int i)\n{\ni = i * i;\n}";
            if (i == 31) contentText.text = "static void Main()\n{\nint myInt;\nSetToValue(ref myInt);\n}\n\nstatic void SetToValue(ref int i)\n{\ni = 50;\n}";
            if (i == 32) contentText.text = "static void Main()\n{\nint myInt;\nSetToValue(out myInt);\n}\n\nstatic void SetToValue(out int i)\n{\ni = 50;\n}";
            if (i == 34) contentText.text = "";
            if (i == 36) contentText.text = "static void Main()\n{\nint myInt = Addition(5.3f, 4.2f);\n}\nstatic int Addition(int val1, int val2)\n{\nreturn val1 + val2;\n}";
            if (i == 37) contentText.text = "";
            if (i == 39) contentText.text = "static void Main()\n{\nbool myBool = IsLarger(10, 7);\n}\nstatic bool IsLarger(int val1, int val2)\n{\nreturn val1 > val2;\n}";
            if (i == 40) contentText.text = "";
            if (i == contextStrings.Length)
                scene.LoadNewScene("LabRoom2");
            else
                contextText.text = contextStrings[i];
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (i != 0) i--;
            if (i == 0) contentText.text = "";
            if (i == 2) contentText.text = "static void Main()\n{\n\n}";
            if (i == 7) contentText.text = "int SquareFunction(int i)\n{\nreturn i * i;\n}";
            if (i == 15) contentText.text = "static void Main()\n{\nint myInteger = SquareFunction(8);\n}";
            if (i == 19) contentText.text = "static void SquareFunction(int i)\n{\ni = i * i;\n}";
            if (i == 21) contentText.text = "static void Main()\n{\nint myInt = 8;\nSquareFunction(myInt);\n}\n\nstatic void SquareFunction(int i)\n{\ni = i * i;\n}";
            if (i == 29) contentText.text = "static void Main()\n{\nint myInt = 8;\nSquareFunction(ref myInt);\n}\n\nstatic void SquareFunction(ref int i)\n{\ni = i * i;\n}";
            if (i == 31) contentText.text = "static void Main()\n{\nint myInt;\nSetToValue(ref myInt);\n}\n\nstatic void SetToValue(ref int i)\n{\ni = 50;\n}";
            if (i == 32) contentText.text = "static void Main()\n{\nint myInt;\nSetToValue(out myInt);\n}\n\nstatic void SetToValue(out int i)\n{\ni = 50;\n}";
            if (i == 34) contentText.text = "";
            if (i == 36) contentText.text = "static void Main()\n{\nint myInt = Addition(5.3f, 4.2f);\n}\nstatic int Addition(int val1, int val2)\n{\nreturn val1 + val2;\n}";
            if (i == 37) contentText.text = "";
            if (i == 39) contentText.text = "static void Main()\n{\nbool myBool = IsLarger(10, 7);\n}\nstatic bool IsLarger(int val1, int val2)\n{\nreturn val1 > val2;\n}";
            if (i == 40) contentText.text = "";
            contextText.text = contextStrings[i];
        }
    }
}

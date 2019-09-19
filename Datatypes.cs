using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Datatypes : MonoBehaviour
{
    int i = -1;
    public GameObject contextObject;
    public GameObject contentObject;
    Text contextText;
    Text contentText;
    SceneController scene;

    string[] contextStrings =
    {
        "C# is a simple, modern, general-purpose, object-oriented programming language developed by Microsoft within its .NET framework",
        "This section will deal with introducing datatypes, which are the storage containers that C# uses to store information",
        "The main datatypes in C# are types int, float, string, char, bool, double, and decimal, let's take a look at an example of each and some real life uses",
        "The int datatype stores integers (whole numbers ranging from -2147483648 to 2147483647). To declare an int datatype, declare the datatype name (int) then you can give the container any name you wish, in this example the variable is called myInteger",
        "In C#, a semicolon is used to signify the end of a statement",
        "The equals (=) symbol assigns the variable on the right to the variable on the left, in this case myInteger is being assigned the value of 10",
        "The float datatype stores real numbers (decimals), and has an accuracy of 6-9 decimal places",
        "Notice the f after 3.65, this is to tell the compiler that we want to treat that number as a float",
        "The double datatype stores real numbers as well, but more accurately (15-17 decimal places)",
        "There is no suffix after the number because all decimal values are treated as doubles by default",
        "The decimal datatype stores real numbers as well, it is the most accurate decimal and can store numbers up to 29 decimal places",
        "It has the m suffix to signify a decimal, not a d as that is to avoid confusion with the double",
        "The long datatype stores integers similar to an int, but  has double the range (-9,223,372,036,854,775,808 to 9,223,372,036,854,775,807)",
        "The short datatype stores integers as well, but has half the range of an int (-32,768 to 32,767)",
        "The string datatype stores text, this is used for outputting log information or just printing qualitative information to the user",
        "As you can see in the example, it is important to always assign strings variables in quotation marks so the compiler does not mistake it for something other than a string",
        "The byte datatype stores integers from 0-255",
        "The char datatype is similar to that of a string, but only deals with individual characters",
        "char variables are assigned in apostrophes instead of quotation marks",
        "Since the long/decimal datatypes can store more data than their counterparts, would it not be better to use them all the time? No, because the more the datatype can store, the more storage is required for the program to run",
        "If you do not need to deal with such large numbers or accurate decimals, it is better to use smaller range types",
        "There are variants of the main datatypes, a datatype with the letter u before it means unsigned. It has the same range as the original but can only store positive values",
        "See the difference between a uint and a normal int above",
        "The bool datatype is a special type, it does not store numbers or text, but the values 'true' or 'false'",
        "It is named after George Boole, who came up with the first algebraic system of logic in the 19th century",
        "bools are assigned using the special keywords true/false",
        "Because they are reserved keywords in C#, you cannot name a variable true/false",
        "Once you have declared a variable for the first time, you do not have the use the associated datatype with it again, see the example above",
        "In this case, the variable my integer is declared for the first time and assigned to be 26, then the line after it is reassigned to become 15",
        "It is also worth noting that you do not have to assign a varible the line you declare it, see above",
        "A bool variable that has been declared but not assigned will have a default value of 'false'",
        "Another datatype variant is one with an s prefix, the only occuring datatype that has this is the sbyte, which has a range of -128 to 127",
        "This is because bytes are unsigned by default, whereas all other default types are already signed",
        "This is the end of Datatypes Terminal 1"

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
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            i++;
            if (i == 0) contentText.text = "";
            if (i == 3) contentText.text = "int myInteger = 10;";
            if (i == 6) contentText.text = "float aRandomFloat = 3.65f;";
            if (i == 8) contentText.text = "double myDoubleValue = 3.65;";
            if (i == 10) contentText.text = "decimal accurateDecimal = 10.293728m;";
            if (i == 12) contentText.text = "long populationOfUK = 66000000;";
            if(i == 13) contentText.text = "short randomNumber = 10293;";
            if (i == 14) contentText.text = "string studentName = \"John\";";
            if (i == 16) contentText.text = "byte smallNumber = 71;";
            if (i == 17) contentText.text = "char gender = 'F';";
            if(i == 19) contentText.text = "";
            if (i == 22) contentText.text = "int range: -2147483648 to 2147483647\nuint range: 0 to 4294967295";
            if (i == 23) contentText.text = "bool myBool = true;";
            if (i == 26) contentText.text = "";
            if (i == 27) contentText.text = "int myInteger = 26;\nmyInteger = 15;";
            if (i == 29) contentText.text = "int myInteger;\nmyInteger = 15;";
            if(i == 30) contentText.text = "bool myBoolean;";
            if (i == 31) contentText.text = "sbyte aNum = -36;";
            if(i == 33) contentText.text = "";
            if (i == contextStrings.Length)
                scene.LoadNewScene("LabRoom1");
            else
                contextText.text = contextStrings[i];
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(i != 0)i--;
            if (i == 0) contentText.text = "";
            if (i == 3) contentText.text = "int myInteger = 10;";
            if (i == 6) contentText.text = "float aRandomFloat = 3.65f;";
            if (i == 8) contentText.text = "double myDoubleValue = 3.65;";
            if (i == 10) contentText.text = "decimal accurateDecimal = 10.293728m;";
            if (i == 12) contentText.text = "long populationOfUK = 66000000;";
            if (i == 13) contentText.text = "short randomNumber = 10293;";
            if (i == 14) contentText.text = "string studentName = \"John\";";
            if (i == 16) contentText.text = "byte smallNumber = 71;";
            if (i == 17) contentText.text = "char gender = 'F';";
            if (i == 19) contentText.text = "";
            if (i == 22) contentText.text = "int range: -2147483648 to 2147483647\nuint range: 0 to 4294967295";
            if (i == 23) contentText.text = "bool myBool = true;";
            if (i == 26) contentText.text = "";
            if (i == 27) contentText.text = "int myInteger = 26;\nmyInteger = 15;";
            if (i == 29) contentText.text = "int myInteger;\nmyInteger = 15;";
            if (i == 30) contentText.text = "bool myBoolean;";
            if (i == 31) contentText.text = "sbyte aNum = -36;";
            if (i == 33) contentText.text = "";

            contextText.text = contextStrings[i];
        }
    }
}

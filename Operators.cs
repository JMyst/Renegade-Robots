using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Operators : MonoBehaviour
{
    int i = -1;
    public GameObject contextObject;
    public GameObject contentObject;
    Text contextText;
    Text contentText;
    SceneController scene;

    string[] contextStrings =
    {
        "Operators are an important concept in every programming language, they allow you to manipulate variables",
        "Common ones that everyone knows of are that of the addition and subtraction operators, which use the characters + and - respectively",
        "The assignment operator is an equals sign (=) and is used to assign the variable on the right to the variable on the left",
        "This example demonstrates the assignment and addition operators being used to perform a simple calculation",
        "The additional operator adds the two values either side of it, then the assignment operator assigns the combined values of 13 to myValue3",
        "The multiplication operator is an asterisk (*) in C# and will multiply values, in this case myValue3 will be assigned the value of 15",
        "The division operator is a slash (/), be careful when using this operator with integer datatypes, as you will not get a decimal value in return, therefore the result will be inaccurate",
        "In this scenario, myValue3 would be assigned the value of 1",
        "Operands are the name of the variables an operator works on, in this case, the operands are myValue and myValue2",
        "The modulus operator, which uses a percentage symbol, is used to divide a number by another, then return any remainders from the division",
        "The example shows how the modulus operates. In this case, myValue3 will be assigned the value of 2 as 14/3 will leave a remainder of 2",
        "If a number leaves no remainders, the value will return 0",
        "The ++ and -- operators are rather unique, in that they only operate on one operand, these are known as unary operators",
        "They increment or decrement a value by 1, the example above demonstrates this",
        "In this scenario, myValue1 will become 15 after the operation",
        "Be careful though, if the operator is on the right side of the operand when assigning, it will assign the value before being incremented",
        "myValue2 will be assigned 5, only then will myValue1 be incremented",
        "Having the increment operator before the variable will increment it before assigning myValue2, meaning myValue2 will be assigned the value 6",
        "When performing operations, having an operation in brackets means that it will be the first operation to be evaluated",
        "In this operation, the addition operator will add 6 + 2 to make 8, then times that by 6 to assign myValue3 to 48",
        "Moving the brackets will affect the outcome of the operation, this time 6 * 6 = 36 plus 2 equals 38",
        "There are a set of unique operators spefically used for working with booleans, these are == and <",
        "The equality operator (==) uses two equation symbols side-by-side and should not be confused with the assignment (=) operator",
        "The equality operator returns 'true' if the values either side are equal",
        "In this example, myBool would be assigned true since the equality operator will evaluate 3 and 3 to be equal",
        "The < operator evaluates if the value on the right is larger than the value on the left. This operator can be flipped to face left >, in this case, it checks to see if the number on the left is larger",
        "Since 3 is not larger than 10, the statement is false, therefore myBool will be assigned false",
        "There are more logical operators that work in conjunction with booleans but that is explained later on",
        "Imagine you have a variable (value) of type int, and you want to add 5 to the variable, instead of writing value = value + 5; you can use compound operators",
        "These combine +, -, /, * with the assignment = operator to allow you to increment a variable by a desired amount",
        "The example above shows how you can add 10 to an existing variable without having to write myInteger = myInteger + 10;",
        "This is the end of Operators Terminal 1"
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
            if (i == 3) contentText.text = "int myValue1 = 4;\nint myValue2 = 9;\nint myValue3 = myValue1 + myValue2;";
            if (i == 5) contentText.text = "int myValue1 = 3;\nint myValue2 = 5;\nint myValue3 = myValue1 * myValue2;";
            if(i == 6) contentText.text = "int myValue1 = 9;\nint myValue2 = 6;\nint myValue3 = myValue1 / myValue2;";
            if (i == 9) contentText.text = "int myValue1 = 14;\nint myValue2 = 3;\nint myValue3 = myValue1 % myValue2;";
            if (i == 12) contentText.text = "int myValue1 = 14;\nmyValue1++;";
            if (i == 15) contentText.text = "int myValue1 = 5;\nint myValue2 = myValue1++;";
            if (i == 17) contentText.text = "int myValue1 = 5;\nint myValue2 = ++myValue1;";
            if (i == 18) contentText.text = "int myValue1 = 6;\nint myValue2 = 2;\nint myValue3 = myValue1 * (myValue1 + myValue2);";
            if (i == 20) contentText.text = "int myValue1 = 6;\nint myValue2 = 2;\nint myValue3 = (myValue1 * myValue1) + myValue2;";
            if (i == 21) contentText.text = "";
            if (i == 23) contentText.text = "bool myBool = 3 == 3;";
            if (i == 25) contentText.text = "bool myBool = 3 > 10;";
            if (i == 28) contentText.text = "";
            if (i == 29) contentText.text = "int myInteger = 45;\nmyInteger += 10;";
            if (i == contextStrings.Length)
                scene.LoadNewScene("LabRoom1");
            else
                contextText.text = contextStrings[i];
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (i != 0) i--;
            if (i == 3) contentText.text = "int myValue1 = 4;\nint myValue2 = 9;\nint myValue3 = myValue1 + myValue2;";
            if (i == 5) contentText.text = "int myValue1 = 3;\nint myValue2 = 5;\nint myValue3 = myValue1 * myValue2;";
            if (i == 6) contentText.text = "int myValue1 = 9;\nint myValue2 = 6;\nint myValue3 = myValue1 / myValue2;";
            if (i == 9) contentText.text = "int myValue1 = 14;\nint myValue2 = 3;\nint myValue3 = myValue1 % myValue2;";
            if (i == 12) contentText.text = "int myValue1 = 14;\nmyValue1++;";
            if (i == 15) contentText.text = "int myValue1 = 5;\nint myValue2 = myValue1++;";
            if (i == 17) contentText.text = "int myValue1 = 5;\nint myValue2 = ++myValue1;";
            if (i == 18) contentText.text = "int myValue1 = 6;\nint myValue2 = 2;\nint myValue3 = myValue1 * (myValue1 + myValue2);";
            if (i == 20) contentText.text = "int myValue1 = 6;\nint myValue2 = 2;\nint myValue3 = (myValue1 * myValue1) + myValue2;";
            if (i == 21) contentText.text = "";
            if (i == 23) contentText.text = "bool myBool = 3 == 3;";
            if (i == 25) contentText.text = "bool myBool = 3 > 10;";
            if (i == 28) contentText.text = "";
            if (i == 29) contentText.text = "int myInteger = 45;\nmyInteger += 10;";
            contextText.text = contextStrings[i];
        }
    }
}

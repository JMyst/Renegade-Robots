using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logic : MonoBehaviour
{
    int i = -1;
    public GameObject contextObject;
    public GameObject contentObject;
    Text contextText;
    Text contentText;
    SceneController scene;

    string[] contextStrings =
    {
        "Boolean logic is a form of algebra and uses 3 simple statements: AND, OR and NOT",
        "By using these 3 logic operators in conjunction with bool variables, you can create your own logic",
        "The AND operator uses two ampersands side-by-side (&&) and checks if the two values next to it are both true",
        "Both values must be true else the operator will evaluate to be false",
        "Here, the bool variable c will be assigned the value of true, since a and b are both true",
        "This time however, c will be assigned false because a and b are not both true",
        "The OR operator uses two verticle slashes side-by-side (||) and checks if at least one of the values either side of it are true",
        "Here, c is assigned to be true since at least one out of a and b is true",
        "The NOT operator uses the exclamation symbol (!) and is used to negate/invert the effect of other logical operators",
        "In the example above, c will be assigned true despite a and b not both being true",
        "This is because the && will evaluate the statement to be false, but the NOT operator will invert the sign from false to true",
        "The && operation is in brackets so it gets evaluated before the negation operator negates anything",
        "!(a && b) means check if a is true and b is true, then whatever the result is, invert it",
        "With no brackets !a && b means invert the value of a, then check it against b, then return true if those requirements are met",
        "There is a variant of the OR operator, it is known as the XOR operator and stands for exclusive-OR and uses the symbol ^",
        "It functions similar to the OR operator, but only returns true if one value is true and the other is false",
        "Here, c would be assigned false as both a and b are both true",
        "Since the equality operator (==) returns a type bool, it can be used with other boolean operators",
        "This example shows how other datatypes can be used to assign a boolean",
        "This looks complex, but is rather simple. The conditions for the statement to be true are that integer i must be larger than integer j, but also that i % 2 equals 0, or in other words, an even number",
        "If both conditions are true, which they are, then b will be assigned to be true",
        "This is the end of Logic Terminal 1"

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
            if (i == 4) contentText.text = "bool a = true;\nbool b = true;\nbool c = a && b;";
            if (i == 5) contentText.text = "bool a = true;\nbool b = false;\nbool c = a && b;";
            if (i == 6) contentText.text = "";
            if (i == 7) contentText.text = "bool a = true;\nbool b = false;\nbool c = a || b;";
            if (i == 8) contentText.text = "";
            if (i == 9) contentText.text = "bool a = true;\nbool b = false;\nbool c = !(a && b);";
            if (i == 14) contentText.text = "";
            if (i == 16) contentText.text = "bool a = true;\nbool b = false;\nbool c = a ^ b;";
            if (i == 18) contentText.text = "int i = 16;\nint j = 3;\nbool a = (i > j) && (i % 2 == 0)";
            if (i == 21) contentText.text = "";
            if (i == contextStrings.Length)
                scene.LoadNewScene("LabRoom2");
            else
                contextText.text = contextStrings[i];
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (i != 0) i--;
            if (i == 4) contentText.text = "bool a = true;\nbool b = true;\nbool c = a && b;";
            if (i == 5) contentText.text = "bool a = true;\nbool b = false;\nbool c = a && b;";
            if (i == 6) contentText.text = "";
            if (i == 7) contentText.text = "bool a = true;\nbool b = false;\nbool c = a || b;";
            if (i == 8) contentText.text = "";
            if (i == 9) contentText.text = "bool a = true;\nbool b = false;\nbool c = !(a && b);";
            if (i == 14) contentText.text = "";
            if (i == 16) contentText.text = "bool a = true;\nbool b = false;\nbool c = a ^ b;";
            if (i == 18) contentText.text = "int i = 16;\nint j = 3;\nbool a = (i > j) && (i % 2 == 0)";
            if (i == 21) contentText.text = "";
            contextText.text = contextStrings[i];
        }
    }
}

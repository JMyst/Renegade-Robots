using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Datatypes2 : MonoBehaviour
{
    int i = -1;
    public GameObject contextObject;
    public GameObject contentObject;
    Text contextText;
    Text contentText;
    SceneController scene;

    string[] contextStrings =
    {
       "This section gives an overview of the datatypes in C#, in a more systematic format",
       "",
       "",
       "",
       "",
       "",
       "",
       "",
       "",
       "",
       "Strings are just sequences of characters",
       "This is the end of Datatypes Terminal 2"
         

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
            if (i == 1) contentText.text = "Type: int\nSize: 4 bytes\nRange: -2147483648 to 2147483647";
            if (i == 2) contentText.text = "Type: short\nSize: 2 bytes\nRange: -32768 to 32767";
            if (i == 3) contentText.text = "Type: long\nSize: 8 bytes\nRange: -9223372036854775808 to 9223372036854775807";
            if (i == 4) contentText.text = "Type: byte\nSize: 1 byte\nRange: 0 to 255";
            if (i == 5) contentText.text = "Type: float\nSize: 4 bytes\nRange: 6-9 decimal places";
            if (i == 6) contentText.text = "Type: double\nSize: 8 bytes\nRange: 15-17 decimal places";
            if (i == 7) contentText.text = "Type: decimal\nSize: 16 bytes\nRange: up to 29 decimal places";
            if (i == 8) contentText.text = "Type: bool\nSize: 1 byte\nRange: true/false";
            if (i == 9) contentText.text = "Type: char\nSize: 2 bytes\nRange: any character (including numbers/symbols)";
            if (i == 10) contentText.text = "Type: string\nSize: n/a\nRange: n/a";
            if (i == 11) contentText.text = "";
            if (i == contextStrings.Length)
                scene.LoadNewScene("LabRoom1");
            else
                contextText.text = contextStrings[i];
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (i != 0) i--;
            if (i == 0) contentText.text = "";
            if (i == 1) contentText.text = "Type: int\nSize: 4 bytes\nRange: -2147483648 to 2147483647";
            if (i == 2) contentText.text = "Type: short\nSize: 2 bytes\nRange: -32768 to 32767";
            if (i == 3) contentText.text = "Type: long\nSize: 8 bytes\nRange: -9223372036854775808 to 9223372036854775807";
            if (i == 4) contentText.text = "Type: byte\nSize: 1 byte\nRange: 0 to 255";
            if (i == 5) contentText.text = "Type: float\nSize: 4 bytes\nRange: 6-9 decimal places";
            if (i == 6) contentText.text = "Type: double\nSize: 8 bytes\nRange: 15-17 decimal places";
            if (i == 7) contentText.text = "Type: decimal\nSize: 16 bytes\nRange: up to 29 decimal places";
            if (i == 8) contentText.text = "Type: bool\nSize: 1 byte\nRange: true/false";
            if (i == 9) contentText.text = "Type: char\nSize: 2 bytes\nRange: any character (including numbers/symbols)";
            if (i == 10) contentText.text = "Type: string\n=Size: n/a\nRange: n/a";
            if (i == 11) contentText.text = "";

            contextText.text = contextStrings[i];
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrays : MonoBehaviour
{
    int i = -1;
    public GameObject contextObject;
    public GameObject contentObject;
    Text contextText;
    Text contentText;
    SceneController scene;

    string[] contextStrings =
    {
        "In C#, we can declare groups of data by using arrays",
        "An array, as its name suggests, is a collection of a specific datatype, such as an array of ints",
        "Arrays are useful for storing and managing large scales of data, especially if they are closely related (for example metric data)",
        "To declare an array, simply declare the datatype followed by two square brackes ([]), then you can give it an identifier name which is chosen by the programmer",
        "Although you have declared an array, it is not yet instantiated. To instantiate this array, you will need to use '= new int[10]'",
        "The 'new' keyword is used to create objects, whilst the number within the square brackets indicates what size you would like the array to be. This array would hold 10 integers",
        "You may be wondering why int i = 5; does not require the new keyword, or is used for any other datatype seen so far. This is because arrays are reference types, not value types. Any integral (integer type), floating-point (decimal type) or bool is a value type, meaning using the new keyword is not necessary",
        "The new keyword will initialise the array with default values, in this case the default values for the int array would all be 0",
        "To access an element in the array, you can declare the array name, followed by square brackets with the element number within, the example above shows how you would assign the 5th element in the array to the number 40",
        "Arrays are indexed at 0, meaning that myArray[0] refers to the first element in the array, therefore myArray[4] is in fact the 5th element in the array",
        "Be careful though, if you use an array value to assign or be assigned, it must be within range of the array, consider the following example",
        "The array has a size of 10 but the line below is trying to access element 17, which does not exist, this will produce an error",
        "You can initialise an array the line you declare it, this can be done by assigning the array to a sequence of values inside braces, as shown above",
        "Each value is separated by a comma",
        "You can also declare 2D arrays, these are essentially arrays of arrays",
        "To do this, you put a comma in the square brackets when declaring the 2D array",
        "The example shows how you would declare a 5x3 array of integers",
        "If you wanted to manually declare values for a 2D array, when assigning, each element will be inside its own array of elements",
        "You access a 2D array the same way you would access any other, the example above assigns the number 8 to row 2, column 3 in the array",
        "This is the end of Arrays Terminal 1"
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
            if (i == 3) contentText.text = "int[] myArray;";
            if (i == 4) contentText.text = "int[] myArray = new int[10];";
            if (i == 8) contentText.text = "myArray[4] = 40;";
            if (i == 10) contentText.text = "int[] myArray = new int[10];\nmyArray[17] = 134;";
            if (i == 12) contentText.text = "int[] myArray = { 1, 7, 14, 38, 0, 134, 1003, 3, 7, 345 };";
            if (i == 16) contentText.text = "int[,] my2DArray = new int[5, 3];";
            if (i == 17) contentText.text = "int[,] my2DArray = { { 1, 6, 3, 2, 9}, { 3, 9, 10, 5, 1 }, { 9, 2, 9, 5, 1 };";
            if (i == 18) contentText.text = "my2DArray[1, 2] = 8;";
            if (i == 19) contentText.text = "";
            if (i == contextStrings.Length)
                scene.LoadNewScene("labRoom3");
            else
                contextText.text = contextStrings[i];
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (i != 0) i--;
            if (i == 0) contentText.text = "";
            if (i == 3) contentText.text = "int[] myArray;";
            if (i == 4) contentText.text = "int[] myArray = new int[10];";
            if (i == 8) contentText.text = "myArray[4] = 40;";
            if (i == 10) contentText.text = "int[] myArray = new int[10];\nmyArray[17] = 134;";
            if (i == 12) contentText.text = "int[] myArray = { 1, 7, 14, 38, 0, 134, 1003, 3, 7, 345 };";
            if (i == 16) contentText.text = "int[,] my2DArray = new int[5, 3];";
            if (i == 17) contentText.text = "int[,] my2DArray = { { 1, 6, 3, 2, 9}, { 3, 9, 10, 5, 1 }, { 9, 2, 9, 5, 1 };";
            if (i == 18) contentText.text = "my2DArray[1, 2] = 8;";
            if (i == 19) contentText.text = "";
            contextText.text = contextStrings[i];
        }
    }
}

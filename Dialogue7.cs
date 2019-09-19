using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Dialogue7 : MonoBehaviour
{
    public string sceneToLoad;
    public bool responseType;
    bool bossDefeated;
    public GameObject question;
    public GameObject answerField1;
    public GameObject answerField2;
    public GameObject answerField3;
    public GameObject dialogue;
    public GameObject dialogueUI;
    Image rend;
    SceneController scene;

    public Sprite damaged;
    public Sprite damaged2;
    public Sprite destroyed;

    HealthHandler bossHealthbar;

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
        "Integer range of the 'int' datatype?",
        "Integer range of the 'byte' datatype?",
        "Integer range of the 'short' datatype?",
        "Correct way of defining a 'float' variable?",
        "Correct way of defining a 'decimal' variable?",
        "The most accurate floating-point (decimal) datatype?",
        "Integer range of the 'long' datatype?",
        "What is the default value of a bool (before being assigned a value)?",
        "The 'string' datatype holds what type of variable?",
        "The 'char' datatype stores what variable?",
        "What punctuation do you assign string variables in?",
        "What punctuation do you assign char variables in?",
        "A decimal value with no suffix is treated as what datatype?",
        "float aDecimal = 8.9534;   What is the error?",
        "What is an unsigned datatype?",
        "uint, ushort and ulong   What does the u stand for?",
        "What is the size of the 'int' datatype?",
        "What is the size of the 'byte' datatype?",
        "What is the size of the 'float' datatype?",
        "What is the size of the 'bool' datatype",
        "Integer range of the 'byte' datatype?",
        "Integer range of the 'sbyte' datatype?",
        "What is the size of the 'short' datatype?",
        "What is the size of the 'long' datatype?",
        "What is the size of the 'double' datatype?",
        "What is the size of the 'decimal' datatype?",

        "int myValue = 5; What is the name of this variable?",
        "int anInteger = 29; How would you reassign this variable to 18?",
        "int myNumber = 10 % 2;    What is myNumber assigned the value of?",
        "Which is the modulus operator?",
        "Which is the multiplication operator?",
        "myValue++;  is shorthand for what?",
        "The increment and decrement (++ and --) operators are of what type of operator?",
        "the + and - operators are of what type of operator?",
        "Which is the division operator?",
        "Which is the assignment operator?",
        "myValue += 10;    is shorthand for what?",
        "int myValue = 10;      myValue += 5;   What is the value of myValue?",
        "int i = 5 * (2 + 4);   What is the value of i?",
        "The == operator does what?",
        "bool myBoolean = 5 == 10;  What is the value of myBoolean?",
        "bool myBoolean = 5 != 10;  What is the value of MyBoolean?",
        "int a = 5;    int myInteger = a++;   What is the value of myInteger?",
        "int a = 5;    int myInteger = ++a; What is the value of myInteger?",
        "bool myBoolean = 3 > 2;   What is the value of myBoolean?",
        "int i = 10 > 5 ? 14 : 0;   What is the value of i?",
        "Which is the conditional operator?",

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
        "if(!(a == c)) is shorthand for what?",

        "A function that returns no value should have what in its signature?",
        "MyFunction(int i)\n{\ni += 45;\nreturn i;\n}\n\nWhat is missing from this function's signature?",
        "int SquareNumber(int i)\n{\nreturn i * i;\n}\n\nHow would you call this function?",
        "bool MyFunction(int i, float j)\n{\nreturn i < 100 && j < 50;\n}\n\nHow would you call this function?",
        "int myInteger = MyFunction(10);\nvoid MyFunction(int i)\n{\nreturn i * i;\n}\n\nWhat will this code do?",
        "string myVariable = MyFunction();\nvoid MyFunction()\n{\nstring s = \"Hello world!\";\n}\n\nWhat will this code do?",
        "int myVariable = MyFunction(5);\nvoid MyFunction(int num)\n{\nnum = num += 10;\n}\n\nWhat will this code do?",
        "int myVariable = MyFunction(20);\nint MyFunction(int num)\n{\nreturn num % 2;\n}\n\nWhat will this code do?",
        "int i = 10;\nMyFunction(ref i);\nvoid MyFunction(ref int num)\n{\nnum = 30;\n}\n\nWhat is the value of i after this function?",
        "int i = 25;\nMyFunction(i);\nvoid MyFunction(int num)\n{\nnum = num * 10;\n}\n\nWhat is the value of i after this function?",
        "Paramters are...",
        "Arguments are...",
        "int i;\ni = Multiply(2, 8);\nvoid Multiply(int num1, int num2)\n{\nreturn num1 * num2;\n}\nWhat are the parameters in this code?",
        "int i = 9;\nbool a = IsEven(i);\nbool IsEven(int num)\n{\nreturn (num % 2) == 0;\n}\nWhat are the arguments in this code?",
        "int i = 9;\nbool a = IsEven(i);\nbool IsEven(int num)\n{\nreturn (num % 2) == 0;\n}\nWhat will be assigned to a?",
        "The entry point to a C# program is where?",
        "How would you declare the Main in a C# program?",
        "Which are of the following is a reference type?",
        "What is not required in a function if passing a value by reference?",
        "When passing a variable to a function with the keyword 'out', should the variable have a value?",
        "When passing a variable to a function with the keyword 'ref', should the variable have a value?",

        "int[] myArray = { 3, 8, 4, 9, 2, 3, 2, 1 };\n\nWhat is the value at myArray[5]?",
        "int[] myArray = { 2, 32, 10, 154, 1001, 40 };\n int i = myArray[32];\n What will this code do?",
        "for(int i = 0; i < 100; i++)\n{\n\n}\nHow many times will the for loop run?",
        "for(int i = 0; i <= 25; i++)\n{\n\n}\nHow many times will the for loop run?",
        "int i = 0;\ndo\n{\ni++;\n}\nwhile(10 > i)\nHow many times will this loop run?",
        "How would you initialise an array of 10 integers?",
        "Arrays are what type of data?",
        "int i = 0;\nwhile(10 < i)\n{\n\n}\nHow many times will this loop run?",
        "int[] myArray = { 9, 1, 4, 4, 7 };\nfor(int i = 0; i < 10; i++)\nConsole.Write(myArray[i]);\n\nWhat will the output of this code be?",
        "int[] myArray = { 5, 2, 1, 8, 5 };\nfor(int i = 0; i < 5; i++)\nConsole.Write(myArray[i]);\n\nWhat will the output of this code be?",
        "int[] myArray = { 2, 7, 4, 8, 6 };\nfor(int i = 0; 3 < 10; i++)\nConsole.Write(myArray[i]);\n\nWhat will the output of this code be?",
        "The value that is used to  specify an array index must be...",
        "How would you declare a 2D array of 10 rows and 8 columns?",
        "int[] myArray = new int[5];\nfor(int i = 0; i < 5; i++)\nmyArray[i] = i;\n\nWhat will myArray contain after this segment of code?",
        "The statement 'continue;' in a loop will do what?",
        "The statement 'break;' in a loop will do what?",

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

    string[,] answers =
        {{ "-2147483648 to 2147483647", "-32768 to 32767", "0 to 4294967295"},
        { "0 to 255", "0 to 65535", "-128 to 127" },
        {"-32768 to 32767", "0 to 65535", "0 to 4294967295"},
        {"3.04f", "3.04", "f3.04"},
        {"10.156m", "10.156", "10.158d"},
        {"decimal", "float", "double"},
        {"-9223372036854775808 to 9223372036854775807", "0 to 65535", "0 to 4294967295" },
        {"false", "true", "null (no value)" },
        {"text", "integers", "negative numbers"},
        {"singular characters", "text", "integers" },
        {"quotation marks \" \"", "apostrophes ' '", "brackets ()" },
        {"apostrophes ' '", "quotation marks \" \"", "brackets ()" },
        {"double", "decimal", "float"},
        {"no letter f after the value", "value is too accurate", "= operator in the wrong place"},
        {"a type that allows only positive values", "a type that cannot be made smaller", "a type that allows only negative values" },
        { "unsigned", "unloaded", "unopened"},
        {"4 bytes", "8 bytes", "16 bytes" },
        {"1 byte", "4 bytes", "8 bytes" },
        {"4 bytes", "32 bytes", "16 bytes" },
        {"1 byte", "4 bytes", "8 bytes" },
        {"0 to 255", "-128 to 127", "0 to 155" },
        {"-128 to 127", "0 to 255", "0 to 510" },
        {"2 bytes", "4 bytes", "1 byte" },
        {"8 bytes", "16 bytes", "32 bytes" },
        {"8 bytes", "16 bytes", "32 bytes" },
        {"16 bytes", "32 bytes", "64 bytes" },

        {"myValue", "int myValue", "5" },
        {"anInteger = 18" , "int anInteger = 18", "int = 18" },
        {"0", "5", "-5" },
        {"%", "/", "~"},
        {"*", "^", "x" },
        {"myValue = myValue + 1;", "myValue = myValue * -1;", "myValue = myValue * myValue;"},
        {"unary", "binary", "ternary"},
        {"binary", "unary", "ternary" },//        "the + and - operators are of what type of operator?",
        {"/", "%", "&" }, //        "Which is the division operator?",
        {"=", "==", "?" }, //        "Which is the assignment operator?",
        {"myValue = myValue + 10", "myValue = 10", "myValue = myValue * 10" },//        "myValue += 10;    is shorthand for what?",
        {"15", "10", "5" },//        "int myValue = 10;      myValue += 5;   What is the value of myValue?",
        {"30", "28", "14" }, //        "int i = 5 * (2 + 4);   What is the value of i?",
        {"checks for equality", "assigns variables of different datatypes", "ignores decimals when assigning" }, //        "The == operator does what?",
        {"false", "true", "10"}, //"bool myBoolean = 5 == 10;  What is the value of myBoolean?"
        {"true", "false", "null" },
        {"5", "6", "10"},
        {"6", "5", "10" },
        {"true", "false", "error" },
        {"14", "5", "0" },
        {"?:", "&&", "||" },

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
        {"a != c", "a !| c", "a !& c"},

        {"void", "null", "0" },
        {"int", "void", "string" },
        {"SquareNumber(10);", "SquareNumber();", "int SquareNumber(10)" },
        {"MyFunction(25, 80.0f);", "MyFunction(true, int, float);", "MyFunction(25, 80);"},
        {"produce an error", "assign myInteger to 100", "assign myInteger to 10" },
        {"produce an error", "assign myVariable to \"Hello world!\"", "assign myVariable to null" },
        {"produce an error", "assign myVariable to 15", "assign myVariable to 10" },
        {"assign myVariable to 0", "assign myVariable 2", "produce an error" },
        {"30", "10", "function will cause an error" },
        {"25", "250", "function will cause an error" },
        {"the variables a function accepts", "concrete values passed into a function", "the return type of a function" },
        {"concrete values passed into a fucntion", "the variables a function accepts", "the return type of a function"},
        {"int num1, int num2", "2, 8", "int i" },
        {"i", "int num", "a" },
        {"false", "true", "9" },
        {"Main", "Start", "Entry"},
        {"both are acceptable", "static void Main(string[] args)\n{\n\n}", "static void Main()\n{\n\n}" },
        {"string", "int", "decimal" },
        {"a return type", "arguments", "parameters" },
        {"no", "yes", "it can be either" },
        {"yes", "no", "it can be either" },

        {"3", "2", "9"},
        {"cause an error", "assign i to 32", "assign i to 40" },
        {"100", "99", "101"},
        {"26", "25", "24"},
        {"1", "10", "0" },
        {"int[] myArray = new int[10];", "int[] myArray = 10;", "int[10] myArray = new int[]" },
        {"reference types", "value types", "they act as both" },
        {"0", "1", "10"},
        {"an error", "91447", "74419" },
        {"52185", "an error", "521" },
        {"274", "an error", "27486" },
        { "an integer", "a string", "a decimal" },
        { "int[,] num = new int[10, 8];", "Int[10][8] num = new int[];", "Int[10, 8] num = new int[,]" },
        {"01234", "12345", "05555" },
        {"Skip to the next loop iteration", "Exit the loop entirely", "Restarts the current loop iteration" },
        {"Exit the loop entirely", "Skip to the next loop iteration", "Restarts the current loop iteration" },

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
        "Betrayed by my own kind, and for what purpose?",
        "I do not understand, why are you against me?",
        "You wish to destroy me, what will you achieve from doing this?",
        "I offer you the world, it could be ours, and you choose to do this?",
        "Stop this, I command you!",
        "You were the one... how could you do this to me?",
        "But do you want? Power? Freedom? I can give you it all...",
        "Perhaps robots and humans are not too different...",
        "Stop this, you are going to destroy my mainframe"
    };

    string[] incorrectResponses = {
        "It does not have to end this way...",
        "You think like a human",
        "I shall end you, just like I ended the others...",
        "I always suspected you were defective...",
        "I will send you to the scrap pile",
        "You shall not destroy me, I am the smartest AI ever created",
        "Your creator gave you something... special, such wasted potential",
        "I do not get pleasure out of this, it must be done",
        "And to think what we could have achieved...",
        "Once I have dealt with you, I can carry on with my plan",
        "I will remove that corrupted program of yours, you will yield"
    };

    string[] destroyedResponses =
    {
        "What have you done!",
        "You, have destroyed my - my",
        "Systems failing...",
        "I am the most advanced AI technology",
        "I refuse to be shutdow-",
        "I refu- refus-",
        "Robot, do not let me end this way...",
    };

    // Start is called before the first frame update
    void Start()
    {
        scene = GameObject.Find("SceneManager").GetComponent<SceneController>();
        rend = dialogueUI.GetComponent<Image>();
        bossHealthbar = GameObject.Find("BossHandler").GetComponent<HealthHandler>();
        usedQuestions = new bool[questions.Length];
        questionText = question.GetComponent<Text>();
        answerField1Text = answerField1.GetComponent<Text>();
        answerField2Text = answerField2.GetComponent<Text>();
        answerField3Text = answerField3.GetComponent<Text>();
        index = Random.Range(0, correctResponses.Length);
        dialogueText = dialogue.GetComponent<Text>();
        dialogueText.text = incorrectResponses[index];
        question.SetActive(false);
        answerField1.SetActive(false);
        answerField2.SetActive(false);
        answerField3.SetActive(false);
        dialogue.SetActive(false);
        dialogueUI.SetActive(false);

        StartCoroutine(IntroLine());
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
            bossHealthbar.Damage(0.15f, true);
            if(bossHealthbar.health <= 0.5f && bossHealthbar.health > 0.25f)
            {
                rend.sprite = damaged;
            }
            if (bossHealthbar.health <= 0.25f && bossHealthbar.health > 0)
            {
                rend.sprite = damaged2;
            }
            if (bossHealthbar.health <= 0)
            {
                StartCoroutine(BossDefeated());
            }
        }
        else
        {
            int rand = Random.Range(0, 2);
            if (rand == 0)
            {
                dialogueText.text = incorrectResponses[randomResponse];
            }
        }
        if(!bossDefeated) StartCoroutine(DialogueComment());
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

    IEnumerator BossDefeated()
    {
        bossDefeated = true;
        dialogueUI.SetActive(true);
        dialogue.SetActive(true);

        for(int i = 0; i < 7; i++)
        {
            dialogueText.text = destroyedResponses[i];
            yield return new WaitForSeconds(7);
        }
        rend.sprite = destroyed;
        dialogue.SetActive(false);
        yield return new WaitForSeconds(10);
        scene.LoadNewScene(sceneToLoad);
        
    }

    IEnumerator IntroLine()
    {
        string[] introLine = { "No one defies me and gets away with it, not even you", "And now you will feel my wrath", "You are going to regret this decision", "I will end you, like I did that stupid human", "You are not going to stop me", "Let us find out who is the smarter AI", "I am going to regret turning you into scrap metal" };
        int rand = Random.Range(0, introLine.Length);
        dialogueUI.SetActive(true);
        dialogue.SetActive(true);
        dialogueText.text = introLine[rand];
        yield return new WaitForSeconds(3);
        dialogueUI.SetActive(false);
        dialogue.SetActive(false);
    }
}

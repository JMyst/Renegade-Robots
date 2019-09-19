using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Classes : MonoBehaviour
{
    int i = -1;
    public GameObject contextObject;
    public GameObject contentObject;
    Text contextText;
    Text contentText;
    SceneController scene;

    string[] contextStrings =
    {
        "Classes are a fundemental part of C#",
        "C# is an object oriented language, meaning that you can create blueprints/templates for objects, allowing you to then create as many objects you would like",
        "These blueprints are known as classes. Classes can hold variables and functions",
        "A class is not an object itself, it is simply the template for one. In order to create an object from the class template, you must do so in the Main",
        "Here is a simple class that represents a student. The student class has a name, age, area of study, and university",
        "The class also comes with a function, the function 'PrintStudentInfo()' does exactly that, it prints all info on that particular student to the console window",
        "The variables used in the Console.WriteLine do not need to be put in quotation marks, because the variables are already strings",
        "You may have noticed that none of the variables are initialised, this is because this is a template, when we create a student object using this class, we can give proper values to the object",
        "Functions within a class are like any other function, they will only run if called from somewhere",
        "This code shows how to create an object in the Main() using the student class",
        "The new operator is used again here, this is because classes are reference types, meaning you must manually create the object using 'new'",
        "The Student() segment on the right is the object's constructor function",
        "A constructor is a special function belonging to objects and is only called once during an object's lifetime, when it is created",
        "As a programmer, you do not need to declare a constructor if you do not want to modify an object at the time of creation, this is because C# creates an empty one for you by default",
        "If you would like to declare your own constructor, you declare it within the class and its name must be the same as the class name, see above for example",
        "A constructor has no return type, not even a void keyword",
        "If a constructor has parameters, like shown above, it will allow you to pass values into the constructor when creating an object",
        "In the Main(), when creating a student object you can pass a name and age as arguments so when the constructor is called it will assign that student object a name and age",
        "A constructor does not require parameters, in the example above, the constructor takes no arguments, but when called will still assign some preliminary information",
        "You may be wondering what the public keyword means in the function 'PrintStudentInfo();' and on the variables, this keyword is an accessibity modifier",
        "An accessibility modifier can allow variables and functions within classes to be accessed from elsewhere, alternatively they can also restrict access so they cannot be accessed, except from within the object itself",
        "The 'PrintStudentInfo()' function is declared as public, meaning that it can also be called from somewhere outside the class, such as the Main()",
        "In order to access an object's functions or variables, you can use the special access (.) operator, which is a full-stop",
        "The code above shows how to access an object's variables/functions, simply declare the object's name followed by a full stop",
        "We can assign the object's variables and call the object's functions from the Main(), but remember that this can only be done because the variables and function are declared public",
        "If the variables were changed to private, like shown above, we could no longer directly access the variables from the Main(), if we tried we would get an error",
        "We would still be able to call the object's 'PrintStudentInfo()', since it is still marked public",
        "It is important to know that in C#, everything must be inside a class. No code can exist outside a class, not even the Main()",
        "The Main() must exist inside a class. You may be wondering how the main can run if it belongs to a class that must be instantiated first",
        "The reason is because of the static modifier, this modifier makes it so that any function/variable that has this keyword does not need to be instantiated",
        "Any function/variable with this modifier will exist at the time the program starts",
        "The static modifer also makes it so that there can only ever be one instance of a variable/function",
        "In the example above, the age variable has been changed to static, this means that any Student objects created will have to share this one variable, instead of each having their own",
        "It is not very practical in this situation, but it can have uses elsewhere",
        "As for static functions, they cannot be called by a class instance, instead they must be called using the class name itself",
        "Instead of saying studentObj.PrintStudentInfo();, you must say Student.PrintStudentInfo();",
        "Classes are reference types, which means that they hold a reference to an object, not the object itself",
        "This means that if you were to create an object named studentObj, and then declared another Student object named studentObj2, if you were to assign studentObj2 to studentObj, they would both be in control of the same object",
        "Because you did not use the new keyword on studentObj2 and instead assigned it to studentObj, they are both share the same object",
        "To give studentObj2 its own object, you will need to use = new Student();",
        "Reference types do not hold data like value types do, they hold the address of the data so when you assign studentObj2 = studentObj; what you are saying is that you want studentObj2 to have the same address as studentObj",
        "Since the address of studentObj is an object instance, both will now point to that object",
        "This is the end of Classes Terminal 2"
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
            if (i == 4) contentText.text = "class Student\n{\npublic int age;\npublic string name;\npublic string university;\npublic string areaOfStudy;\npublic void PrintStudentInfo()\n{\nConsole.WriteLine(name)\nConsole.WriteLine(age);\nConsole.WriteLine(university);\nConsole.WriteLine(areaOfStudy);}\n}";
            if (i == 7) contentText.text = "static void Main()\n{\nStudent studentObj = new Student();\n}";
            if (i == 14) contentText.text = "class Student\n{\npublic int age;\npublic string name;\npublic string university;\npublic string areaOfStudy;\npublic Student(string Name, int Age)\n{\nname = Name;\nage = Age;\n}\n}";
            if (i == 17) contentText.text = "static void Main()\n{\nStudent studentObj = new Student(\"John Smith\", 21);\n}";
            if(i == 18) contentText.text = "class Student\n{\npublic int age;\npublic string name;\npublic string university;\npublic string areaOfStudy;\npublic Student()\n{\nuniversity = \"University of Lincoln\";\n}\n}";
            if (i == 19) contentText.text = "class Student\n{\npublic int age;\npublic string name;\npublic string university;\npublic string areaOfStudy;\npublic void PrintStudentInfo()\n{\nConsole.WriteLine(name);\nConsole.WriteLine(age);\nConsole.WriteLine(university);\nConsole.WriteLine(areaOfStudy);\n}\n}";
            if (i == 23) contentText.text = "static void Main()\n{\nStudent studentObj = new Student();\nstudentObj.name = \"John\";\nstudentObj.age = 22;\nstudentObj.PrintStudentInfo();\n}";
            if (i == 25) contentText.text = "class Student\n{\nprivate int age;\nprivate string name;\nprivate string university;\nprivate string areaOfStudy;\npublic void PrintStudentInfo()\n{\nConsole.WriteLine(name);\nConsole.WriteLine(age);\nConsole.WriteLine(university);\nConsole.WriteLine(areaOfStudy);\n}\n}";
            if (i == 27) contentText.text = "";
            if (i == 28) contentText.text = "class Student\n{\nprivate int age;\nprivate string name;\nprivate string university;\nprivate string areaOfStudy;\nstatic void Main()\n{\n\n}\n}";
            if (i == 32) contentText.text = "class Student\n{\nstatic int age;\nprivate string name;\nprivate string university;\nprivate string areaOfStudy;\nstatic void Main()\n{\n\n}\n}";
            if (i == 36) contentText.text = "";
            if (i == 37) contentText.text = "static void Main()\n{\nStudent studentObj = new Student();\nStudent studentObj2 = studentObj;\n}";
            if (i == 42) contentText.text = "";
            if (i == contextStrings.Length)
                scene.LoadNewScene("labRoom3");
            else
                contextText.text = contextStrings[i];
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (i != 0) i--;
            if (i == 0) contentText.text = "";
            if (i == 4) contentText.text = "class Student\n{\npublic int age;\npublic string name;\npublic string university;\npublic string areaOfStudy;\npublic void PrintStudentInfo()\n{\nConsole.WriteLine(name)\nConsole.WriteLine(age);\nConsole.WriteLine(university);\nConsole.WriteLine(areaOfStudy);}\n}";
            if (i == 7) contentText.text = "static void Main()\n{\nStudent studentObj = new Student();\n}";
            if (i == 14) contentText.text = "class Student\n{\npublic int age;\npublic string name;\npublic string university;\npublic string areaOfStudy;\npublic Student(string Name, int Age)\n{\nname = Name;\nage = Age;\n}\n}";
            if (i == 17) contentText.text = "static void Main()\n{\nStudent studentObj = new Student(\"John Smith\", 21);\n}";
            if (i == 18) contentText.text = "class Student\n{\npublic int age;\npublic string name;\npublic string university;\npublic string areaOfStudy;\npublic Student()\n{\nuniversity = \"University of Lincoln\";\n}\n}";
            if (i == 19) contentText.text = "class Student\n{\npublic int age;\npublic string name;\npublic string university;\npublic string areaOfStudy;\npublic void PrintStudentInfo()\n{\nConsole.WriteLine(name);\nConsole.WriteLine(age);\nConsole.WriteLine(university);\nConsole.WriteLine(areaOfStudy);\n}\n}";
            if (i == 23) contentText.text = "static void Main()\n{\nStudent studentObj = new Student();\nstudentObj.name = \"John\";\nstudentObj.age = 22;\nstudentObj.PrintStudentInfo();\n}";
            if (i == 25) contentText.text = "class Student\n{\nprivate int age;\nprivate string name;\nprivate string university;\nprivate string areaOfStudy;\npublic void PrintStudentInfo()\n{\nConsole.WriteLine(name);\nConsole.WriteLine(age);\nConsole.WriteLine(university);\nConsole.WriteLine(areaOfStudy);\n}\n}";
            if (i == 27) contentText.text = "";
            if (i == 28) contentText.text = "class Student\n{\nprivate int age;\nprivate string name;\nprivate string university;\nprivate string areaOfStudy;\nstatic void Main()\n{\n\n}\n}";
            if (i == 32) contentText.text = "class Student\n{\nstatic int age;\nprivate string name;\nprivate string university;\nprivate string areaOfStudy;\nstatic void Main()\n{\n\n}\n}";
            if (i == 36) contentText.text = "";
            if (i == 37) contentText.text = "static void Main()\n{\nStudent studentObj = new Student();\nStudent studentObj2 = studentObj;\n}";
            if (i == 42) contentText.text = "";
            contextText.text = contextStrings[i];
        }
    }
}

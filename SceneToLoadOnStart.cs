using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneToLoadOnStart : MonoBehaviour
{
    public SceneController scene;
    SerializeClass s;
    // Start is called before the first frame update
    void Start()
    {
        s = new SerializeClass();

        string b = PlayerPrefs.GetString("GameData_0");

        if (b != null)
        {
            s = JsonUtility.FromJson<SerializeClass>(b);

            if (s != null)
            {
                if (s.levelToLoad == 1) scene.LoadNewScene("LabRoom1");
                if (s.levelToLoad == 2) scene.LoadNewScene("LabRoom2");
                if (s.levelToLoad == 3) scene.LoadNewScene("LabRoom3");
                if (s.levelToLoad == 4) scene.LoadNewScene("LabRoom4");
            }
            else
            {
                scene.LoadNewScene("Intro");
            }
        }
    }
}

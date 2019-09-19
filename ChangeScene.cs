using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public int level;
    public string sceneName;
    public string altScene;
    string sceneToLoad;
    SerializeClass s;
    SceneController scene;

    private void Start()
    {
        scene = GameObject.Find("SceneManager").GetComponent<SceneController>();
        if (altScene != "")
        {
            s = new SerializeClass();

            string b = PlayerPrefs.GetString("GameData_0");

            if (b != null)
            {
                s = JsonUtility.FromJson<SerializeClass>(b);

                if(level == 1)
                {
                    if (s.skipIntro34 == false)
                        sceneToLoad = sceneName;
                    if (s.skipIntro34 == true)
                        sceneToLoad = altScene;
                }
                if (level == 2)
                {
                    if (s.skipIntro56 == false)
                        sceneToLoad = sceneName;
                    if (s.skipIntro56 == true)
                        sceneToLoad = altScene;
                }
                if (level == 3)
                {
                    if (s.skipIntro78 == false)
                        sceneToLoad = sceneName;
                    if (s.skipIntro78 == true)
                        sceneToLoad = altScene;
                }
            }
        }
        else
        {
            sceneToLoad = sceneName;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            scene.LoadNewScene(sceneToLoad);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnContact : MonoBehaviour
{
    SerializeClass s;

    public string sceneToLoad;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string b = PlayerPrefs.GetString("GameData_0");

        if (b != null)
        {
            s = JsonUtility.FromJson<SerializeClass>(b);
        }
        s.isRobot = true;
        string json = JsonUtility.ToJson(s);
        PlayerPrefs.SetString("GameData_0", json);
        SceneManager.LoadScene(sceneToLoad);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadNewScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}

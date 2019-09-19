using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntervalScene : MonoBehaviour
{
    public string sceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IntervalTime());
    }

    IEnumerator IntervalTime()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(sceneToLoad);
    }
}

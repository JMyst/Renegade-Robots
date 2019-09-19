using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    public string sceneToLoad;
    public SceneController scene;
    public GameObject textObject;
    Text creditText;

    string[] creditsText = { "A Unity Game by Jozef Mystkowski", "Music by Eric Matyas\nwww.soundimage.org", "The End" };
    // Start is called before the first frame update
    void Start()
    {
        creditText = textObject.GetComponent<Text>();
        StartCoroutine(PlayCredits());
    }

    IEnumerator PlayCredits()
    {
        yield return new WaitForSeconds(3);
        creditText.text = creditsText[0];
        yield return new WaitForSeconds(10);
        creditText.text = creditsText[1];
        yield return new WaitForSeconds(10);
        creditText.text = creditsText[2];
        yield return new WaitForSeconds(10);
        scene.LoadNewScene(sceneToLoad);   
    }
}

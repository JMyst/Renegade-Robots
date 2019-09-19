using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LearnToolTip : MonoBehaviour
{
    public string sceneName;
    SceneController scene;
    SaveScene sceneSaver;
    bool colliding;
    public GameObject msgObject;
    Text msgText;
    public string msg;
    // Start is called before the first frame update
    void Start()
    {
        scene = GameObject.Find("SceneManager").GetComponent<SceneController>();
        sceneSaver = sceneSaver = GameObject.Find("GameSave").GetComponent<SaveScene>();
        msgText = msgObject.GetComponent<Text>();
        colliding = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && colliding)
        {
            sceneSaver.SaveGame();
            scene.LoadNewScene(sceneName);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            msgObject.SetActive(true);
            msgText.text = msg;
            colliding = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            msgObject.SetActive(false);
            colliding = false;
        }
    }
}

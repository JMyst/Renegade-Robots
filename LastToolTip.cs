using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastToolTip : MonoBehaviour
{
    bool colliding;
    public GameObject msgObject;
    Text msgText;
    public string sceneName;
    public string msg;
    SceneController scene;
    SaveScene sceneSaver;

    // Start is called before the first frame update
    void Start()
    {
        scene = GameObject.Find("SceneManager").GetComponent<SceneController>();
        msgText = msgObject.GetComponent<Text>();
        colliding = false;
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && colliding)
        {
            scene.LoadNewScene(sceneName);
        }
    }
}

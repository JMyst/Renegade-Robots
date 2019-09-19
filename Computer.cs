using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Computer : MonoBehaviour
{
    public GameObject textObject;
    Text objectText;

    public string computerInfo;

    void Start()
    {
        objectText = textObject.GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            textObject.SetActive(true);
            objectText.text = computerInfo;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            textObject.SetActive(false);
        }
    }
}

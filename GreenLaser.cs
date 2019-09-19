using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenLaser : MonoBehaviour
{
    Control playerControl;
    Renderer playerRend;
    Animator robotAnim;
    float origSpeedX;
    float origSpeedY;
    // Start is called before the first frame update
    void Start()
    {
        playerControl = GameObject.Find("Robot").GetComponent<Control>();
        playerRend = GameObject.Find("Robot").GetComponent<Renderer>();
        robotAnim = GameObject.Find("Robot").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            origSpeedX = playerControl.xSpeed;
            origSpeedY = playerControl.ySpeed;
            playerControl.xSpeed = 0.0f;
            playerControl.ySpeed = 0.0f;

            playerControl.isFrozen = true;
            playerRend.material.SetColor("_Color", Color.green);
            robotAnim.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerControl.xSpeed = origSpeedX;
            playerControl.ySpeed = origSpeedY;
            playerRend.material.SetColor("_Color", Color.white);

            playerControl.isFrozen = false;
            robotAnim.enabled = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator anim;
    AudioSource audio;
    public AudioClip jump;

    public float xSpeed = 5.0f;
    public float ySpeed = 5.0f;
    public bool isJumping = false, isAirborn = false;

    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * xSpeed * Time.deltaTime);
            anim.SetInteger("State", 4);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * xSpeed * Time.deltaTime);
            anim.SetInteger("State", 5);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            anim.SetInteger("State", 1);
            transform.Translate(Vector3.up * ySpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetInteger("State", 2);
            transform.Translate(Vector3.down * ySpeed * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            anim.SetInteger("State", 3);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            anim.SetInteger("State", 0);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetInteger("State", 6);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anim.SetInteger("State", 7);
        }
    }
}
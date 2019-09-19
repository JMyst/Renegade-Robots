using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator anim;
    AudioSource audio;
    public AudioClip jump;

    public bool isFrozen = false;
    public float xSpeed = 8.0f;
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
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * xSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * ySpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * ySpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Space) && isJumping == false && isFrozen == false)
        {
            anim.SetInteger("State", 1);
            isJumping = true;
            audio.PlayOneShot(jump, 0.7f);
        }
    }
    void StateOriginal()
    {
        anim.SetInteger("State", 0);
    }
    void Grounded()
    {
        isJumping = false;
        isAirborn = false;
    }
    void AirBorn()
    {
        isAirborn = true;
    }
}
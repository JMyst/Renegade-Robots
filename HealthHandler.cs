using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    public float health;
    [SerializeField] private HealthBar healthBar;
    GameObject player;
    Renderer rend;
    public AudioClip hit;
    AudioSource audio;
    bool takingDamage, isRunning, lowHealth;

    // Start is called before the first frame update
    private void Start()
    {
        audio = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        rend = player.GetComponent<Renderer>();
        health = 1.0f;
        takingDamage = false;
        isRunning = false;
        lowHealth = false;
    }
    private void FixedUpdate()
    {
        if (takingDamage == true && isRunning == false)StartCoroutine(PlayerHit());
    }

    IEnumerator PlayerHit()
    {
        isRunning = true;
        rend.material.SetColor("_Color", Color.red);
        yield return new WaitForSeconds(0.05f);
        rend.material.SetColor("_Color", Color.white);
        yield return new WaitForSeconds(0.05f);
        rend.material.SetColor("_Color", Color.red);
        yield return new WaitForSeconds(0.05f);
        rend.material.SetColor("_Color", Color.white);
        takingDamage = false;
        isRunning = false;
    }
    public void Damage(float dmg)
    {
        audio.PlayOneShot(hit, 0.7f);
        health -= dmg;
        if (health < 0)
        {
            health = 0;
        }
        healthBar.SetSize(health);
        takingDamage = true;
        if (health <= 0.5f && health > 0.25f) healthBar.SetColour(Color.yellow);
        if (health <= 0.25f && health > 0.0f) healthBar.SetColour(Color.red);
    }

    public void Damage(float dmg, bool damageBoss)
    {
        audio.PlayOneShot(hit, 0.7f);
        health -= dmg;
        if (health < 0)
        {
            health = 0;
        }
        healthBar.SetSize(health);
        if (health <= 0.5f && health > 0.25f) healthBar.SetColour(Color.yellow);
        if (health <= 0.25f && health > 0.0f) healthBar.SetColour(Color.red);
    }
}

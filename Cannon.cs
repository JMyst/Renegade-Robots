using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    Transform playerTransform;
    GameObject rocket;
    public GameObject rocketPrefab;
    CannonRocket rocketScript;
    Quaternion rotation;
    Animator anim;
    public AudioClip cannonFire;
    AudioSource audio;

    public float shootTime;
    public bool readyToShoot;
    public bool levelEnd;

    // Start is called before the first frame update
    void Start()
    {
        readyToShoot = true;
        anim = GameObject.Find("CannonBarrel").GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        levelEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 relativePos = playerTransform.position - transform.position;
        rotation = Quaternion.LookRotation(Vector3.forward, relativePos);
        rotation.x = transform.rotation.x;
        rotation.y = transform.rotation.y;
        transform.rotation = rotation;
    }

    public IEnumerator ShootRockets()
    {
        while (readyToShoot == true)
        {
                audio.PlayOneShot(cannonFire, 7.0f);
                rocket = Instantiate(rocketPrefab);
                rocketScript = rocket.GetComponent<CannonRocket>();
                Vector3 forwardVector = rotation * Vector3.up;
                rocketScript.SetPosition(transform, forwardVector, playerTransform);
                anim.SetInteger("State", 1);
                yield return new WaitForSeconds(shootTime);
        }
    }
}

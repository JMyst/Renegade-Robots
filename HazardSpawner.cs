using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner : MonoBehaviour
{
    public bool levelEnd;
    int rocketCount;
    bool beamSpawned, isRunning;
    public GameObject beamPrefab;
    public GameObject rocketPrefab;
    public GameObject alertPrefab;

    GameObject beam;
    GameObject rocket;
    GameObject alert;

    EngineEvent engineEvent;
    RocketMovement rocketMovement;
    Alert alertScript;

    AudioSource audio;
    public AudioClip rocketFire;
    public AudioClip alertSound;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        beamSpawned = false;
        isRunning = false;
        engineEvent = GameObject.Find("EngineParent").GetComponent<EngineEvent>();
        rocketCount = 0;
        levelEnd = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!isRunning && !engineEvent.questionEvent)StartCoroutine(SpawnBeam());
        if(beamSpawned && !levelEnd)
        {
            beam.transform.Translate(Vector3.up * 6.0f * Time.deltaTime);
        }
        if (rocketCount < 5 && !engineEvent.questionEvent) StartCoroutine(SpawnRocket());
    }

    IEnumerator SpawnRocket()
    {
        rocketCount++;
        int rocketSpawnTime = Random.Range(1, 10);
        int fromPosition = Random.Range(1, 5);
        float randX = Random.Range(-5.7f, 6.2f);
        float randY = Random.Range(4.5f, -4.6f);
        yield return new WaitForSeconds(rocketSpawnTime);
        if (!engineEvent.questionEvent && !levelEnd)
        {
            alert = Instantiate(alertPrefab);
            alertScript = alert.GetComponent<Alert>();
            audio.PlayOneShot(alertSound, 0.7f);
            if (fromPosition == 1)
            {
                alertScript.SetPosition(randX, 4.48f);
                yield return new WaitForSeconds(1);
                rocket = Instantiate(rocketPrefab);
                rocketMovement = rocket.GetComponent<RocketMovement>();
                rocketMovement.SetPosition(randX, 10.0f, Vector3.down, 90);

            }
            else
            {
                if (fromPosition == 2)
                {
                    alertScript.SetPosition(5.96f, randY);
                    yield return new WaitForSeconds(1);
                    rocket = Instantiate(rocketPrefab);
                    rocketMovement = rocket.GetComponent<RocketMovement>();
                    rocketMovement.SetPosition(10.0f, randY, Vector3.left, 180);
                }
                else
                {
                    if (fromPosition == 3)
                    {
                        alertScript.SetPosition(randX, -4.4f);
                        yield return new WaitForSeconds(1);
                        rocket = Instantiate(rocketPrefab);
                        rocketMovement = rocket.GetComponent<RocketMovement>();
                        rocketMovement.SetPosition(randX, -10.0f, Vector3.up, -90);

                    }
                    else
                    if (fromPosition == 4)
                    {
                        alertScript.SetPosition(-5.48f, randY);
                        yield return new WaitForSeconds(1);
                        rocket = Instantiate(rocketPrefab);
                        rocketMovement = rocket.GetComponent<RocketMovement>();
                        rocketMovement.SetPosition(-12.0f, randY, Vector3.right, 1);
                    }
                }
            }
            yield return new WaitForSeconds(0.25f);
            audio.PlayOneShot(rocketFire, 0.7f);
        }
        rocketCount--;
    }

    IEnumerator SpawnBeam()
    {
        isRunning = true;
        int spawnInterval = Random.Range(1, 10);
        yield return new WaitForSeconds(spawnInterval);
        if (!engineEvent.questionEvent)
        {
            beamSpawned = true;
            beam = Instantiate(beamPrefab);
            beam.transform.position = new Vector3(-5.83f, -10.0f);
            yield return new WaitForSeconds(5.0f);
            GameObject.Destroy(beam);
            beamSpawned = false;
        }
        isRunning = false;
    }
}

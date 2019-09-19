using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner3 : MonoBehaviour
{
    public bool levelEnd;
    int rocketCount;
    bool beamSpawned, isRunning;
    public bool cannonSpawned, spawningCannon, cannonRunning, cannonDespawning;
    public GameObject beamPrefab;
    public GameObject rocketPrefab;
    public GameObject alertPrefab;

    GameObject beam;
    GameObject rocket;
    GameObject alert;
    GameObject cannon;
    Cannon cannonScript;

    EngineEvent3 engineEvent;
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
        cannonSpawned = false;
        isRunning = false;
        cannonRunning = false;
        engineEvent = GameObject.Find("EngineParent").GetComponent<EngineEvent3>();
        cannon = GameObject.Find("Cannon");
        cannonScript = GameObject.Find("PivotPoint").GetComponent<Cannon>();
        rocketCount = 0;
        levelEnd = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isRunning && !engineEvent.questionEvent) StartCoroutine(SpawnBeam());
        if (beamSpawned && !levelEnd)
        {
            beam.transform.Translate(Vector3.up * 6.0f * Time.deltaTime);
        }
        if (spawningCannon)
        {
            cannon.transform.Translate(Vector2.up * 1.0f * Time.deltaTime);
        }
        if (cannonDespawning)
        {
            cannon.transform.Translate(Vector2.up * -1.0f * Time.deltaTime);
        }
        if (engineEvent.questionEvent)
        {
            cannonDespawning = true;
            cannonScript.readyToShoot = false;
        }
        if(levelEnd)
        {
            cannonDespawning = true;
            cannonScript.readyToShoot = false;
        }
        if (rocketCount < 5 && !engineEvent.questionEvent) StartCoroutine(SpawnRocket());
        if (!cannonRunning && !engineEvent.questionEvent) StartCoroutine(SpawnCannon());
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

    IEnumerator SpawnCannon()
    {
        cannonDespawning = false;
        cannon.transform.position = new Vector3(0.2130803f, -3.42f, -0.09179688f);
        cannonRunning = true;
        int spawnInterval = Random.Range(5, 15);
        yield return new WaitForSeconds(spawnInterval);
        spawningCannon = true;
        yield return new WaitForSeconds(3);
        spawningCannon = false;
        yield return new WaitForSeconds(1);
        if (!levelEnd)cannonScript.readyToShoot = true;
        if(!engineEvent.questionEvent) StartCoroutine(cannonScript.ShootRockets());
        yield return new WaitForSeconds(8);
        cannonScript.readyToShoot = false;
        cannonDespawning = true;
        yield return new WaitForSeconds(3);
        cannonDespawning = false;
        cannonRunning = false;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EngineEvent7 : MonoBehaviour
{
    public string sceneToLoad;
    int iteration = 0;

    public float questionTime;
    public bool isLevelEnd;
    public GameObject levelEnd;
    Text levelEndText;
    public Dialogue7 questionScript;

    SceneController scene;
    GameObject childGameObject1;
    GameObject childGameObject2;
    GameObject childGameObject3;
    GameObject questionZones;
    HealthHandler healthBar;
    HealthHandler bossHealthBar;

    Vector3 child1OrigPos;
    Vector3 child2OrigPos;
    Vector3 child3OrigPos;
    AudioSource laser;
    SaveScene sceneSaver;
    HazardSpawner7 hSpawner;

    int deactivatedLaser;

    public bool engineAppearing = false, engineDisappearing = false, isRunning = false, engineRunning = false, questionEvent = false;

    // Start is called before the first frame update

    void Awake()
    {
        childGameObject1 = transform.Find("Laser1").gameObject;
        childGameObject2 = transform.Find("Laser2").gameObject;
        childGameObject3 = transform.Find("Laser3").gameObject;
        questionZones = GameObject.Find("QuestionZones");
        laser = GetComponent<AudioSource>();
        sceneSaver = GameObject.Find("GameSave").GetComponent<SaveScene>();
        hSpawner = GameObject.Find("GameHandler").GetComponent<HazardSpawner7>();
    }

    private void Start()
    {
        levelEndText = levelEnd.GetComponent<Text>();
        isLevelEnd = false;
        healthBar = GameObject.Find("GameHandler").GetComponent<HealthHandler>();
        bossHealthBar = GameObject.Find("BossHandler").GetComponent<HealthHandler>();
        scene = GameObject.Find("SceneManager").GetComponent<SceneController>();
        child1OrigPos = childGameObject1.transform.position;
        child2OrigPos = childGameObject2.transform.position;
        child3OrigPos = childGameObject3.transform.position;
        questionZones.SetActive(false);
    }

    IEnumerator WaitForQuestion()
    {
        if (!isRunning && !isLevelEnd)
        {
            isRunning = true;

            int randomWait = Random.Range(8, 28);
            yield return new WaitForSeconds(randomWait);
            questionEvent = true;
            yield return new WaitForSeconds(2);
            engineAppearing = true;
            yield return new WaitForSeconds(3.0f);
            engineAppearing = false;
            ActivateQuestion();
            yield return new WaitForSeconds(questionTime);
            questionZones.SetActive(false);
            engineRunning = true;
            laser.Play();
            questionScript.StopQuestion();
            yield return new WaitForSeconds(0.3f);
            engineRunning = false;
            yield return new WaitForSeconds(3.0f);
            engineRunning = true;
            yield return new WaitForSeconds(1.0f);
            engineRunning = false;
            childGameObject1.transform.position = child1OrigPos;
            childGameObject2.transform.position = child2OrigPos;
            childGameObject3.transform.position = child3OrigPos;
            yield return new WaitForSeconds(2.0f);
            engineDisappearing = true;
            questionScript.StartDialogue();
            questionEvent = false;
            yield return new WaitForSeconds(3.0f);
            engineDisappearing = false;
            isRunning = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (healthBar.health <= 0.0f) StartCoroutine(GameLoss());
        if (bossHealthBar.health <= 0.0f)
        {
            isRunning = false;
            EndLevel();
        }
        StartCoroutine(WaitForQuestion());
        if (engineAppearing == true)
        {
            transform.Translate(Vector3.down * 0.5f * Time.deltaTime);
        }
        if (engineDisappearing == true)
        {
            transform.Translate(Vector3.up * 0.5f * Time.deltaTime);
        }
        if (engineRunning == true)
        {
            if (deactivatedLaser == 1)
            {
                childGameObject3.transform.Translate(Vector2.down * 35.0f * Time.deltaTime);
                childGameObject2.transform.Translate(Vector2.down * 35.0f * Time.deltaTime);
            }
            else
            {
                if (deactivatedLaser == 2)
                {
                    childGameObject3.transform.Translate(Vector2.down * 35.0f * Time.deltaTime);
                    childGameObject1.transform.Translate(Vector2.down * 35.0f * Time.deltaTime);
                }
                else
                {
                    if (deactivatedLaser == 3)
                    {
                        childGameObject2.transform.Translate(Vector2.down * 35.0f * Time.deltaTime);
                        childGameObject1.transform.Translate(Vector2.down * 35.0f * Time.deltaTime);
                    }
                }
            }
        }
        else
        {
            if (engineRunning == true && deactivatedLaser == 1)
                childGameObject1.transform.Translate(Vector2.down * 35.0f * Time.deltaTime);
        }
    }

    void ActivateQuestion()
    {
        questionScript.StartQuestion();
        questionZones.SetActive(true);
        deactivatedLaser = questionScript.CheckCorrectionField();
    }

    void EndLevel()
    {
        hSpawner.levelEnd = true;
        isLevelEnd = true;
    }

    IEnumerator GameLoss()
    {
        hSpawner.levelEnd = true;
        isLevelEnd = true;
        levelEndText.text = "Gameover";
        yield return new WaitForSeconds(5);

        scene.LoadNewScene(sceneToLoad);
    }
}
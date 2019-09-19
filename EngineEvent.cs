using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EngineEvent : MonoBehaviour
{
    public string sceneToLoad;
    int iteration = 0;

    public float questionTime;
    public int level;
    public int terminal;
    public bool isLevelEnd;
    public GameObject levelEnd;
    Text levelEndText;
    public Dialogue questionScript;

    SceneController scene;
    GameObject childGameObject1;
    GameObject childGameObject2;
    GameObject childGameObject3;
    GameObject questionZones;
    HealthHandler healthBar;

    Vector3 child1OrigPos;
    Vector3 child2OrigPos;
    Vector3 child3OrigPos;
    AudioSource laser;
    Score scoreScript;
    SaveScene sceneSaver;
    HazardSpawner hSpawner;

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
       hSpawner = GameObject.Find("GameHandler").GetComponent<HazardSpawner>();
    }

    private void Start()
    {
        isLevelEnd = false;
        levelEndText = levelEnd.GetComponent<Text>();
        healthBar = GameObject.Find("GameHandler").GetComponent<HealthHandler>();
        scene = GameObject.Find("SceneManager").GetComponent<SceneController>();
        scoreScript = GameObject.Find("Score").GetComponent<Score>();
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
            iteration++;
            if(iteration == 7)
            {
                StartCoroutine(EndLevel());
            }
            else
            isRunning = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (healthBar.health <= 0.0f) StartCoroutine(GameLoss());
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
                if(deactivatedLaser == 2)
                {
                    childGameObject3.transform.Translate(Vector2.down * 35.0f * Time.deltaTime);
                    childGameObject1.transform.Translate(Vector2.down * 35.0f * Time.deltaTime);
                }
                else
                {
                    if(deactivatedLaser == 3)
                    {
                        childGameObject2.transform.Translate(Vector2.down * 35.0f * Time.deltaTime);
                        childGameObject1.transform.Translate(Vector2.down * 35.0f * Time.deltaTime);
                    }
                }
            }
        }
        else
        {
            if(engineRunning == true && deactivatedLaser == 1)
            childGameObject1.transform.Translate(Vector2.down * 35.0f * Time.deltaTime);
        }
    }

    void ActivateQuestion()
    {
        questionScript.StartQuestion();
        questionZones.SetActive(true);
        deactivatedLaser = questionScript.CheckCorrectionField();
    }

    IEnumerator EndLevel()
    {
        hSpawner.levelEnd = true;
        isLevelEnd = true;
        levelEndText.text = "Level finished!";
        yield return new WaitForSeconds(3);
        int healthBonus = (int)(healthBar.health * 1000.0f);
        scoreScript.SetScore(healthBonus);
        levelEndText.text = "Health remaining bonus: +" + healthBonus.ToString();
        yield return new WaitForSeconds(5);
        levelEndText.text = "Final Score: " + scoreScript.score.ToString();
        yield return new WaitForSeconds(3);
        if (scoreScript.score < 2000)
        {
            levelEndText.text = "You missed out on a medal!";
        }
        if (scoreScript.score >= 2000 && scoreScript.score < 3000)
        {
            levelEndText.text = "You achieved the bronze medal!";
            int badgeCount = sceneSaver.GetBadgeCount(1);
            if (badgeCount < 1)
                sceneSaver.SaveBadges(level, terminal, 1);
        }
        if (scoreScript.score >= 3000 && scoreScript.score < 4000)
        {
            levelEndText.text = "You achieved the silver medal!";
            int badgeCount = sceneSaver.GetBadgeCount(1);
            if (badgeCount < 2)
                sceneSaver.SaveBadges(level, terminal, 2);
        }
        if (scoreScript.score >= 4000)
        {
            levelEndText.text = "You achieved the gold medal!";
            int badgeCount = sceneSaver.GetBadgeCount(1);
            if (badgeCount < 3)
                sceneSaver.SaveBadges(level, terminal, 3);
        }
        yield return new WaitForSeconds(5);
        scene.LoadNewScene(sceneToLoad);
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
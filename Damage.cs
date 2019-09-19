using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private HealthHandler healthScript;
    private EngineEvent engineScript;
    private Control control;
    private Dialogue dialogueScript;
    public float dmg;
    // Start is called before the first frame update
    void Start()
    {
        healthScript = GameObject.FindGameObjectWithTag("GameHandler").GetComponent<HealthHandler>();
        control = GameObject.FindGameObjectWithTag("Player").GetComponent<Control>();
        engineScript = GameObject.Find("EngineParent").GetComponent<EngineEvent>();
        dialogueScript = GameObject.Find("QuestionHandler").GetComponent<Dialogue>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && !engineScript.isLevelEnd)
        {
            healthScript.Damage(dmg);
            if(engineScript.questionEvent)
            {
                dialogueScript.responseType = false;
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserHazard : MonoBehaviour
{
    private HealthHandler healthScript;
    private Control control;
    EngineEvent engineScript;

    public float dmg;
    // Start is called before the first frame update
    void Start()
    {
        engineScript = GameObject.Find("EngineParent").GetComponent<EngineEvent>();
        healthScript = GameObject.FindGameObjectWithTag("GameHandler").GetComponent<HealthHandler>();
        control = GameObject.FindGameObjectWithTag("Player").GetComponent<Control>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && !control.isAirborn && !engineScript.isLevelEnd)
        {
            healthScript.Damage(dmg);
        }
    }
}
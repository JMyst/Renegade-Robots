using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneEngine : MonoBehaviour
{
    public GameObject lasers;
    bool engineAppearing = false, lasersActive = false;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (engineAppearing == true)
        transform.Translate(Vector3.down * 1.0f * Time.deltaTime);
        if (lasersActive == true)
        lasers.transform.Translate(Vector3.down * 35.0f * Time.deltaTime);
    }

    public void TriggerEngines()
    {
        engineAppearing = true;
    }
    public void StopEngines()
    {
        engineAppearing = false;
    }

    public void ActivateLasers()
    {
        lasersActive = true;
    }
}

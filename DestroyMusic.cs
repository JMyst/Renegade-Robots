using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMusic : MonoBehaviour
{
    public string musicToDestroy;
    GameObject destroyLoad;
    // Start is called before the first frame update
    void Start()
    {
        destroyLoad = GameObject.Find(musicToDestroy);
        GameObject.Destroy(destroyLoad);
    }
}

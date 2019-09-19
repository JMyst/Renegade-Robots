using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAnim : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void StopFiring()
    {
        anim.SetInteger("State", 0);
    }
}

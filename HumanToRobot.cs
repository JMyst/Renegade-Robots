using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanToRobot : MonoBehaviour
{
    public RuntimeAnimatorController robotAnim;
    SpriteRenderer rend;
    Animator anim;
    SerializeClass s;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        GetHumanOrRobot();
    }
    void GetHumanOrRobot()
    {
        string b = PlayerPrefs.GetString("GameData_0");
        if (b != null)
        {
            s = JsonUtility.FromJson<SerializeClass>(b);
        }
        if(s.isRobot == true)
        {
            anim.runtimeAnimatorController = robotAnim as RuntimeAnimatorController;
        }
    }
}

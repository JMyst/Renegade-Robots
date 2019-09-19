using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipIntros : MonoBehaviour
{
    public int level;
    SerializeClass s;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        s = new SerializeClass();
        if (player != null)
        {
            string p = PlayerPrefs.GetString("GameData_0");
            if (p != null && p.Length > 0 && player != null)
            {
                s = JsonUtility.FromJson<SerializeClass>(p);

                if(level == 2)
                    s.skipIntro34 = true;
                if (level == 3)
                    s.skipIntro56 = true;
                if (level == 4)
                    s.skipIntro78 = true;

                string json = JsonUtility.ToJson(s);
                PlayerPrefs.SetString("GameData_0", json);
            }

        }
    }
}

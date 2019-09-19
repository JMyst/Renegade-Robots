using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScene : MonoBehaviour
{
    public int labRoomOnLoad;
    public int levelToLoad;
    public int badge1Requirement, badge2Requirement;

    public GameObject player;
    public GameObject badges1;
    public GameObject badges2;
    public GameObject lockDoor;

    Badges script1;
    Badges script2;

    SerializeClass s;

    // Start is called before the first frame update
    void Start()
    {
        s = new SerializeClass();
        if (player != null) // && badges1 != null && badges2 != null)
            RestoreGame();
        else
        {
            LoadBadges();
        }
    }

    public void LoadBadges()
    {
        string b = PlayerPrefs.GetString("GameData_0");

        if(b != null)
        {
            s = JsonUtility.FromJson<SerializeClass>(b);
        }
    }

    public int GetBadgeCount(int terminal)
    {
        switch(terminal)
        {
            case 1:
                if (s.badges1_1 == 3)
                    return 3;
                if (s.badges1_1 == 2)
                    return 2;
                if (s.badges1_1 == 1)
                    return 1;
                break;
            case 2:
                if (s.badges1_2 == 3)
                    return 3;
                if (s.badges1_2 == 2)
                    return 2;
                if (s.badges1_2 == 1)
                    return 1;
                break;
            case 3:
                if (s.badges2_1 == 3)
                    return 3;
                if (s.badges2_1 == 2)
                    return 2;
                if (s.badges2_1 == 1)
                    return 1;
                break;
            case 4:
                if (s.badges2_2 == 3)
                    return 3;
                if (s.badges2_2 == 2)
                    return 2;
                if (s.badges2_2 == 1)
                    return 1;
                break;
            case 5:
                if (s.badges3_1 == 3)
                    return 3;
                if (s.badges3_1 == 2)
                    return 2;
                if (s.badges3_1 == 1)
                    return 1;
                break;
            case 6:
                if (s.badges3_2 == 3)
                    return 3;
                if (s.badges3_2 == 2)
                    return 2;
                if (s.badges3_2 == 1)
                    return 1;
                break;
            default:
                break;
        }
        return 0;
    }

    void RestoreGame()
    {
        string p = PlayerPrefs.GetString("GameData_0");
        if (p != null && p.Length > 0 && player != null)
        {
            s = JsonUtility.FromJson<SerializeClass>(p);
            if (s != null)
            {
                Vector3 position = new Vector3();
                if (levelToLoad == 1)
                {
                    position.x = s.x;
                    position.y = s.y;
                    position.z = s.z;
                }
                if (levelToLoad == 2)
                {
                    position.x = s.x2;
                    position.y = s.y2;
                    position.z = s.z2;
                }
                if (levelToLoad == 3)
                {
                    position.x = s.x3;
                    position.y = s.y3;
                    position.z = s.z3;
                }
                if (levelToLoad == 4)
                {
                    //position.x = s.x4;
                    //position.y = s.y4;
                    //position.z = s.z4;
                    position.x = 43.51358f;
                    position.y = -31.35163f;
                    position.z = 12.8632f;
                }

                player.transform.position = position;
            }
        }
        if (p != null && p.Length > 0 && badges1 != null && badges2 != null)
        {
            if (s != null)
            {
                script1 = badges1.GetComponent<Badges>();
                script2 = badges2.GetComponent<Badges>();

                if (levelToLoad == 1)
                {
                    script1.SetBadges(s.badges1_1);
                    script2.SetBadges(s.badges1_2);
                }
                if(levelToLoad == 2)
                {
                    script1.SetBadges(s.badges2_1);
                    script2.SetBadges(s.badges2_2);
                }
                if (levelToLoad == 3)
                {
                    script1.SetBadges(s.badges3_1);
                    script2.SetBadges(s.badges3_2);
                }

                if (script1.badgeNumber >= badge1Requirement && script2.badgeNumber >= badge2Requirement)
                {
                    LockDoor openDoor = lockDoor.GetComponent<LockDoor>();
                    openDoor.Unlock();
                }
            }
        }
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.S))
    //    {
    //        SaveGame();
    //        SaveBadges(1, 1, 0);
    //        SaveBadges(1, 2, 0);
    //        SaveBadges(2, 1, 0);
    //        SaveBadges(2, 2, 0);
    //        SaveBadges(3, 1, 0);
    //        SaveBadges(3, 2, 0);
    //        RobotToHuman();
    //        ResetCutScenes();
    //    }
    //}

    public void SaveGame()
    {
        if (levelToLoad == 1)
        {
            s.x = player.transform.position.x;
            s.y = player.transform.position.y;
            s.z = player.transform.position.z;
        }
        if (levelToLoad == 2)
        {
            s.x2 = player.transform.position.x;
            s.y2 = player.transform.position.y;
            s.z2 = player.transform.position.z;
        }
        if (levelToLoad == 3)
        {
            s.x3 = player.transform.position.x;
            s.y3 = player.transform.position.y;
            s.z3 = player.transform.position.z;
        }
        if (levelToLoad == 4)
        {
            s.x4 = player.transform.position.x;
            s.y4 = player.transform.position.y;
            s.z4 = player.transform.position.z;
        }

        string json = JsonUtility.ToJson(s);
        Debug.Log(json);

        PlayerPrefs.SetString("GameData_0", json);
    }

    public void SaveBadges(int level, int terminal, int badgeCount)
    {
        if(level == 1)
        {
            if (terminal == 1)
                s.badges1_1 = badgeCount;
            if (terminal == 2)
                s.badges1_2 = badgeCount;
        }
        if (level == 2)
        {
            if (terminal == 1)
                s.badges2_1 = badgeCount;
            if (terminal == 2)
                s.badges2_2 = badgeCount;
        }
        if (level == 3)
        {
            if (terminal == 1)
                s.badges3_1 = badgeCount;
            if (terminal == 2)
                s.badges3_2 = badgeCount;
        }
        string json = JsonUtility.ToJson(s);
        PlayerPrefs.SetString("GameData_0", json);
    }

    private void RobotToHuman()
    {
        s.isRobot = false;
    }

    private void ResetCutScenes()
    {
        s.skipIntro34 = false;
        s.skipIntro56 = false;
        s.skipIntro78 = false;
    }

    private void SaveLevel()
    {
        s.levelToLoad = labRoomOnLoad;
    }

    private void OnApplicationQuit()
    {
        if (player != null)
        {
            SaveLevel();
            SaveGame();
        }
    }
}

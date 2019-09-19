using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Badges : MonoBehaviour
{
    public int badgeNumber;
    public Sprite[] badges;
    SpriteRenderer rend;

    private void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
    }
    public void SetBadges(int badgeCount)
    {
        rend.sprite = badges[badgeCount];
        badgeNumber = badgeCount;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDoor : MonoBehaviour
{
    SpriteRenderer rend;
    BoxCollider2D collider;
    public Sprite openSprite;

    // Start is called before the first frame update
    private void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }

    public void Unlock()
    {
        rend.sprite = openSprite;
        collider.isTrigger = true;
    }
}

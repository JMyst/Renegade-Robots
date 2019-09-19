using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alert : MonoBehaviour
{
    public void SetPosition(float x, float y)
    {
        transform.position = new Vector3(x, y);
        StartCoroutine(Lifespan());
    }

    IEnumerator Lifespan()
    {
        yield return new WaitForSeconds(1);
        GameObject.Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    Vector3 direction;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * 12.0f * Time.deltaTime, Space.World);
    }
    public void SetPosition(float x, float y, Vector3 movementDirection, int rotation)
    {
        transform.position = new Vector3(x, y);
        direction = movementDirection;
        transform.Rotate(Vector3.back * rotation);
        StartCoroutine(Lifespan());
    }

    IEnumerator Lifespan()
    {
        yield return new WaitForSeconds(5);
        GameObject.Destroy(gameObject);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRocket : MonoBehaviour
{
    Vector3 direction;
    Quaternion rotation;
    // Update is called once per frame

    void Update()
    {
        transform.Translate(Vector3.right * 6.0f * Time.deltaTime);
    }
    public void SetPosition(Transform cannonPos, Vector3 cannonDirection, Transform playerTransform)
    {
        transform.position = cannonPos.position;
        //direction = cannonDirection;
        Vector3 relativePos = playerTransform.position - transform.position;
        rotation = Quaternion.LookRotation(Vector3.forward, relativePos);
        rotation.x = transform.rotation.x;
        rotation.y = transform.rotation.y;
        transform.rotation = rotation;
        transform.Rotate(new Vector3(0.0f, 0.0f, 90.0f));
        StartCoroutine(Lifespan());
    }

    IEnumerator Lifespan()
    {
        yield return new WaitForSeconds(5);
        GameObject.Destroy(gameObject);
    }

}

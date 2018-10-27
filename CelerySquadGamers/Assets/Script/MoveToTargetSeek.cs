using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTargetSeek : MonoBehaviour
{

    GameObject targetObj;
    float time = 0;
    Rigidbody2D rb;
    Transform objectTransform;
    public float force;

    bool startSeekCheck = false;
    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        if (startSeekCheck && rb.velocity.magnitude < 60)
        {
            time = Time.deltaTime;
            Vector2 target = targetObj.transform.position - objectTransform.position;

            float distance = target.magnitude;
            target.Normalize();

            if (distance < 2)
            {

                rb.AddForce(target * force / 6);
            }
            else
            {
                rb.AddForce(target * force / 4);
            }

        }
    }

    public void startSeek(Vector2 origin, GameObject newTarget)
    {
        objectTransform = gameObject.transform;
        rb = gameObject.GetComponent<Rigidbody2D>();

        targetObj = newTarget;
        startSeekCheck = true;
        Debug.Log(origin);
        Vector2 target = objectTransform.position - (Vector3)origin;
        rb.AddForce(target * force * 35);
    }
}

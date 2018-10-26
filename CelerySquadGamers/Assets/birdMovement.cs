using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdMovement : MonoBehaviour {

    // Use this for initialization
    Transform birdTransform;
    Rigidbody2D birdPhysics;
    public float horitzontalSpeed;
    public float verticalUpSpeed;

	void Start () {
        birdPhysics = gameObject.GetComponent<Rigidbody2D>();
        birdTransform = gameObject.transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

	}

    public void birdTurn(bool right)
    {
        float newHspeed;
        if(right)
        {
            newHspeed = horitzontalSpeed;
        }
        else
        {
            newHspeed = -horitzontalSpeed;
        }

        birdTransform.position = new Vector3(birdTransform.position.x + newHspeed, birdTransform.position.y, 0);
    }

    public void birdUp()
    {
        birdPhysics.velocity *= 0;
        birdPhysics.AddForce(verticalUpSpeed * birdTransform.up);
    }
}

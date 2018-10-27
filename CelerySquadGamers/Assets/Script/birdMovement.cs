using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class birdMovement : MonoBehaviour {

    // Use this for initialization
    Transform birdTransform;
    Rigidbody2D birdPhysics;
    public float horitzontalSpeed;
    public float verticalUpSpeed;
    Animator anim;

    private bool canFlap = true;

	void Start () 
    {
        birdPhysics = gameObject.GetComponent<Rigidbody2D>();
        birdTransform = gameObject.transform;
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {

	}

    public void flipGuard()
    {
        anim.SetBool("guarding", !anim.GetBool("guarding"));
    }

    //should only be called by animator------------
    public void setInvince()
    {
        anim.SetBool("invincible", !anim.GetBool("invincible"));
    }
    public void allowFlap()
    {
        canFlap = true;
    }
    //----------------------------------------------

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
        if (canFlap == true)
        {
            canFlap = false;
            Debug.Log("FLAP");
            birdPhysics.velocity *= 0;
            birdPhysics.AddForce(new Vector2(0, verticalUpSpeed), ForceMode2D.Impulse); //verticalUpSpeed * birdTransform.up
        } 
    }
}

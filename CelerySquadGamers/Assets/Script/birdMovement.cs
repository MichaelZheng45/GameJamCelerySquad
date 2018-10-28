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
    PlayerStats birdStats;

	void Start () 
    {
        birdStats = GetComponent<PlayerStats>();
        birdPhysics = gameObject.GetComponent<Rigidbody2D>();
        birdTransform = gameObject.transform;
        anim = GetComponent<Animator>();
        GameManagement.StartGracePeriod();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {

	}

    public void setGuard(bool newGuard)
    {
        anim.SetBool("guarding", newGuard);
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
            newHspeed = birdTransform.position.x + horitzontalSpeed;
            if(newHspeed > 2.4)
            {
                newHspeed = 2.4f;
            }
        }
        else
        {
            newHspeed = birdTransform.position.x - horitzontalSpeed;
            if(newHspeed < -2.4)
            {
                newHspeed = -2.4f;
            }
        }

        birdTransform.position = new Vector3(newHspeed, birdTransform.position.y, 0);
    }

    public void birdUp()
    {
        if (canFlap == true && birdStats.checkDead() != true)
        {
            SoundManage.playAudioClip(CLIP_ENUM.FLAP);
            canFlap = false;
            Debug.Log("FLAP");
            birdPhysics.velocity *= 0;
            birdPhysics.AddForce(new Vector2(0, verticalUpSpeed), ForceMode2D.Impulse); //verticalUpSpeed * birdTransform.up
        } 
    }

    public void Reset()
	{
        birdPhysics.velocity = new Vector2(0,0);
		transform.position = new Vector2(0,-3);
        canFlap = true;
        anim.SetBool("guarding", false);
        anim.SetBool("invincible", true);
        anim.Rebind();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {

	public GameObject bird;
	public int buffferZone = 0;
	private Rigidbody2D rb, birdRb;
	private bool canFollow = false;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();

		if (bird == null)
		{
			Debug.Log("CAMERA NEED BIRD");
		}
		else
		{
			birdRb = bird.GetComponent<Rigidbody2D>();
		}
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (birdRb.velocity.y > 0 && canFollow)
		{
			rb.velocity = birdRb.velocity;
			rb.gravityScale = birdRb.gravityScale;
		}
		else
		{
			rb.velocity = new Vector2(0,0);
			rb.gravityScale = 0;
		}
    }

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Bird")
		{
			canFollow = true;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag == "Bird")
		{
			canFollow = false;
		}
	}
}

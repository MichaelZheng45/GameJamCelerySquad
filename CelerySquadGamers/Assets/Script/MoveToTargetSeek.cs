using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTargetSeek : MonoBehaviour {

    GameObject target;
    float time = 0;
    Rigidbody2D rb;

    public float force;
	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
        Vector2 target = target.transform.position - 

	}

    void startSeek(GameObject newTarget)
    {
        target = newTarget;
    }
}

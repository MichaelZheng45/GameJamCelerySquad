using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class indicatorScript : MonoBehaviour {


    Transform cameraTrans;
    Transform userTransform;
	// Use this for initialization
	void Start () {
        userTransform = gameObject.transform;
        cameraTrans = GameObject.FindGameObjectWithTag("MainCamera").transform;
	}
	
	// Update is called once per frame
	void Update () {
        userTransform.position = new Vector2(userTransform.position.x, cameraTrans.position.y + 2f);
	}
}

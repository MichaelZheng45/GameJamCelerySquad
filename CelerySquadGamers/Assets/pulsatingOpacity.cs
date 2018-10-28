using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pulsatingOpacity : MonoBehaviour {

    SpriteRenderer objRenderer;
	// Use this for initialization
	void Start () {
        objRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        float newA = .1f * Mathf.Sin(Time.time * 2) + .15f;
        objRenderer.color = new Color(1, 1, 1, newA);
	}
}

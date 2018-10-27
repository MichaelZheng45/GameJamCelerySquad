using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camChake : MonoBehaviour {


    bool startShake = false;
    float timer = 0;
    float duration = .6f;

    Transform camTransform;
	// Use this for initialization
	void Start () {
        camTransform = gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
        // Vector3 newPos = camTransform.position; //zero is temp
        Vector3 newPos = new Vector3(0, 0, -10);
        //camera follow

        if (startShake)
        {
            timer += Time.deltaTime;

            float xValue = Random.Range(-.2f, .3f);

            newPos = new Vector3(newPos.x + xValue,newPos.y,-10);
            if(timer > duration)
            {
                startShake = false;
            }
        }

        camTransform.position = newPos;
	}

    public void CameraShake()
    {
        startShake = true;
        timer = 0;
    }
}

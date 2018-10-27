using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputHandler : MonoBehaviour {

    public GameObject bird;
    birdMovement birdMoveComp;
	// Use this for initialization
	void Start () {
        birdMoveComp = bird.GetComponent<birdMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        handleInput();
	}

    void handleInput()
    {
        if(Input.GetKeyUp(KeyCode.Space)) //arms up, guard up
        {
            birdMoveComp.birdUp();
            birdMoveComp.setGuard(false);
        }
        if(Input.GetKeyDown(KeyCode.Space)) //arms down, guard down
        {
            birdMoveComp.setGuard(true);
        }
        else if(Input.GetKey(KeyCode.Space)) //defend
        {
           
        }

        if(Input.GetKey(KeyCode.A)) //go left
        {
            birdMoveComp.birdTurn(false);
        }

        if(Input.GetKey(KeyCode.D)) //go right
        {
            birdMoveComp.birdTurn(true);
        }
    }
}

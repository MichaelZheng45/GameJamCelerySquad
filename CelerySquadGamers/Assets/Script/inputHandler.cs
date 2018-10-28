using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputHandler : MonoBehaviour {

    public GameObject bird;
    birdMovement birdMoveComp;

    private bool canMoveBird = false;

	// Use this for initialization
	void Start () 
    {
        birdMoveComp = bird.GetComponent<birdMovement>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        handleInput();
	}

    void handleInput()
    {
        if(Input.GetKeyUp(KeyCode.Space)) //arms up, guard up
        {
            if (!canMoveBird)
            {
                GameManagement.EndGracePeriod();

                birdMoveComp.birdUp();
                birdMoveComp.setGuard(false);
            }
            else if (canMoveBird)
            {
                birdMoveComp.birdUp();
                birdMoveComp.setGuard(false);
            }
        }
        if(Input.GetKeyDown(KeyCode.Space)) //arms down, guard down
        {
            if (canMoveBird)
            {
                birdMoveComp.setGuard(true);
            }
            
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

    public void setMoveBird(bool permission)
    {
        canMoveBird = permission;
    }
}

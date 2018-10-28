using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //destroy objects or create obj bool;
        if(collision.tag == "Bird")
        {
            Debug.Log("GIVE ME FREEDOM OR GIVE ME DEATH");
        }
    }
}

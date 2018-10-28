using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roostCheckPoint : MonoBehaviour {

    public Canvas roostMenu;
    public GameObject despawner;
    private Despawner despawnScr;

	// Use this for initialization
	void Start () 
    {
		roostMenu.enabled = false;
        despawnScr = despawner.GetComponent<Despawner>();
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bird")
        {
            Debug.Log("Roost");
            Time.timeScale = 0;
            roostMenu.enabled = true;
            despawnScr.deleteAllActive();
        }
    }

    public void RoostButtonClick()
    {
        Debug.Log("CLOSE THE ROOST");
        roostMenu.enabled = false;
        Time.timeScale = 1;
    }
}

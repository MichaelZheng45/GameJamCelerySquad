using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public List<float> currency;

    float totalHealth;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float newHealth = 0;
        for(int i = 0; i < currency.Count; i++)
        {
            newHealth += currency[i];
        }
        totalHealth = newHealth;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject temp = collision.gameObject;
        if(temp.tag == "PartsCollect")
        {
            //add points to curreny based on value from obj
        }
        else if(temp.tag == "Obstacle")
        {
            //remove points based on value from obj
        }
    }
}

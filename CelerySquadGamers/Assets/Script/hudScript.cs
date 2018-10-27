using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hudScript : MonoBehaviour {

    public Text junkCountText;
    public GameObject birdPlayer;
    PlayerStats thePlayerStats;

    void Start()
    {
        thePlayerStats = birdPlayer.GetComponent<PlayerStats>();
    }

	public void UpdateJunkCounter()
    {
        junkCountText.text = thePlayerStats.partsCount.ToString();
    }

}

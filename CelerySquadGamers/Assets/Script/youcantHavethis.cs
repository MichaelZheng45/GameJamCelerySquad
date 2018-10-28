using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class youcantHavethis : MonoBehaviour {

    public TextMeshProUGUI playerPartsText;

    public float timeCount = 0;
    public bool startSayNo = false;
    float duration = 3;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(startSayNo)
        { 
            timeCount += .1f;
            Color red = playerPartsText.color;
            float newA = .4f * Mathf.Sin(timeCount * 4) + .5f;
            playerPartsText.color = new Color(red.r, red.g, red.b, newA);

            if (timeCount > duration)
            {
                startSayNo = false;
                playerPartsText.enabled = false;
            }
        }
    }

    public void sayNo()
    {
        playerPartsText.enabled = true;
        startSayNo = true;
        timeCount = 0;
    }
}

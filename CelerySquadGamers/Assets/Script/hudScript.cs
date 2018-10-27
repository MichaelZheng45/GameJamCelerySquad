using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hudScript : MonoBehaviour {

    public Text junkCountText;
 

	public void UpdateJunkCounter(float partsCount)
    {
        junkCountText.text = partsCount.ToString();
    }

}

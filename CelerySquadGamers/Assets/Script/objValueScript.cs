using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class objValueScript : MonoBehaviour{
    public objectdataValue objectVal;
    
    private void Start()
    {
        gameObject.tag = objectVal.tag;
        gameObject.name = objectVal.name;
        gameObject.GetComponent<SpriteRenderer>().sprite = objectVal.objectSprite;
    }

    public float returnValue()
    {
        return objectVal.value;
    }

    public void destroyObj(GameObject target)
    {

    }
}

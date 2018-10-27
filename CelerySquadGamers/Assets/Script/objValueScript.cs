using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class objValueScript : MonoBehaviour{
    public objectdataValue objectVal;
    public ParticleSystem junkParticle;
    GameObject junkEmitter;

    private void Start()
    {
        gameObject.tag = objectVal.tag;
        gameObject.name = objectVal.name;

        junkEmitter = GameObject.FindGameObjectWithTag("junkEmitter");
        junkParticle = junkEmitter.GetComponent<ParticleSystem>();

    }

    public float returnValue()
    {
        return objectVal.value;
    }

    public void destroyObj(GameObject target)
    {

        Transform unitTransform = gameObject.transform;
        junkEmitter.GetComponent<testParticle>().setPos(transform.position + new Vector3(0,1,0));
        junkParticle.Emit(5);
        Destroy(gameObject);
    }
}

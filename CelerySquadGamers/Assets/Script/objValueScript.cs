using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class objValueScript : MonoBehaviour{
    public objectdataValue objectVal;
    public ParticleSystem junkParticle;
    GameObject junkEmitter;

    public GameObject spawnParts;
    public int partCount;
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

        for(int i = 0; i < partCount; i++)
        {
            float newX = Random.Range(-.2f, .2f);
            Vector3 newPos = new Vector3(unitTransform.position.x + newX,unitTransform.position.y + .5f,0 );

            //GameObject newObject = Instantiate(spawnParts, newPos, unitTransform.rotation) as GameObject;
            //newObject.GetComponent<MoveToTargetSeek>().startSeek(unitTransform.position,target);
        }
        Destroy(gameObject);
    }
}

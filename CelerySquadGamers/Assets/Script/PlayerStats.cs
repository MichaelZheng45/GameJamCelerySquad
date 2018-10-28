using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using TMPro;
public class PlayerStats : MonoBehaviour {

    public float partsCount;
    public int hitlayer = 8;

    private Animator anim;
    public GameObject hitParticleSys;
    ParticleSystem birdParticle;
    public hudScript thehudscript;

    public GameObject cameraMain;

    bool isDead = false;
    public TextMeshProUGUI playerPartsText;
    // Use this for initialization
    void Start () 
    {
        birdParticle = hitParticleSys.GetComponent<ParticleSystem>();

        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        playerPartsText.text = "Count: " + partsCount;
        if(partsCount <= 0)
        {
            if (isDead == false)
            {
                var main = birdParticle.main;
                main.loop = true;
                birdParticle.Play();
                isDead = true;
            }
           
            cameraMain.GetComponent<camChake>().CameraShake();
        }
	}

    public bool checkDead()
    {
        return isDead;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject temp = collision.gameObject;
        objValueScript tempObjScript = temp.GetComponent<objValueScript>();
        if (temp.layer == hitlayer)
        {
            //add points to curreny based on value from obj or remove points based on value from obj
            if ( temp.tag == "Obstacle" && anim.GetBool("invincible"))
            {
                //ignore the damage taken and destroy the obstacle and add some JUICINESSS
                //later on give that so it absorb parts animation or lookness
                tempObjScript.destroyObj(gameObject);
            }
            else
            {
                float rValue = tempObjScript.returnValue();

                if(rValue < 0)
                {
                    birdParticle.Play();
                    cameraMain.GetComponent<camChake>().CameraShake();
                }

                partsCount += rValue;
                //thehudscript.UpdateJunkCounter(partsCount); NO HUD YET

                Destroy(temp);
            }

        }
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("HOLY SH*T, IVE BEEN SHOT");
        partsCount += 2;
    }
}

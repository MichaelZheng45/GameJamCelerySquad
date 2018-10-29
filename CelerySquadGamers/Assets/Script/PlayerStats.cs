using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using TMPro;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour {

    public float partsCount;
    public int hitlayer = 8;

    private Animator anim;
    public GameObject hitParticleSys;
    ParticleSystem birdParticle;
    public ParticleSystem featherParts;

    public GameObject cameraMain;

    public GameObject despawner;
    private Despawner despawnScr;

    bool isDead = false;
    public TextMeshProUGUI playerPartsText;
    public TextMeshProUGUI roostPlayerPartsText;
    public youcantHavethis sayNoer;
    //powerups
    public int helmetDmgReducer;
    public int trampolinePush;
    public bool helmetOn = false;
    public bool trampolineOn = true;
    public Image helmetObj;
    public Image trampoline;
    public int helmetCost;
    public int trampolineCost;

    Transform userTransform;
    Transform cameraTransform;
    Rigidbody2D rb;


    // Use this for initialization
    void Start () 
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        userTransform = gameObject.transform;
        cameraTransform = cameraMain.transform;
        birdParticle = hitParticleSys.GetComponent<ParticleSystem>();

        anim = GetComponent<Animator>();
        despawnScr = despawner.GetComponent<Despawner>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        playerPartsText.text = "Count: " + partsCount;
        roostPlayerPartsText.text = "Count: " + partsCount;
        if (partsCount <= 0)
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

        //powerups
        trampoline.enabled = trampolineOn;
        helmetObj.enabled = helmetOn;

        if(trampolineOn && userTransform.position.y < cameraMain.transform.position.y - 5 && partsCount > 0)
        {
            rb.velocity *= 0;
            rb.AddForce(trampolinePush * new Vector2(0, 1));
            trampolineOn = false;
            SoundManage.playAudioClip(CLIP_ENUM.FLAP);
        }

    }

    public bool checkDead()
    {
        return isDead;
    }

    public void buyTrampoline()
    {
        if(trampolineOn || partsCount - trampolineCost <= 0)
        {
            //send error that you cant buy
            sayNoer.sayNo();
        }
        else
        {
            trampolineOn = true;
            partsCount -= trampolineCost;
        }
    }

    public void buyHelmet()
    {
        if(helmetOn || partsCount - helmetCost <= 0)
        {
            //send error that you cant buy
            sayNoer.sayNo();
        }
        else
        {
            helmetOn = true;
            partsCount -=helmetCost;
        }
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
                despawnScr.removeFromActive(temp);
                tempObjScript.destroyObj(gameObject);
                SoundManage.playAudioClip(CLIP_ENUM.BLOCK);
            }
            else
            {
                float rValue = tempObjScript.returnValue();

                if(rValue < 0)
                {
                    if(helmetOn)
                    {
                        rValue -= (-helmetDmgReducer); //reduce dmg by 2
                        SoundManage.playAudioClip(CLIP_ENUM.HARDHAT);
                    }
                    else
                    {
                        SoundManage.playAudioClip(CLIP_ENUM.DESTROY);
                    }
                    birdParticle.Play();
                    cameraMain.GetComponent<camChake>().CameraShake();
                }
                else
                {
                    SoundManage.playAudioClip(CLIP_ENUM.COLLECT);
                }
                partsCount += rValue;
                //thehudscript.UpdateJunkCounter(partsCount); NO HUD YET
                if(temp.tag != "Metro")
                {
                    despawnScr.removeFromActive(temp);
                    Destroy(temp);
                }
                else
                {
                    featherParts.Play();
                    SoundManage.playAudioClip(CLIP_ENUM.METROHIT);
                }
            }

        }
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("HOLY SH*T, IVE BEEN SHOT");
        partsCount += 1;
    }
}

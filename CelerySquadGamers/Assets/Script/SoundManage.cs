using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CLIP_ENUM
{
    BLOCK,
    COLLECT,
    DESTROY,
    FLAP,
    HARDHAT,
    METROHIT
}
public class SoundManage : MonoBehaviour {


    private static SoundManage soundInstance;

    public static SoundManage instance { get { return soundInstance; } }

    private void Awake()
    {
        if(soundInstance !=  null && soundInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            soundInstance = this;
        }
    }

    public List<AudioSource> audioMainSource;
    public AudioSource backgroundAudio;

    // Use this for initialization
    void Start () {
        backgroundAudio.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void playAudioClip(CLIP_ENUM index, float volum = 1)
    {
        instance.audioMainSource[(int)index].volume = volum;
        instance.audioMainSource[(int)index].Play();
    }
}

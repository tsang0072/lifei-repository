using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioClip AMB_Game;
    public AudioClip SFX_Hit;

    AudioSource AMBSource;
    AudioSource SFXSource;


    private void Awake()
    {
        if(instance==null)
        {
            instance=this;
        }else if(instance!=this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        AMBSource=gameObject.AddComponent<AudioSource>();
        SFXSource=gameObject.AddComponent<AudioSource>();

    }
    void Update() {
    }
    //play sound when player hitting
    public void PlayHit(){
        SFXSource.clip=SFX_Hit;
        SFXSource.Play();
        
    }
    public void PauseBGM(){
        AMBSource.clip=AMB_Game;
        AMBSource.Pause();
    }
}

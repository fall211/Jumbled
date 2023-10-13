using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    public AudioSource musicPlayer;
    public AudioSource sfxPlayer;
    public AudioClip hurtSound;
    public AudioClip finishSound;

    void Start(){
        musicPlayer.volume = 0.5f;
        sfxPlayer.volume = 0.5f;
    }


    public void PlayHurtSound(){
        sfxPlayer.clip = hurtSound;
        sfxPlayer.Play();
    }

    public void PlayFinishSound(){
        sfxPlayer.clip = finishSound;
        sfxPlayer.Play();
    }

    public void ChangeVolume(float volume){
        musicPlayer.volume = volume;
        sfxPlayer.volume = volume;
    }

}

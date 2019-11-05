using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    [SerializeField] AudioSource audio;
    //creates the function that will play the music. 
    //This function takes a audioClip and a float as the volume. 
    private void PlayTheMusic(AudioClip clip, float volume)
    {
        audio.clip = clip;
        audio.volume = volume;
        audio.Play();
    }

    private void Start()
    {
        //plays the music useing the music clip and the soundvolume float from ChangeVolume. 
        PlayTheMusic(clip, ChangeVolume.soundVolume);
    }

    private void Update()
    {
        audio.volume = ChangeVolume.soundVolume;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVolume : MonoBehaviour
{
    [SerializeField] AudioSource audioMusic;
    [SerializeField] AudioSource audioMusicTwo;
    [SerializeField] AudioSource audioEffects;
    [SerializeField] AudioSource audioEffectsTwo;
    public static float soundVolume = 1.0f;

    //sets the volume to the float given by the slider. 
    public void SetVol(float vol)
    {
        soundVolume = vol;
    }

    private void Update()
    {
        //Debug.Log(soundVolume);
    }
}

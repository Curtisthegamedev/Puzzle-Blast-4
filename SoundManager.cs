using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager _instance;
    [SerializeField] AudioSource powerUpSound;
    [SerializeField] AudioSource music;
    public static float volume = 1.0f;

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    public void ChangeSound(float newVolume)
    {
        //volume = newVolume; 
    }

    public void PlayASound(AudioClip powerUpClip, float volume)
    {
        if (powerUpSound)
        {
            powerUpSound.clip = powerUpClip;
            powerUpSound.volume = volume;
            powerUpSound.Play();
            Debug.Log("if statment is true");
        }
    }
    public static SoundManager instance
    {
        get { return _instance; }
        set { _instance = value; }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource Source;
    public CMUSoundEffect[] Sound;

    // Use this for initialization
    void Awake()
    {
        instance = this;
    }

    /*
    public void PlaySoundEffect(int SoundEffectNumber, float Volume)
    {
        Source.PlayOneShot(Sound[SoundEffectNumber], Volume);
    }*/

    public void PlaySoundEffect(int SoundEffectNumber)
    {
        Debug.Log("Play Sound:" + Sound[SoundEffectNumber].clip);
        Source.PlayOneShot(Sound[SoundEffectNumber].clip, Sound[SoundEffectNumber].volume);
    }

    [System.Serializable]
    public class CMUSoundEffect
    {
        public AudioClip clip;
        public float volume = 1;
    }
}
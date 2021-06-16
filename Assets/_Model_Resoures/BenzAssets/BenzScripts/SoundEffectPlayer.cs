using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(AudioSource))]
public class SoundEffectPlayer : MonoBehaviour
{
    AudioSource source;
    //public SoundEffect[] AudioClips;
    public SoundManager.CMUSoundEffect[] SoundEffects;

    // Use this for initialization
    void Start()
    {
        GetAudioSource();
    }

    public void PlaySoundEffect(int SoundEffectIndex)
    {
        if (!source)
            GetAudioSource();

        source.PlayOneShot(SoundEffects[SoundEffectIndex].clip, SoundEffects[SoundEffectIndex].volume);
    }

    void GetAudioSource()
    {
        source = GetComponent<AudioSource>();

        if (source == null)
            source = SoundManager.instance.GetComponent<AudioSource>();
    }

    /*
    [System.Serializable]
    public class SoundEffect
    {
        public AudioClip clip;
        public float volume = 1;
    }*/
}
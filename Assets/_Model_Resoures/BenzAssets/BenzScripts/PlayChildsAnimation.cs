using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Play animation without transition
public class PlayChildsAnimation : MonoBehaviour
{
    public bool Loop;
    public bool PlayOnStart;
    public bool ResetOnEnable;
    public AnimationData[] Anims;
    Animator[] childAnimators;
    int animIndex;
    int childIndex;
    float timeCounter;
    bool isPlaying;

	// Added
	public AudioSource audioSource;

	// Use this for initialization
	void Awake ()
    {
        childAnimators = GetComponentsInChildren<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (Anims == null || Anims.Length == 0 || childAnimators == null || animIndex >= Anims.Length)
            return;

        timeCounter += Time.deltaTime;

        if (isPlaying)
        {
            if(timeCounter > Anims[animIndex].DelayBetweenChild)
            {
                timeCounter = 0;

                if (Anims[animIndex].WaitTime > 0)
                {
					// please remove
					if (audioSource)
					{
						audioSource.Play();
					}

                    childAnimators[childIndex].Play(Anims[animIndex].AnimationName);
                    childIndex++;

                    if (childIndex >= childAnimators.Length)
                    {
                        timeCounter = 0;
                        isPlaying = false;
                        animIndex++;
                        childIndex = 0;
                    }
                }
                else
                {
                    foreach (Animator animator in childAnimators)
                    {
						// please remove
						if (audioSource)
						{
							audioSource.Play();
						}

                        animator.Play(Anims[animIndex].AnimationName);
                    }

                    animIndex++;
                    childIndex = 0;
                    isPlaying = false;
                }

                if (animIndex >= Anims.Length && Loop)
                    animIndex = 0;
            }
        }
        else
        {
            if(timeCounter > Anims[animIndex].WaitTime)
            {
                timeCounter = 0;
                isPlaying = true;
            }
        }
	}

    void OnEnable()
    {
        if (ResetOnEnable)
        {
            animIndex = 0;
            childIndex = 0;
            timeCounter = 0;

            if (PlayOnStart)
                isPlaying = true;
            else
                isPlaying = false;
        }
    }

    [System.Serializable]
    public class AnimationData
    {
        public string AnimationName;
        public float WaitTime;
        public float DelayBetweenChild;
    }
}
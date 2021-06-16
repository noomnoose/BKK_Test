using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnimationFrame : MonoBehaviour
{
    public string stateName;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        if (anim != null)
            anim.Play(stateName, -1, Random.Range(0.0f, 1.0f));

        Debug.Log(anim);
    }

    void OnEnable()
    {
        if (anim != null)
            anim.Play(stateName, -1, Random.Range(0.0f, 1.0f));
    }
}
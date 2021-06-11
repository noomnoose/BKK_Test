using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_PaymentAnimation : MonoBehaviour
{
    public MovePath[] movePaths;

    void OnEnable()
    {
        ResetAnimation(); 
    }

    public void ResetAnimation()
    {
        for (int i = 0; i < movePaths.Length; i++)
        {
            movePaths[i].gameObject.SetActive(false);
        }
    }

    public void PlayAnimation(int index)
    {
        movePaths[index].gameObject.SetActive(true);
        movePaths[index].trail.gameObject.SetActive(true);
    }

    public void HideAnimation(int index)
    {
        movePaths[index].trail.gameObject.SetActive(false);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class AnimStartButton : MonoBehaviour
{
    public Button button;
    public Animator anim;
    public Transform ring1, ring2, ring3;
    public Image fill;
    public float speed1 = 30, speed2 = 30, speed3 = 30;
    public float decaySpeed = 0.5f;
    public float detectSpeed = 4f;

    public UnityEvent OnDetect;
    private bool IsRun;

    void OnEnable()
    {
        fill.fillAmount = 0f;
        IsRun = false;
        anim.SetTrigger("IDLE");
    }

    public void Init()
    {
        //gameObject.SetActive(false);
        //gameObject.transform.localScale = Vector3.zero;
        //enabled = false;
    }

    /// <summary>
    /// for debug Hold [A] to simulate detecting this button.
    /// </summary>
    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
            Detecting();
    }

    void FixedUpdate()
    {
        ring1.Rotate(0, 0, speed1 * Time.deltaTime);
        ring2.Rotate(0, 0, speed2 * Time.deltaTime);
        ring3.Rotate(0, 0, speed3 * Time.deltaTime);

        if (!IsRun)
            fill.fillAmount = Mathf.Clamp(fill.fillAmount - decaySpeed * Time.deltaTime, 0f, 1f);
    }
    /// <summary>
    /// CALL THIS FUNCTION WHILE AIMING THIS BUTTON.
    /// </summary>
    public void Detecting()
    {
        fill.fillAmount = Mathf.Clamp(fill.fillAmount + detectSpeed * Time.deltaTime, 0f, 1f);
        if (fill.fillAmount >= 1f)
        {
            if (!IsRun) AnimClick();
            IsRun = true;
        }
    }

    public void AnimClick()
    {
        //button.interactable = false;
        anim.enabled = true;
        anim.SetTrigger("CLICK");

        HUD.SetState(2);

        OnDetect.Invoke();

        Invoke("Disable", 1f);
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }

    public void SetEnable()
    {
        ////button.interactable = true;
        //anim.enabled = false;
        //enabled = true;

        //gameObject.SetActive(true);
        //transform.localScale = Vector3.zero;
        //iTween.ScaleTo(gameObject, iTween.Hash("scale", Vector3.one, "time", 0.33f, "easetype", iTween.EaseType.easeOutBack));
        //Invoke("Delay", 0.4f);
    }

    void Delay()
    {
        anim.enabled = true;
        //anim.SetTrigger("IDLE");
        AnimClick();
    }

    public void SetDisable()
    {
        //button.interactable = false;
        //anim.enabled = false;
        //iTween.ScaleTo(gameObject, iTween.Hash("scale", Vector3.zero, "time", 0.33f, "delay", 0.05f, "easetype", iTween.EaseType.easeInBack));
        //Invoke("DisableGameObject", 0.4f);
    }

    void DisableGameObject()
    {
        gameObject.SetActive(false);
        enabled = false;
    }
}

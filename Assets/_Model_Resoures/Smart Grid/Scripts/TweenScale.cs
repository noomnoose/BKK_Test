using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TweenScale : MonoBehaviour
{
    public Vector3 MinimalScale = Vector3.zero;
    public Vector3 MaximumScale = Vector3.one;
    public float tweenTime = 0.5f;
    public bool PopUpOnEnable;
    public bool PopUpFromZero;

    ScaleState state;
    bool isScaling;

    public UnityEvent ScaleDownEvent;
    public UnityEvent ScaleUpEvent;
    public UnityEvent OnHideEvents;

    void OnEnable()
    {
        if (PopUpOnEnable)
        {
            if (PopUpFromZero)
                transform.localScale = Vector3.zero;
            else
                transform.localScale = MinimalScale;

            ScaleToMaximum();
        }
    }

    void Update()
    {
        if (isScaling)
        {
            switch (state)
            {
                case ScaleState.ScaleUp:
                    if (transform.localScale == MaximumScale)
                    {
                        ScaleUpEvent.Invoke();
                        isScaling = false;
                    }
                    break;
                case ScaleState.ScaleDown:
                    if (transform.localScale == MinimalScale)
                    {
                        ScaleDownEvent.Invoke();
                        isScaling = false;
                    }
                    break;
                case ScaleState.Hide:
                    if (transform.localScale == Vector3.zero)
                    {
                        OnHideEvents.Invoke();
                        isScaling = false;
                    }
                    break;
                case ScaleState.HideAndInactive:
                    if (transform.localScale == Vector3.zero)
                    {
                        OnHideEvents.Invoke();
                        isScaling = false;
                    }
                    break;
            }
        }
    }

    public void ScaleToMaximum()
    {
        state = ScaleState.ScaleUp;
        isScaling = true;
        iTween.ScaleTo(gameObject, iTween.Hash("scale", MaximumScale, "time", tweenTime));
    }

    public void Hide()
    {
        state = ScaleState.Hide;
        isScaling = true;
        iTween.ScaleTo(gameObject, iTween.Hash("scale", Vector3.zero, "time", tweenTime));
    }

    public void ScaleToMinimum()
    {
        state = ScaleState.ScaleDown;
        isScaling = true;
        iTween.ScaleTo(gameObject, iTween.Hash("scale", MinimalScale, "time", tweenTime));
    }

    public void HideAndDisable()
    {
        state = ScaleState.HideAndInactive;
        isScaling = true;
        iTween.ScaleTo(gameObject, iTween.Hash("scale", Vector3.zero, "time", tweenTime));
    }

    public void SetScale(Vector3 scale)
    {
        transform.localScale = scale;
    }

    enum ScaleState
    {
        None,
        ScaleUp,
        ScaleDown,
        Hide,
        HideAndInactive
    }
}
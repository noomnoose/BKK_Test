using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HUD : MonoBehaviour
{
    public static HUD Singleton;

    [SerializeField]
    private Text title, hint;
    [SerializeField]
    private Image cursor, fill;
    [SerializeField]
    private GameObject hintRoot;
    //[SerializeField]
    //private AnimStartButton startButton;
    [SerializeField]
    private GameObject startBar;

    /// <summary>
    /// fill graphics at cursor[0f - 1f]
    /// </summary>
    public static float Fill
    {
        set
        {
            var clamped = Mathf.Clamp(value, 0f, 1f);
            Singleton.fill.fillAmount = clamped;
        }

        get
        {
            return Singleton.fill.fillAmount;
        }
    }
    
    void Awake()
    {
        Singleton = this;
        //startButton.Init();
        HUD.SetState(0); // default state.
        HUD.Fill = 0f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            HUD.SetState(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            HUD.SetState(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            HUD.SetState(2);
        }
    }

    public static void SetTitle(string title)
    {
        var has_text = !string.IsNullOrEmpty(title);
        Singleton.title.transform.parent.gameObject.SetActive(has_text);
        Singleton.title.text = title;
    }

    //public static void BindStartButton(UnityAction onClick)
    //{
    //    Singleton.startButton.onClick.RemoveAllListeners();
    //    Singleton.startButton.onClick.AddListener(onClick);
    //}

    public static void SetState(int state)
    {
        if (state == 0)
        {
            Singleton.cursor.gameObject.SetActive(true);
            Singleton.hintRoot.SetActive(true);
            //Singleton.startButton.SetDisable();
            Singleton.startBar.GetComponent<RectTransform>().pivot = new Vector2(0f, 0.5f);
            iTween.ScaleTo(Singleton.startBar, iTween.Hash("scale", Vector3.zero, "time", 0.33f, "oncomplete", "startbar_oncomplete", "oncompletetarget", Singleton.gameObject));
        }
        else if (state == 1)
        {
            Singleton.cursor.gameObject.SetActive(false);
            //Singleton.startButton.SetEnable();
            Singleton.startBar.SetActive(true);
            Singleton.startBar.transform.localScale = Vector3.zero;
            Singleton.startBar.GetComponent<RectTransform>().pivot = new Vector2(0f, 0.5f);
            iTween.ScaleTo(Singleton.startBar, iTween.Hash("scale", Vector3.one, "time", 0.33f));
        }
        else if (state == 2)
        {
            Singleton.cursor.gameObject.SetActive(false);
            Singleton.hintRoot.SetActive(false);
            Singleton.startBar.GetComponent<RectTransform>().pivot = new Vector2(1f, 0.5f);
            iTween.ScaleTo(Singleton.startBar, iTween.Hash("scale", Vector3.zero, "time", 0.33f, "oncomplete", "startbar_oncomplete", "oncompletetarget", Singleton.gameObject));
        }
    }

    void startbar_oncomplete()
    {
        startBar.SetActive(false);
    }
}

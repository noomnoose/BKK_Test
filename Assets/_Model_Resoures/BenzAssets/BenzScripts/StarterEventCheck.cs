using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarterEventCheck : MonoBehaviour
{

    public int ButtonNumber;

    //public GameObject CountDownBar;
    //Image CountDownImage;

    public float CountDown = 2;
    public float Count;
    public AnimStartButton AnimButton;

    public void Awake()
    {
        //	CountDownImage = CountDownBar.GetComponent<Image> ();
        Count = 0;
    }

    public void Update()
    {
        CountDown = ApplicationManage.instance.starterCountDown;
        //	CountDownImage.fillAmount = (Count / CountDown * 100) / 100;

    }

    void OnTriggerEnter(Collider target)
    {
        if (target.tag == "FakeRaycast")
        {
            HUD.SetTitle(ApplicationManage.instance.Title[ButtonNumber]);
        }
    }

    void OnTriggerStay(Collider target)
    {
        if (target.tag == "FakeRaycast")
        {
            AnimButton.Detecting();

            if (Count < CountDown)
            {
                Count += Time.deltaTime;
                //HUD.Fill = (Count / CountDown * 100) / 100;
            }
        }

        if (Count >= CountDown && !ApplicationManage.instance.IsPlaying)
        {
            Count = 0;
            //ApplicationManage.instance.StartPlaying (ButtonNumber);
        }
    }

    void OnTriggerExit(Collider target)
    {
        if (target.tag == "FakeRaycast")
        {
            Count = 0;
            //HUD.Fill = 0;
            ApplicationManage.instance.NoContentDetect();
        }
    }
}

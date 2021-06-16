using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CMUMarkerControl : MonoBehaviour
{

    public GameObject Loading;
    public GameObject Video;
    public GameObject[] LineControl;

    //public GameObject GridObj;

    public float Count;
    public float WaitTimeShow = 2.0f;

    public bool isShow = false;
    public bool isFound = false;

    Vector3 LoadingStartScale;

    public bool isTest;

    // Use this for initialization
    void Start()
    {
		
        LoadingStartScale = Loading.transform.localScale;

        Hide();

        if (isTest)
            Show();
    }

    float countButton;

	void OnEnable()
	{
		isShow = false;
		isFound = false;
	}

    // Update is called once per frame
    void Update()
    {
        CheckEneble();
		if(ApplicationManage.instance.StillTracking == false)
		{
			this.gameObject.SetActive (false);
		}

        if (isFound)
        {
            if (!isShow)
            {
                Count += Time.deltaTime;
                if (Count >= WaitTimeShow)
                {
                    Show();
                }
            }
        }

        //Reset Scene

        if (Input.GetMouseButtonDown(0))
        {
            countButton++;
            if (countButton >= 3)
            {
                Application.LoadLevel(0);
            }
        }

        if (countButton > 0)
        {
            countButton -= Time.deltaTime;
        }
    }


    public void Show()
    {
        isShow = true;

        Loading.SetActive(false);
        Video.SetActive(true);

        // bad performance
        Video.GetComponent<VideoPlayerScript>().Play();
    }

    public void Found()
    {
        if (isShow)
            return;
		
        isFound = true;
        Loading.SetActive(true);
        //GridObj.SetActive (true);
        iTween.ScaleTo(Loading, iTween.Hash("time", 1.0f, "scale", LoadingStartScale * 2.0f));
    }


    public void Lost()
    {
        isFound = false;
        Count = 0;

    }

    public void Hide()
    {
        Count = 0;
        isFound = false;
        isShow = false;
        Loading.SetActive(false);
        Video.SetActive(false);
		if(LineControl.Length!=0){
        LineControl[0].SetActive(false);
		}


        //GridObj.SetActive (false);
    }


    public void CheckEneble()
    {
        if (this.enabled)
        {
            Found();
        }
    }

    // test disable video after video playing finished.
    // call from onVideoEnd()
    public void InactiveVideo()
    {
        StartCoroutine(InactiveVid());
    }

    IEnumerator InactiveVid()
    {
        yield return new WaitForSeconds(0.55f);
        Video.SetActive(false);
    }
}
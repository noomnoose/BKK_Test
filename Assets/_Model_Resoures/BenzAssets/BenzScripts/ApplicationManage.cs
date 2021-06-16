using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ApplicationManage : MonoBehaviour
{
    //StateManager stateManager;

    //public StateManager StateManager
    //{
    //    get { return stateManager; }
    //}

    public static ApplicationManage instance;
    public int CurrentAnimation;
    [Space]
    public GameObject Starter;
    public float starterCountDown;

    [Space]
    public List<GameObject> AnimationSet;
    public List<string> Title;
    //public GameObject[] ModelMakers = new GameObject[6];

    [Space]
    public bool IsPlaying;
    public bool StillTracking;
    public float outTrackingCount;
    float Count;

    bool isCurrentPlayState = false;

    //
    ShowHideObjects hideScript;

    // Use this for initialization
    void Awake()
    {
        instance = this;
        StillTracking = false;
        IsPlaying = false;
        hideScript = Starter.GetComponent<ShowHideObjects>();

        // get vuforia state manager
        //stateManager = TrackerManager.Instance.GetStateManager(); 

        // set target framerate to 60
        Application.targetFrameRate = 30;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    // Update is called once per frame
    public void Update()
    {
        if (StillTracking == false)
        {
            if (Count < outTrackingCount)
            {
                Count += 1 * Time.deltaTime;
            }

            if (Count >= 0.3f && IsPlaying == true)
            {
                AnimationSet[CurrentAnimation].SetActive(false);
            }

            if (Count >= outTrackingCount)
            {
                IsPlaying = false;
                NoContentDetect();

                if (Starter && Starter.activeSelf)
                {
                    Starter.SetActive(false);
                }

                foreach (GameObject obj in AnimationSet)
                {
                    if (obj.activeSelf)
                    {
                        obj.SetActive(false);
                    }
                }
            }
        }
        else
        {
            Count = 0;
            if (Starter && !IsPlaying)
                Starter.SetActive(true);

            if (IsPlaying)
            {
                AnimationSet[CurrentAnimation].SetActive(true);
            }
        }

        if (IsPlaying == true)
        {
            //if (isCurrentPlayState == false) {
            //Starter.SetActive (false);
            HUD.SetTitle(Title[CurrentAnimation]);

            /*
            if (StillTracking == false)
            {
                AnimationSet[CurrentAnimation].SetActive(false);
            }
            else
            {
                AnimationSet[CurrentAnimation].SetActive(true);	
            }*/


            isCurrentPlayState = true;
            //}
        }
        else
        {
            //if (isCurrentPlayState == false) {
            AnimationSet[CurrentAnimation].SetActive(false);
            isCurrentPlayState = true;
            //}

        }

    }


    public void SetInListActive(List<GameObject> listName, bool on_off)
    {

        for (int i = 0; i < listName.Count; i++)
        {
            listName[i].SetActive(on_off);
        }

    }


    public void StartPlaying(int Buttonnumber)
    {
        CurrentAnimation = Buttonnumber;
        AnimationSet[CurrentAnimation].SetActive(true);
        IsPlaying = true;

        //HUD.SetState (1);
        HUD.SetTitle(Title[Buttonnumber]);
        hideScript.HideAllAndInactive();
        SoundManager.instance.PlaySoundEffect(3);
    }

    public void AnimationFinish()
    {
        IsPlaying = false;
        NoContentDetect();
        //SoundManager.instance.PlaySoundEffect(4);
    }

    public void NoContentDetect()
    {
        HUD.SetState(0);
        HUD.SetTitle("No Content Detected");
    }

    public bool isTrackingMarker()
    {
        bool result = false;
        // Query the StateManager to retrieve the list of markers currently being tracked by Vuforia)
        IEnumerable<TrackedReference> activeTrackables = stateManager.GetActiveTrackableBehaviours();

        // Iterate through the list of active trackables
        foreach (TrackedReference tb in activeTrackables)
        {
            // if there is any marker found, return true
            result = true;
            break;
        }

        return result;
    }
}
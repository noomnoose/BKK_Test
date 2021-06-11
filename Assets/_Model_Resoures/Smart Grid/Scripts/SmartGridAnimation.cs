using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartGridAnimation : MonoBehaviour
{
    public GameObject WaypointsToBuilding;
    public GameObject WaypointsToPlant;
    public float WaitTime;

    public GameObject Buildings;
    public ShowHideObjects PlantUIEffects;
    ShowHideObjects[] BuildingEffects;

    void Start()
    {
        BuildingEffects = new ShowHideObjects[Buildings.transform.childCount];
        for (int i = 0; i < BuildingEffects.Length; i++)
        {
            BuildingEffects[i] = Buildings.transform.GetChild(i).GetComponent<ShowHideObjects>();
        }
    }

    public void PlayAnimation()
    {
        WaypointsToBuilding.SetActive(true);
        WaypointsToPlant.SetActive(false);
        PlantUIEffects.HideAll();
        foreach (ShowHideObjects effect in BuildingEffects)
        {
            effect.HideAll();
        }
    }

    public void ActiveWaypointToPlant()
    {
        //yield return new WaitForSeconds(WaitTime);
        WaypointsToBuilding.SetActive(false);
        WaypointsToPlant.SetActive(true);

        // won't wotk on reach called until trail is disabled
        foreach (ShowHideObjects effect in BuildingEffects)
        {
            effect.HideAll();
        }
    }

    float timeCount = 0;

    void OnDisable()
    {
        timeCount = 0;
    }

    void Update()
    {
        if (ApplicationManage.instance.IsPlaying && WaypointsToBuilding.activeSelf && !WaypointsToPlant.activeSelf)
        {
            timeCount += Time.deltaTime;
            if (timeCount >= WaitTime)
            {
                ActiveWaypointToPlant();
            }
        }
    }
}
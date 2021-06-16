using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartGridBuilding : MonoBehaviour
{
    public float WaitTime = 2f;
    public float ShowInterval = 0.1f;
    public ShowHideObjects SolarCellsPanel;
    bool isShowing;

    // Use this for initialization
    void Start()
    {
		
    }
	
    // Update is called once per frame
    void Update()
    {
		
    }

    public void ShowSolarCells()
    {
        if (isShowing)
            return;
        
        StopAllCoroutines();
        StartCoroutine(TweenSolarCells(true));
        isShowing = true;
    }

    public void HideSolarCells()
    {
        if (!isShowing)
            return;

        StopAllCoroutines();
        StartCoroutine(TweenSolarCells(false));
        isShowing = false;
    }

    IEnumerator TweenSolarCells(bool show)
    {
        yield return new WaitForSeconds(WaitTime);
        for (int i = 0; i < SolarCellsPanel.ObjectList.Length; i++)
        {
            if (show)
                SolarCellsPanel.Show(i);
            else
                SolarCellsPanel.Hide(i);

            if (ShowInterval > 0)
                yield return new WaitForSeconds(ShowInterval);
        }
    }

    void OnDisable()
    {
        SolarCellsPanel.HideAll();
        isShowing = false;
    }
}
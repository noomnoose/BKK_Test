using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideObjects : MonoBehaviour
{
    public bool HideOnStart = true;
    public bool PopUpOnEnable = true;
    public float ShowUpTime = 0.5f;
    public GameObject[] ObjectList;
    Vector3[] ObjectScale;

    bool willInactive = false;

    void Awake()
    {
        ObjectScale = new Vector3[ObjectList.Length];
        for (int i = 0; i < ObjectList.Length; i++)
        {
            ObjectScale[i] = ObjectList[i].transform.localScale;
        }

        if (HideOnStart)
        {
            foreach (GameObject obj in ObjectList)
            {
                obj.transform.localScale = Vector3.zero;
            }
        }
    }

    void OnEnable()
    {
        if(PopUpOnEnable)
        {
            foreach (GameObject obj in ObjectList)
            {
                obj.transform.localScale = Vector3.zero;
            }

            ShowAll();
        }
    }

    void Update()
    {
        if(willInactive)
        {
            foreach(GameObject obj in ObjectList)
            {
                if (obj.transform.localScale != Vector3.zero)
                    return;
            }

            gameObject.SetActive(false);
        }
    }

    public void Show(int index)
    {
        willInactive = false;
        iTween.ScaleTo(ObjectList[index], iTween.Hash("scale", ObjectScale[index], "time", ShowUpTime));
    }

    public void Hide(int index)
    {
        iTween.ScaleTo(ObjectList[index], iTween.Hash("scale", Vector3.zero, "time", ShowUpTime));
    }

    public void ShowAll()
    {
        willInactive = false;
        for (int i = 0; i < ObjectList.Length; i++)
        {
            iTween.ScaleTo(ObjectList[i], iTween.Hash("scale", ObjectScale[i], "time", ShowUpTime));
        }
    }

    public void HideAll()
    {
        foreach (GameObject obj in ObjectList)
        {
            iTween.ScaleTo(obj, iTween.Hash("scale", Vector3.zero, "time", ShowUpTime));
        }
    }

    public void HideAllAndInactive()
    {
        willInactive = true;
        HideAll();
    }
}
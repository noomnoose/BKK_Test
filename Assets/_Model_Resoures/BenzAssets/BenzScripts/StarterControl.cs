using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarterControl : MonoBehaviour
{

    public GameObject cam;
    //public GameObject button;
    public float closedDistance;
    public Vector3 scale;

	//public StarterEventCheck eventCheck;

	//bool isNear = false;
    // Use this for initialization
    void Start()
    {


    }
	
    // Update is called once per frame
    void Update()
    {
		/*
        if (Vector3.Distance(transform.position, cam.transform.position) <= closedDistance)
        {
			if (!isNear) {
				
				//StartCoroutine (ScaleUp ());
				isNear = true;
			}
        }
        else
        {
			if (isNear) {
				//HUD.SetTitle("No Object Found");
				//StartCoroutine (ScaleDown ());
				isNear = false;
			}
        }*/

    }

	/*
    public IEnumerator ScaleUp()
    {
        yield return null;
       // button.SetActive(true);
        iTween.ScaleTo(gameObject, iTween.Hash("scale", scale, "time", 0.5f));

    }

    public IEnumerator ScaleDown()
    {
		
        iTween.ScaleTo(gameObject, iTween.Hash("scale", Vector3.zero, "time", 0.5f));
        while (button.transform.localScale.magnitude != 0)
            yield return null;
       / button.SetActive(false);
    }
	*/

}

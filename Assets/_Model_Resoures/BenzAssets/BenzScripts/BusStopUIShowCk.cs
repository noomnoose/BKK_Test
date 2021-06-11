using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusStopUIShowCk : MonoBehaviour {

	public GameObject cam;
	public GameObject UI;
	public float closedDistance;
	public Vector3 scale;

    void Start()
    {
        if(cam == null)
        {
            cam = GameObject.Find("Camera");
        }
    }

	// Use this for initialization
	void OnEnable() {
		

	}
	
	// Update is called once per frame
	void Update () {
		
	}
		

	public void OnTriggerStay()
	{
		if (Vector3.Distance (transform.position, cam.transform.position) <= closedDistance) {
			UI.SetActive (true);
			Debug.Log ("Uppp");
		} else {
			UI.SetActive (false);

		}
		Debug.Log ("Up");
	}

	public void OnTriggerExit()
	{
		UI.SetActive (false);
		Debug.Log ("Down");

	}
}

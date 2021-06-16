using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class VuforiaAutoFocus : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);

		CameraDevice myCam = CameraDevice.Instance;
		myCam.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

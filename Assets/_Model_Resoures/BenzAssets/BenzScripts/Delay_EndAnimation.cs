using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay_EndAnimation : MonoBehaviour {
	public float DelayTime;
	float count;

	// Use this for initialization
	void OnEnable () {
		count = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (count < DelayTime) {
			count += Time.deltaTime * 1;
		} else {
			ApplicationManage.instance.AnimationFinish ();
		}


	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoReset : MonoBehaviour {
	
	public List<GameObject> Object;
	// Use this for initialization
	void Start () {

	}

	void OnEnable(){
		for (int i = 0; i < Object.Count; i++) {
			Object [i].SetActive (false);
		}
	}

	// Update is called once per frame

}

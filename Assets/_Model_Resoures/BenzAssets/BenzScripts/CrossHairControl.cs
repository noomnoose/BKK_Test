using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairControl : MonoBehaviour {

	public GameObject CrossHair;
	public Vector3 scale;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (ApplicationManage.instance.IsPlaying == true) {
			CrossHair.SetActive (false);
		} else {
			CrossHair.SetActive (true);
		}

	}

	public IEnumerator ScaleUp()
	{
		yield return null;
		CrossHair.SetActive(true);
		iTween.ScaleTo(gameObject, iTween.Hash("scale", scale, "time", 0.5f));

	}

	public IEnumerator ScaleDown()
	{

		iTween.ScaleTo(gameObject, iTween.Hash("scale", Vector3.zero, "time", 0.5f));
		while (CrossHair.transform.localScale.magnitude != 0)
			yield return null;
		CrossHair.SetActive(false);
	}

}

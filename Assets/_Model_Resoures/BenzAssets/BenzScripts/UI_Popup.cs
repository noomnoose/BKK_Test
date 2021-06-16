using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Popup : MonoBehaviour {

	public Vector3 scale;
	// Use this for initialization

	public void OnEnable(){
		this.transform.localScale = new Vector3 (0, 0, 0);
        iTween.ScaleTo(gameObject, iTween.Hash("scale", scale, "time", 0.5f));
        //StartCoroutine(ScaleUp());
    }

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator ScaleUp()
	{
		yield return null;
		//this.SetActive(true);
		iTween.ScaleTo(gameObject, iTween.Hash("scale", scale, "time", 0.5f));

	}

	public IEnumerator ScaleDown()
	{

		iTween.ScaleTo(gameObject, iTween.Hash("scale", Vector3.zero, "time", 0.5f));
		while (this.transform.localScale.magnitude != 0)
			yield return null;
		//this.SetActive(false);
	}
}

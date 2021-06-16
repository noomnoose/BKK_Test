using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageScript : MonoBehaviour {

	public Vector3 scale;
	public GameObject Effect;
	// Use this for initialization

	public void OnEnable(){
		this.transform.localScale = new Vector3 (0, 0, 0);
		Effect.SetActive (false);
		StartCoroutine(ScaleUp());
	}
	// Update is called once per frame
	void Update()
	{

	}

	public IEnumerator ScaleUp()
	{
		yield return null;
		//this.SetActive(true);
		iTween.ScaleTo(gameObject, iTween.Hash("scale", scale, "time", 0.5f));
		SoundManager.instance.PlaySoundEffect (0);

	}

	public IEnumerator ScaleDown()
	{

		iTween.ScaleTo(gameObject, iTween.Hash("scale", Vector3.zero, "time", 0.5f));
		while (this.transform.localScale.magnitude != 0)
			yield return null;
		//this.SetActive(false);
	}
	void OnTriggerEnter(Collider target)
	{
		if(target.tag == "Truck")
		{
			SoundManager.instance.PlaySoundEffect (1);
			StartCoroutine (ScaleDown ());
			Effect.SetActive (true);
		}
	}

}

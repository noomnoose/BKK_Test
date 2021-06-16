using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDefualt_OnEnable : MonoBehaviour {

	public Vector3 MinimumScale;

	void OnEnable()
	{
		this.transform.localScale = MinimumScale;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarCellTransformReset : MonoBehaviour
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnEnable()
    {
        transform.localRotation = Quaternion.Euler(-180, 0, 0);
    }
}

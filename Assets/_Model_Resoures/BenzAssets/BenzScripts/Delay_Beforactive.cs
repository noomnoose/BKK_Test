using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay_Beforactive : MonoBehaviour {

	public List<GameObject> Object;
	public float DelayTime;
	float count;
    bool activated;

	// Use this for initialization
	void Start () {
		
	}
		
	void OnEnable(){
        activated = false;
        count = DelayTime;

        for (int i = 0; i < Object.Count; i++)
        {
            Object[i].SetActive(false);
        }
    }

	// Update is called once per frame
	void Update ()
    {

		//Debug.Log (count);

		if(count >0)
		{
			count -= 1 * Time.deltaTime;
		}

		if (!activated && count <= 0)
        {
			for (int i = 0; i < Object.Count; i++)
            {
				Object [i].SetActive (true);
			}
            activated = true;
		}
	}
}

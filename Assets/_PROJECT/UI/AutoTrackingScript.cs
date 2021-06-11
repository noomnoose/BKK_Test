using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoTrackingScript : MonoBehaviour
{
    public GameObject prefab;
    private Transform root;
    private GameObject instanced;
    public Transform point;
    public string info;
    
    private void OnEnable()
    {
        if (!point)
            point = transform;

        if (!root)
        {
            root = GameObject.Find("Canvas OBJECT DATA").transform;
        }

        if (!instanced)
        {
            instanced = GameObject.Instantiate<GameObject>(prefab);
            instanced.transform.SetParent(root, false);

            var script = instanced.GetComponent<UITrackingObj>();
            script.worldObj = point;
            script.rect = instanced.GetComponent<RectTransform>();

            instanced.gameObject.SetActive(true);
            var text = instanced.GetComponentInChildren<Text>();
            if (string.IsNullOrEmpty(info) == false)
                text.text = info;
            else
                text.text = point.name;
        }

        instanced.SetActive(true);
    }

    private void OnDisable()
    {
        if (instanced)
            instanced.SetActive(false);
    }
}

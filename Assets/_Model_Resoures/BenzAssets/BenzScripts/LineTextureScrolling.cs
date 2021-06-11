using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTextureScrolling : MonoBehaviour
{
    //How fast the texture scrolls
    public float textureScrollSpeed = 8f;
    LineRenderer line;
    TrailRenderer trail;

    // Use this for initialization
    void Start()
    {
        line = GetComponent<LineRenderer>();
        trail = GetComponent<TrailRenderer>();
    }
	
    // Update is called once per frame
    void Update()
    {
        // if has trail renderer scrolling it's texture in x axis
        if (trail)
        {
            trail.sharedMaterial.mainTextureOffset += new Vector2(Time.deltaTime * textureScrollSpeed, 0);
            if (trail.sharedMaterial.mainTextureOffset.x > 1000)
                trail.sharedMaterial.mainTextureOffset -= new Vector2(1000, 0);
        }
        // if has line renderer scrolling it's texture in x axis
        else if (line)
        {
            line.sharedMaterial.mainTextureOffset += new Vector2(Time.deltaTime * textureScrollSpeed, 0);
            if (line.sharedMaterial.mainTextureOffset.x > 1000)
                line.sharedMaterial.mainTextureOffset -= new Vector2(1000, 0);
        }
    }
}
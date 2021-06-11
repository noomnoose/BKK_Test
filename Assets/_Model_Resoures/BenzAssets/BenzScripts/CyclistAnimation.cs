using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyclistAnimation : MonoBehaviour
{
    public Animator animator;
    public int filterLength = 3;
    Queue<float> PositionFilter;
    Queue<float> RotationFilter;
    Vector3 previousPosition;
    float previousRotation;

    void Start()
    {
        PositionFilter = new Queue<float>();
        RotationFilter = new Queue<float>();

        for (int i =0; i < filterLength; i++)
        {
            PositionFilter.Enqueue(0);
            RotationFilter.Enqueue(0);
        }
    }

	// Update is called once per frame
	void Update ()
    {
        float deltaPosition = Vector3.Distance(transform.position, previousPosition);
        float deltaRotation = transform.rotation.eulerAngles.y - previousRotation;

        float filteredPosition = LowPassFilter(PositionFilter, deltaPosition);
        float filteredRotation = LowPassFilter(RotationFilter, deltaRotation);

        // test
        if (filteredPosition > 0)
            animator.SetFloat("speed", 1);
        else
            animator.SetFloat("speed", -1);

        if (filteredRotation < -1)
        {
            Debug.Log("Turn Left " + filteredRotation);
            animator.SetInteger("turning", -1);
        }
        else if (filteredRotation > 1)
        {
            Debug.Log("Turn Right " + filteredRotation);
            animator.SetInteger("turning", 1);
        }
        else if(filteredRotation > -0.05f || filteredRotation < 0.05f)
            animator.SetInteger("turning", 0);

        previousPosition = transform.position;
        previousRotation = transform.rotation.eulerAngles.y;
    }

    public float LowPassFilter(Queue<float> filterData, float lastValue)
    {
        if (filterData == null || filterData.Count <= 0)
            return 0;

        filterData.Enqueue(lastValue);
        filterData.Dequeue();

        float filteredValue = 0;
        foreach (float v in filterData)
        {
            filteredValue += v;
        }
        filteredValue /= filterLength;
        return filteredValue;
    }
}

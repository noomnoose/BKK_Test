using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;


public class MovePath : MonoBehaviour
{
    [TabGroup("Setting")]
    public bool SnapToFirstPoint = true, ActiveTrailOnStart = true, Loop = true, LookOnPath = false;
    [TabGroup("Setting")]
    public float speed = 5f, lookSpeed = 4f, minDistToReach = 0.1f, updateTimeLeftInterval = 0.5f;

    [TabGroup("References")]
    public Transform trail;
    [TabGroup("References")]
    public List<Transform> path;
    [TabGroup("References")]
    void UpdatePath()
    {
        path.Clear();
        foreach (Transform item in transform)
        {
            path.Add(item);
        }
    }

    [TabGroup("Events")]
    public UnityEvent OnStart, OnReached;
    [TabGroup("Events")]
    public MyTimeEvent OnTimeLeftUpdate;

    [TabGroup("Debug")]
    public int index;

    [TabGroup("Debug")]
    private float _current_dist, _total_dist;
    [TabGroup("Debug")]
    public float timeLeft;
    private float _next_time_left_update;

    void OnEnable()
    {
        if (path.Count <= 0)
        {
            UpdatePath();
        }

        if (SnapToFirstPoint)
            index = 0;

        if (trail != null)
        {
            trail.position = path[index].position;
            var next_point = (index + 1) % path.Count;
            trail.rotation = Quaternion.LookRotation(path[next_point].position - path[index].position);
        }

        if (ActiveTrailOnStart)
            if (trail != null)
                trail.gameObject.SetActive(true);

        _current_dist = 0f;
        _total_dist = GetTotalDist;

        OnStart.Invoke();
    }

    void Update()
    {
        if (trail == null)
            return;

        var _temp_pos = trail.position;
        trail.position = Vector3.MoveTowards(trail.position, path[index].position, speed * Time.deltaTime);
        var _delta_dist = Vector3.Distance(trail.position, _temp_pos);
        _current_dist += _delta_dist; // calcurate current distance.
        timeLeft = GetRemainDist / speed; // calcurate time left.
        
        UpdateTimeLeftEvent(); // update time left event
        UpdateLook(); // update look a head

        // check if reached a wp.
        if (Vector3.Distance(trail.position, path[index].position) < minDistToReach)
        {
            if (index == path.Count - 1)
            {
                // reached
                OnReached.Invoke();
                if (Loop)
                    index = 0;
            }
            else
            {
                index = (index + 1) % path.Count; // on reach normal waypoint.
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (path != null)
        {
            Gizmos.color = Color.black;
            var count = Loop ? path.Count : path.Count - 1;
            for (int i = 0; i < count; i++)
            {
                var second_index = (i + 1) % path.Count;
                Gizmos.DrawLine(path[i].position, path[second_index].position);
            }
        }
    }

    private void UpdateLook()
    {
        if (LookOnPath == false)
            return;

        if (trail == null)
            return;

        var look_dir = path[index].position - trail.position;

        if (look_dir.magnitude > 0.1f)
            trail.rotation = Quaternion.Lerp(trail.rotation, Quaternion.LookRotation(look_dir), Time.deltaTime * lookSpeed);
    }
    private void UpdateTimeLeftEvent()
    {
        if (Time.time > _next_time_left_update)
        {
            _next_time_left_update = Time.time + updateTimeLeftInterval;
            OnTimeLeftUpdate.Invoke(timeLeft);
        }
    }
    public float GetRemainDist
    {
        get
        {
            return Mathf.Max(_total_dist - _current_dist, 0f);
        }
    }
    public float GetTotalDist
    {
        get
        {
            var total = 0f;
            for (int i = 0; i < path.Count - 1; i++)
            {
                var dist = Vector3.Distance(path[i].position, path[i + 1].position);
                total += dist;
            }

            return total;
        }
    }

    [System.Serializable]
    public class MyTimeEvent : UnityEvent<float> { }
}

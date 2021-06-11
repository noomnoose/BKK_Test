using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimerScript : MonoBehaviour
{

    public Text text;
    public TextMesh mesh;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        mesh = GetComponent<TextMesh>();
        if (text)
            text.text = "";
        if (mesh)
            mesh.text = "";
    }

    public void OnUpdate(float second)
    {
        var t = second.ToTimeString();

        if (text)
            text.text = t;
        if (mesh)
            mesh.text = t;
    }

    void OnEnable()
    {
        if (text)
            text.text = "";
        if (mesh)
            mesh.text = "";
    }
}

public static class TimeHelper
{
    public static string ToTimeString(this float second)
    {
        var ts = TimeSpan.FromSeconds(second);
        var t_time = "";

        // the old one is well formatted
        /*
        if (ts.Hours > 0)
            t_time += ts.Hours + " ชั่วโมง";
        if (ts.Minutes > 0)
            t_time += ts.Minutes + " นาที";
        if (ts.TotalSeconds > 0)
            t_time += ts.Seconds + " วินาที";

        if (t_time == "0 วินาที")
            t_time = "";*/

        // temp
        if (ts.Minutes == 0)
            t_time += "00:";
        else if (ts.Minutes < 10)
            t_time += "0" + ts.Minutes + ":";
        else
            t_time += ts.Minutes;

        if (ts.TotalSeconds == 0)
        {
            t_time += "00";
        }
        else if (ts.TotalSeconds < 10)
        {
            t_time += "0" + (int)ts.TotalSeconds;
        }
        else
        {
            t_time += (int)ts.Seconds;
        }

        return t_time;
    }
}

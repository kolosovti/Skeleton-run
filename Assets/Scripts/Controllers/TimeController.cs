using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController
{
    private static TimeController instance = null;

    public static TimeController Instance
    {
        get
        {
            if (instance == null)
                instance = new TimeController();
            return instance;
        }
    }

    public void StartTime() => Time.timeScale = 1f;

    public void StopTime() => Time.timeScale = 0f;
}

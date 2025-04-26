using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text _timer;
    private int _sec;
    private int _min;
    private int _hour;
    private static bool active;

    void Start()
    {
        _timer = GetComponent<Text>();
        StartTimer();
        StartCoroutine(ITimer());
    }

    public static void StartTimer()
    {
        active = true;
    }
    public static void StopTimer()
    {
        active = false;
    }
    public static void Restart()
    {
        active = false;
    }


    IEnumerator ITimer()
    {
        while (active == true)
        {
            if(_sec == 59)
            {
                _min++;
                _sec = -1;
            }
            if (_min == 59)
            {
                _hour++;
                _min = -1;
            }
            _sec++;
            _timer.text = _hour.ToString("D2") + "." + _min.ToString("D2") + "." + _sec.ToString("D2");
            yield return new WaitForSeconds(1);
        }
    }
    
}

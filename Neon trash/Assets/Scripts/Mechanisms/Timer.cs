using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text _timer;
    public int _sec;
    public int _min;
    public int _hour;
    private static bool active;

    private Color NeonYellow = new Color(1f, 0.142361111f, 0.380392157f, 1f);
    private Color NeonRed = new Color(1f, 0.9019607843137255f, 0.5529411764705882f, 1f);

    void Start()
    {
        _timer = GetComponent<Text>();
        StartTimer();
        StartCoroutine(ITimer());
    }

    public void SetRedColor()
    {
        _timer.color = NeonYellow;
    }

    public void SetYellowColor()
    {
        _timer.color = NeonRed;
    }

    //Color(255, 41, 97, 255);<-------Red 
    //Color(255, 230, 141, 255);<--Yellow

    // float значение блять оказывается блять считается RGBA ---> new Color(255, 41, 97, 255) ---> 255/255 = 1, 41/255 = 0.142361111f ---> ну вы поняли суки
    // RGBA ---> Red Green blue Alpha chnl, альфа канал отвечает за прозрачность где 255(1f) не прзрачный, а 0 полностью стекло бля



    public void StartTimer()
    {
        active = true;
    }
    public void StopTimer()
    {
        active = false;
        //StartCoroutine(Istoped()); <--- эта хуйня реализующая моргание таймера крашит проект
    }
    public void Restart()
    {
        active = false;
    }

    IEnumerator Istoped()
    {
        while (active == false)
        {
            if (_timer.color == NeonYellow)
            {
                _timer.color = new Color(0, 0, 0, 0);
                yield return new WaitForSeconds(1);
                _timer.color = NeonYellow;
            }
            if (_timer.color == NeonRed)
            {
                _timer.color = new Color(0, 0, 0, 0);
                yield return new WaitForSeconds(1);
                _timer.color = NeonRed;
            }

        }
    }



    IEnumerator ITimer()
    {
        while (active == true)
        {
            if (_sec == 59)
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

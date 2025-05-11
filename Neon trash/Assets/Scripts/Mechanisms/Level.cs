using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public Timer timer;
    public bool useBuildIndexForLevelNumber = true;
    public int levelNumber = 0;
    [Range(0, 59)] public float levelTimeHour = 0;
    [Range(0, 59)] public float levelTimeMin = 0;
    [Range(0, 59)] public float levelTimeSec = 0;
    private int _star = 0;
    private int _timeStar = 0;
    private int _finishStar = 0;

    //private int _starNumber = 0;
    //public int starCount = 0;
    private void SetLevelNumber()
    {
        if (useBuildIndexForLevelNumber)
        {
            levelNumber = SceneManager.GetActiveScene().buildIndex;
        }
    }

    private void Awake()
    {
        SetLevelNumber();
        Load();
    }

    public void Save()
    {
        PlayerPrefs.SetInt($"Starlevel{levelNumber}", _star);
        PlayerPrefs.SetInt($"Timelevel{levelNumber}", _timeStar);
        PlayerPrefs.SetInt($"Finishlevel{levelNumber}", _finishStar);
    }

    public void Load()
    {
        _star = PlayerPrefs.GetInt($"Starlevel{levelNumber}");
        _timeStar = PlayerPrefs.GetInt($"Timelevel{levelNumber}");
        _finishStar = PlayerPrefs.GetInt($"Finishlevel{levelNumber}");
    }

    public void Finish()
    {
        _finishStar = 1;////
        timer.StopTimer();
        SetTimeStar();
        //CheckStar();
        Save();
    }

    public void StarNumberAdd()
    {
        _star = 1;
    }


    //private void CheckStar()
    //{
    //    if (_starNumber == starCount)
    //    {
    //        _star = 1;////
    //    }
    //}

    private bool CheckTime()
    {
        bool withinTimeLimit = (levelTimeHour > timer._hour) ||
                               (levelTimeHour == timer._hour && levelTimeMin > timer._min) ||
                               (levelTimeHour == timer._hour && levelTimeMin == timer._min && levelTimeSec > timer._sec);
        return withinTimeLimit;
    }

    private void SetTimerColor()
    {
        if (!CheckTime())
        {
            timer.SetRedColor();
        }
        else
        {
            timer.SetYellowColor();
        }
    }


    private void SetTimeStar()
    {
        if (CheckTime())
        {
            _timeStar = 1;////  
        }
    }

    private void DebugL()
    {
        Debug.Log($"_star: {_star}");
        Debug.Log($"_timeStar: {_timeStar}");
        Debug.Log($"_finishStar: {_finishStar}");
    }

    private void Update()
    {
        DebugL();
        SetTimerColor();
    }

}
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelWinPannel : MonoBehaviour
{
    private int levelNumber;

    public Animator FinishStar;
    public Animator TimeStar;
    public Animator Star;

    private void Start()
    {
        levelNumber = SceneManager.GetActiveScene().buildIndex;
    }

    public void ShowStars()
    {
        int star = PlayerPrefs.GetInt($"Starlevel{levelNumber}");
        int timeStar = PlayerPrefs.GetInt($"Timelevel{levelNumber}");
        int finishStart = PlayerPrefs.GetInt($"Finishlevel{levelNumber}");
        if (star == 1)
        {
            Star.SetBool("active", true);
        }
        if (timeStar == 1)
        {
            TimeStar.SetBool("active", true);
        }
        if (finishStart == 1)
        {
            FinishStar.SetBool("active", true);
        }
        
    }


    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartLeveL()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
}


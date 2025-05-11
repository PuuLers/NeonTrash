using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PausePannel : MonoBehaviour
{
    public GameObject pannel;
    private bool active = false;


    public void GoToMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Play()
    {
        Time.timeScale = 1.0f;
        pannel.SetActive(false);
        active = false;
    }

    public void Show()
    {
        Time.timeScale = 0f;
        pannel.SetActive(true);
        active = true;
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space))
        {
            active = !active;
            if (active)
            {
                Show();
            }
            if (!active)
            {
                Play();
            }
        }
    }

}

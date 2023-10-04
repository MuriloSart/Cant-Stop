using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject menu;
    public bool pause = false;
    public bool start = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pause)
            {
                Pause();
            }
            else
            {
                Play();
            }    
        }
    }
    
    public void Pause()
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
        pause = true;
    }

    public void Play()
    {
        Time.timeScale = 1f;
        menu.SetActive(false);
        pause = false;
    }
}

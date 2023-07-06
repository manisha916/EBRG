using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    public Canvas pauseCanvas;
    public Canvas homeCanvas;

    private bool isPaused = false;

    public void OnPauseButtonClicked()
    {
        Time.timeScale = 0f;
        pauseCanvas.enabled = true;
        isPaused = true;
    }
    public void OnPlayButtonClicked()
    {
        if (isPaused)
        {
            Time.timeScale = 1f;
            pauseCanvas.enabled = false;
            isPaused = false;
        }
    }
    public void OnRestartClicked()
    {
       
        pauseCanvas.enabled = false;
        GroundSpawner.instance.DestroyChildPrefav();


    }

    public void OnHomeClicked()
    {
        ScreenManager.instance.SwitchScreen(ScreenType.Home);
        pauseCanvas.enabled = false;
        Time.timeScale = 1f;
        GroundSpawner.instance.DestroyChildPrefav();
      
        
    }
   
   

    public void StartGame()
    {
        homeCanvas.enabled = false;


    }

}
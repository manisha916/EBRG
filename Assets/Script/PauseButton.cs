using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    public Canvas pauseCanvas;
    public Canvas homeCanvas;
    public Canvas gameOverCanvas;

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
        Time.timeScale = 1f;
        GroundSpawner.instance.DestroyChildPrefav();
        GroundSpawner.instance.StartGame();

    }

    public void OnHomeClicked()
    {
        Debug.Log("pausedisable");
        ScreenManager.instance.SwitchScreen(ScreenType.Home);
        pauseCanvas.enabled = false;
        Time.timeScale = 1f;
        GroundSpawner.instance.DestroyChildPrefav();
        GroundSpawner.instance.StartGame1();


    }
    public void OnRestartClickedGameOver()
    {
        gameOverCanvas.enabled = false;
        Time.timeScale = 1f;
        GroundSpawner.instance.DestroyChildPrefav();
        GroundSpawner.instance.StartGame();

    }

    public void OnHomeClickedGameOver()
    {
        gameOverCanvas.enabled = false;
        Debug.Log("home");//work
        ScreenManager.instance.SwitchScreen(ScreenType.Home);
        Time.timeScale = 1f;
        GroundSpawner.instance.DestroyChildPrefav();//work
        GroundSpawner.instance.StartGame1();


    }

    public void StartGame()
    {
        homeCanvas.enabled = false;
        GroundSpawner.instance.StartGame();
        Debug.Log("homeDisable");
    }

}
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public Canvas pauseCanvas;
    public Canvas homeCanvas;
    public Canvas gameOverCanvas;
    public Canvas shopCanvas;
    public Canvas settingCanvas;

    public Score score;

    public float startDelay = 5f;
    public CountDownCanvas countdownCanvas;



    public void Start()
    {
        score = GameObject.FindObjectOfType<Score>();
    }


    public void OnPauseButtonClicked()
    {
        Time.timeScale = 0f;
        pauseCanvas.enabled = true;
        SoundManager.inst.PlaySound(SoundName.click);
    }

    public async void OnPlayButtonClicked()
    {
       
        pauseCanvas.enabled = false;
        SoundManager.inst.PlaySound(SoundName.s2);
        countdownCanvas.StartCountdown();
        await System.Threading.Tasks.Task.Delay(2000);
        Time.timeScale = 1f;
    }
  

    public void OnRestartClicked()
    {
        pauseCanvas.enabled = false;
        Time.timeScale = 1f;
        GroundSpawner.instance.DestroyChildPrefav();
        GroundSpawner.instance.StartGame();
        score.ResetScore();
        SoundManager.inst.PlaySound(SoundName.s2);

    }

    public void OnHomeClicked()
    {
    
        ScreenManager.instance.SwitchScreen(ScreenType.Home);
        pauseCanvas.enabled = false;
        GroundSpawner.instance.DestroyChildPrefav();
        GroundSpawner.instance.StartGame1();
        score.ResetScore();
        SoundManager.inst.PlaySound(SoundName.s2);


    }
    public void OnRestartClickedGameOver()
    {
        gameOverCanvas.enabled = false;
        Time.timeScale = 1f;
        GroundSpawner.instance.DestroyChildPrefav();
        GroundSpawner.instance.StartGame();
        score.ResetScore();
        SoundManager.inst.PlaySound(SoundName.s2);

    }

    public void OnHomeClickedGameOver()
    {
        gameOverCanvas.enabled = false;
        Debug.Log("home");
        ScreenManager.instance.SwitchScreen(ScreenType.Home);
        GroundSpawner.instance.DestroyChildPrefav();
        GroundSpawner.instance.StartGame1();
        score.ResetScore();
        SoundManager.inst.PlaySound(SoundName.s2);

    }

    public void StartGame()
    {
        homeCanvas.enabled = false;
        GroundSpawner.instance.StartGame();
        Time.timeScale = 1f;
        SoundManager.inst.PlaySound(SoundName.s2);

    }
    public void OnShopClicked()
    {

        ScreenManager.instance.SwitchScreen(ScreenType.Shop);
        homeCanvas.enabled = false;
        SoundManager.inst.PlaySound(SoundName.s2);

    }
    public void OnSettingClicked()
    {

        ScreenManager.instance.SwitchScreen(ScreenType.Setting);
        homeCanvas.enabled = false;
        SoundManager.inst.PlaySound(SoundName.s2);

    }
    public void OnBackClicked()
    {

        ScreenManager.instance.SwitchScreen(ScreenType.Home);
        settingCanvas.enabled = false;
        SoundManager.inst.PlaySound(SoundName.click);

    }
    public void OnBackBtnClicked()
    {

        ScreenManager.instance.SwitchScreen(ScreenType.Home);
        shopCanvas.enabled = false;
        SoundManager.inst.PlaySound(SoundName.click);

    }
}


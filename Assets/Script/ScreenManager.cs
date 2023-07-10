using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public static ScreenManager instance;
    public BaseScreen[] screens;
    public BaseScreen currentScreen;

    private void Awake()
    {
        instance = this;
    }

    public void SwitchScreen(ScreenType screenType)
    {
        currentScreen.canvas.enabled = false;
        foreach (BaseScreen bs in screens)
        {
            if (bs.screenType == screenType)
            {
                bs.canvas.enabled = true;
                currentScreen = bs;
                break;
            }
        }
    }

}
public enum ScreenType
{
  Home,Pause,gameOver,Shop,Setting
}
[System.Serializable]
public class BaseScreen
{
    public ScreenType screenType;
    public Canvas canvas;
}
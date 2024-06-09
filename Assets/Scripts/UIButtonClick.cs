using System;
using UnityEngine;


public class UIButtonClick : MonoBehaviour
{
    private UIPanelActivator _uIPanelActivator;
    private SceneController _sceneController;
    private void Start()
    {
        _uIPanelActivator = GetComponent<UIPanelActivator>();
        _sceneController = GetComponent<SceneController>();
    }
    public void OnClickPause()
    {
        _uIPanelActivator.PauseGame();
    }

    public void OnClickContinue()
    {
        _uIPanelActivator.ContinueGame();
    }

    public void OnClickExit()
    {
        _sceneController.LoadMenu();
    }

    public void OnClickStartGame()
    {
        _sceneController.LoadGameScene();
    }

    public void OnClickRestart()
    {
        _sceneController.LoadGameScene();
    }
}

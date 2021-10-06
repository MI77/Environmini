using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.InputAction;

public class MainMenuBehaviour : MonoBehaviour
{
#if UNITY_STANDALONE_WIN
    public SceneAsset firstScene;
    public SceneAsset mainMenuScene;
#endif
    public GameObject mainMenu;
    public GameObject gameOverMenu;
    public GameObject creditsMenu;
    public GameObject currentMenu;
    public PlayerInput playerInput;
    public GameManager gameManager;

    public void StartNewGame()
    {

        gameManager.StartNewGame();
        HideMenu();
    }
    public void BackToMainMenu()
    {
#if UNITY_STANDALONE_WIN
        SceneManager.LoadScene(mainMenuScene.name);
#endif
#if UNITY_WEBGL
#endif
        HideMenu();
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void HideMenu()
    {
        if (currentMenu != null)
        {
            currentMenu.SetActive(false);
            //playerInput.SwitchCurrentActionMap("GridControls");
        }
        currentMenu = null;

    }

    public void ShowMenu(GameObject menuToShow)
    {
        HideMenu();
        currentMenu = menuToShow;
        if (menuToShow != null)
        {
            menuToShow.SetActive(true);
            //playerInput.SwitchCurrentActionMap("MenuControls");
        }
    }

    internal void ShowGameOverMenu()
    {
        ShowMenu(gameOverMenu);
    }
}

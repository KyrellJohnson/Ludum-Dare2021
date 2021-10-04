using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManagerMainMenu : MonoBehaviour
{
    [SerializeField]
    CanvasGroup 
        mainMenu,
        optionsMenu;

    private void Awake()
    {
        mainMenu.alpha = 1;
        mainMenu.interactable = true;
        mainMenu.blocksRaycasts = true;

        optionsMenu.alpha = 0;
        optionsMenu.interactable = false;
        optionsMenu.blocksRaycasts = false;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OptionsMenu()
    {
        mainMenu.alpha = 0;
        mainMenu.interactable = false;
        mainMenu.blocksRaycasts = false;

        optionsMenu.alpha = 1;
        optionsMenu.interactable = true;
        optionsMenu.blocksRaycasts = true;
    }

    public void MainMenu()
    {
        mainMenu.alpha = 1;
        mainMenu.interactable = true;
        mainMenu.blocksRaycasts = true;

        optionsMenu.alpha = 0;
        optionsMenu.interactable = false;
        optionsMenu.blocksRaycasts = false;
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
                // Application.Quit() does not work in the editor so
                // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                         Application.Quit();
        #endif
    }











}

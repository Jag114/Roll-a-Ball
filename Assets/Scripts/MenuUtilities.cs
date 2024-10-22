using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUtilities : MonoBehaviour
{
    public GameObject level_select_panel;
    GameObject options_panel;

    public void StartGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void StartGame(int lvl)
    {
        SceneManager.LoadScene(lvl, LoadSceneMode.Single);
    }

    public void OpenLevelSelectionWindow()
    {
        level_select_panel.gameObject.SetActive(true);
    }

    public void ShowOptions(bool isActive)
    {
        options_panel.SetActive(isActive);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

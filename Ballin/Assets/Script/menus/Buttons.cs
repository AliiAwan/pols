using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public string TitleScreen;
    public string Game;
    public string Shop;
    public string Settings;

    public void OpenTitleScreen()
    {
        SceneManager.LoadScene(TitleScreen);
    }

    public void OpenGame()
    {
        SceneManager.LoadScene(Game);
    }

    public void OpenShop()
    {
        SceneManager.LoadScene(Shop);
    }
    public void OpenSettings()
    {
        SceneManager.LoadScene(Settings);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

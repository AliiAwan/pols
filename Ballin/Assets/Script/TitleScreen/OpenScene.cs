using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenScene : MonoBehaviour
{
    public string SceneToOpen;

    public void openScene()
    {
        SceneManager.LoadScene(SceneToOpen);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

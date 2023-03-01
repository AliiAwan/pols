using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject PauseMenu;

    private float normalTimeScale;

    // Start is called before the first frame update
    void Start()
    {
        GlobalManager.IsPaused = false;
        GlobalManager.Pausable = true;
        PauseMenu.SetActive(false);

        normalTimeScale = Time.timeScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(GlobalManager.IsPaused || !GlobalManager.Pausable)// game is paused and pausemenu is already displayed
            {
                GlobalManager.IsPaused = false;
                PauseMenu.SetActive(false);

                Time.timeScale = normalTimeScale;
            }
            else
            {
                GlobalManager.IsPaused = true;
                PauseMenu.SetActive(true);

                Time.timeScale = 0;
            }
        }
    }
}

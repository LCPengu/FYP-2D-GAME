using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        ConsolePrint("Game was Resumed");
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f ;
        GameIsPaused = true;
        ConsolePrint("Game was Paused");
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        ConsolePrint("Loading menu...");
        SceneManager.LoadScene(0);
    }

    public void QuitingGame()
    {
        ConsolePrint("Quiting game");
        Application.Quit();
    }

    public void ConsolePrint(string output)
    {
        Debug.Log(output);
    }
}

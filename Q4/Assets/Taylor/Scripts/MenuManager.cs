using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    PlayerChecker playerChecker;

    public static bool canPause = true;
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    public GameObject playTestUI;
    public bool playTest;

    void Start()
    {
        playerChecker = GameObject.Find("Players").GetComponent<PlayerChecker>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canPause)
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

        if (Input.GetKeyDown(KeyCode.T))
        {
            playTest = !playTest;
        }

        if (!playTest)
        {
            playTestUI.SetActive(true);
        }
        else
        {
            playTestUI.SetActive(false);
        }
    }

    public void Resume()
    {
        if (playerChecker.canSwitch == false)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void PressStart()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void PressCredits()
    {
        SceneManager.LoadScene("CreditScene");
    }

    public void PressToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PressQuit()
    {
        Debug.Log("Quitting Application...");
        Application.Quit();
    }
}

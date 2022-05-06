using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    PlayerChecker playerChecker;
    MGManager MGM;

    public static bool canPause = true;
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    void Start()
    {
        playerChecker = GameObject.Find("Players").GetComponent<PlayerChecker>();
        MGM = GameObject.Find("MiniGameManager").GetComponent<MGManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canPause && BuildingMenu.menuCheck == false && SpawnMenuActivate.menuCheck == false)
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

        if (!GameIsPaused && BuildingMenu.menuCheck == false && SpawnMenuActivate.menuCheck == false && MGManager.fishGame == false && MGManager.rogGame == false && MGManager.oreGame == false && MGManager.woodGame == false)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
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

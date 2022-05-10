using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    MGManager MGM;
    Population pop;

    public static bool canPause = true;
    public static bool GameIsPaused;
    public GameObject pauseMenuUI;

    void Start()
    {
        MGM = GameObject.Find("MiniGameManager").GetComponent<MGManager>();
        pop = GameObject.Find("Population Manager").GetComponent<Population>();
        GameIsPaused = false;
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

        try
        {
            if (!GameIsPaused && BuildingMenu.menuCheck == false && SpawnMenuActivate.menuCheck == false && MGManager.oreGame == false && pop.winScreen.activeInHierarchy == false)
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
        catch
        {
            //I'm not dealing with you rn....
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
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void PressCredits()
    {
        SceneManager.LoadScene("CreditScene");
    }

    public void PressToMain()
    {
        SceneManager.LoadScene("MainMenu");
        One.goForIt = false;
    }

    public void PressQuit()
    {
        Debug.Log("Quitting Application...");
        Application.Quit();
    }

    public void hover()
    {
        FindObjectOfType<AudioManager>().Play("Hover");
    }

    public void click()
    {
        FindObjectOfType<AudioManager>().Play("Click");
    }
}

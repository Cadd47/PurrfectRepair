﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    PlayerChecker playerChecker;

    public static bool canPause = true;
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    
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
    }

    public void Resume()
    {
        if (playerChecker.canSwitch == true)
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
        Cursor.lockState = CursorLockMode.None;

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    //Main transitions
    public void PressStart()
    {
        SceneManager.LoadScene("TaylorTest");
    }

    public void PressOptions()
    {
        SceneManager.LoadScene("OptionScene");
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

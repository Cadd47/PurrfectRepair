﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMenuActivate : MonoBehaviour
{
    BuildingManager buildingManager;
    PlayerChecker playerChecker;

    public GameObject mainCam;
    public GameObject spawnCam;
    public GameObject spawnMenu;

    private bool hasPlayer;
    private bool amOne;
    public bool editBuild = false;

    public int menuCheck;

    void Start()
    {
        playerChecker = GameObject.Find("Players").GetComponent<PlayerChecker>();
        buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && hasPlayer)
        {
            menuCheck++;
            Check();
        }
    }

    private void OnTriggerEnter(Collider buildMenu)
    {
        if (buildMenu.CompareTag("Player"))
        {
            hasPlayer = true;
        }
    }

    private void OnTriggerExit(Collider buildMenu)
    {
        if (buildMenu.CompareTag("Player"))
        {
            hasPlayer = false;
        }
    }

    private void Check()
    {
        if (menuCheck % 2 == 1)
        {
            playerChecker.canSwitch = false;
            //camera & build menu
            mainCam.SetActive(false);
            spawnCam.SetActive(true);
            spawnMenu.SetActive(true);
            //cursor
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            //buildings
            editBuild = true;
            //Checks which player you are
            if (GameObject.Find("Player One").GetComponent<PlayerMovement>().enabled == true)
            {
                amOne = true;
                GameObject.Find("Player One").GetComponent<PlayerMovement>().enabled = false;
                GameObject.Find("Player One").GetComponent<AltGrav>().enabled = true;
            }

            if (GameObject.Find("Player Two").GetComponent<PlayerMovement>().enabled == true)
            {
                amOne = false;
                GameObject.Find("Player Two").GetComponent<PlayerMovement>().enabled = false;
                GameObject.Find("Player Two").GetComponent<AltGrav>().enabled = true;
            }
        }

        if (menuCheck % 2 == 0)
        {
            playerChecker.canSwitch = true;
            //destroy any green and red
            Destroy(buildingManager.selectedObject);
            buildingManager.selectedObject = null;
            buildingManager.cantSelect = false;
            //camera & build menu
            mainCam.SetActive(true);
            spawnCam.SetActive(false);
            spawnMenu.SetActive(false);
            //cursor
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            //buildings
            editBuild = false;
            //Checks which player you are when closing build menu
            if (amOne)
            {
                GameObject.Find("Player One").GetComponent<PlayerMovement>().enabled = true;
                GameObject.Find("Player One").GetComponent<AltGrav>().enabled = false;
            }
            else
            {
                GameObject.Find("Player Two").GetComponent<PlayerMovement>().enabled = true;
                GameObject.Find("Player Two").GetComponent<AltGrav>().enabled = false;
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMenu : MonoBehaviour
{
    BuildingManager buildingManager;
    PlayerChecker playerChecker;

    public GameObject mainCam;
    public GameObject buildCam;

    public GameObject buildMenu;

    private bool hasPlayer;
    private bool amOne;

    public int menuCheck;

    void Start()
    {
        playerChecker = GameObject.Find("Players").GetComponent<PlayerChecker>();
        buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
        
        buildingManager.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && hasPlayer)
        {
            menuCheck++;
            check();
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
            GameObject.Find("BuildingManager").GetComponent<BuildingManager>().enabled = false;
        }
    }

    void check()
    {
        if (menuCheck % 2 == 1)
        {
            playerChecker.canSwitch = false;

            //camera & build menu
            mainCam.SetActive(false);
            buildCam.SetActive(true);
            buildMenu.SetActive(true);

            //cursor
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            GameObject.Find("BuildingManager").GetComponent<BuildingManager>().enabled = true;

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
            GameObject.Find("BuildingManager").GetComponent<BuildingManager>().enabled = false;

            //destroy any green and red
            Destroy(buildingManager.selectedObject);
            buildingManager.selectedObject = null;

            playerChecker.canSwitch = true;

            //camera & build menu
            mainCam.SetActive(true);
            buildCam.SetActive(false);
            buildMenu.SetActive(false);

            //cursor
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

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

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
    public GameObject buildGrid;
    public GameObject E;
    public Light mainLight;

    private bool hasPlayer;
    public static bool amOne;
    public bool editBuild = false;

    public static bool menuCheck;

    void Start()
    {
        playerChecker = GameObject.Find("Players").GetComponent<PlayerChecker>();
        buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && hasPlayer)
        {
            menuCheck = !menuCheck;
            Check();
        }

        if (menuCheck)
        {
            MenuManager.canPause = false;

            if (Input.GetKeyDown(KeyCode.E) && !hasPlayer)
            {
                menuCheck = !menuCheck;
                Check();
            }
        }
        else
        {
            MenuManager.canPause = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && menuCheck)
        {
            MenuManager.canPause = false;
            menuCheck = !menuCheck;
            Check();
        }

        if (hasPlayer)
        {
            E.SetActive(true);
        }
        else
        {
            E.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            hasPlayer = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            hasPlayer = false;
        }
    }

    private void Check()
    {
        if (menuCheck)
        {
            enableBuildMenu();
        }
        else
        {
            disableBuildMenu();
        }
    }

    private void enableBuildMenu()
    {
        playerChecker.canSwitch = false;
        //camera & menu
        mainCam.SetActive(false);
        buildCam.SetActive(true);
        buildMenu.SetActive(true);
        buildGrid.SetActive(true);
        mainLight.shadowStrength = 0f;
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
    private void disableBuildMenu()
    {
        playerChecker.canSwitch = true;
        //destroy any green and red
        Destroy(buildingManager.selectedObject);
        buildingManager.selectedObject = null;
        buildingManager.cantSelect = false;
        //camera & menu
        mainCam.SetActive(true);
        buildCam.SetActive(false);
        buildMenu.SetActive(false);
        buildGrid.SetActive(false);
        mainLight.shadowStrength = 0.15f;
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
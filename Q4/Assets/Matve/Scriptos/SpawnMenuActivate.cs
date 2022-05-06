using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMenuActivate : MonoBehaviour
{

    PlayerChecker playerChecker;

    public GameObject mainCam;
    public GameObject buildCam;
    public GameObject buildMenu;
    public GameObject E;

    private bool hasPlayer;
    private bool amOne;
    public bool editBuild = false;

    public static bool menuCheck;

    void Start()
    {
        playerChecker = GameObject.Find("Players").GetComponent<PlayerChecker>();
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
        //camera & build menu
        mainCam.SetActive(false);
        buildCam.SetActive(true);
        buildMenu.SetActive(true);
        //cursor && pause
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
    private void disableBuildMenu()
    {
        playerChecker.canSwitch = true;
        //camera & build menu
        mainCam.SetActive(true);
        buildCam.SetActive(false);
        buildMenu.SetActive(false);
        //cursor && pause
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

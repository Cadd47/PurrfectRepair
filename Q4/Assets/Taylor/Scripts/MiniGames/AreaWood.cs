using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaWood : MonoBehaviour
{
    PlayerChecker playerChecker;
    MGManager mgm;

    public GameObject E;
    public bool hasPlayer;
    public static bool active;

    public static bool amOne;

    private void Start()
    {
        playerChecker = GameObject.Find("Players").GetComponent<PlayerChecker>();
        mgm = GameObject.Find("MiniGameManager").GetComponent<MGManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && hasPlayer)
        {
            active = !active;
            Check();
        }

        if (active)
        {
            if (Input.GetKeyDown(KeyCode.E) && !hasPlayer)
            {
                active = !active;
                Check();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && active)
        {
            active = !active;
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

        Collider[] hitChecks = Physics.OverlapSphere(transform.position, 7.5f);
        foreach (Collider hitCollider in hitChecks)
        {
            if (hitCollider.gameObject.name == "Player One")
            {
                if (GameObject.Find("Player One").GetComponent<x>().enabled == true)
                {
                    hasPlayer = true;
                }
                else
                {
                    hasPlayer = false;
                }
            }

            if (hitCollider.gameObject.name == "Player Two")
            {
                if (GameObject.Find("Player Two").GetComponent<x>().enabled == true)
                {
                    hasPlayer = true;
                }
                else
                {
                    hasPlayer = false;
                }
            }

            if (hitCollider.gameObject.name != "Player One" && hitCollider.gameObject.name != "Player Two")
            {
                hasPlayer = false;
            }
        }
    }

    private void Check()
    {
        if (active)
        {
            enableMG();
        }
        else
        {
            disableMG();
        }
    }

    private void enableMG()
    {
        playerChecker.canSwitch = false;

        MGManager.woodGame = true;
        mgm.PleaseCheck();

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

    public void disableMG()
    {
        playerChecker.canSwitch = true;

        MGManager.woodGame = false;
        mgm.PleaseCheck();

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
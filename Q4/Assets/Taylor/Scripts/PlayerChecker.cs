using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChecker : MonoBehaviour
{
    public static bool playerCheck;
    public bool canSwitch;

    public GameObject camOne;
    public GameObject camTwo;

    public GameObject sprintOne;
    public GameObject sprintTwo;

    // Start is called before the first frame update
    void Start()
    {
        canSwitch = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && canSwitch)
        {
            playerCheck = !playerCheck;
            Check();
        }

    }

    public void checkPlayer()
    {
        playerCheck = !playerCheck;
        Check();
    }

    public void Check()
    {
        if (!playerCheck)
        {
            //Debug.Log("Even");
            GameObject.Find("Player One").GetComponent<PlayerMovement>().enabled = true;
            GameObject.Find("Player Two").GetComponent<PlayerMovement>().enabled = false;

            GameObject.Find("Player One").GetComponent<AltGrav>().enabled = false;
            GameObject.Find("Player Two").GetComponent<AltGrav>().enabled = true;

            GameObject.Find("Player One").GetComponent<x>().enabled = true;
            GameObject.Find("Player Two").GetComponent<x>().enabled = false;

            camOne.SetActive(true);
            camTwo.SetActive(false);

            //particles
            sprintOne.SetActive(true);
            sprintTwo.SetActive(false);
        }

        if (playerCheck)
        {
            //Debug.Log("Odd");
            GameObject.Find("Player One").GetComponent<PlayerMovement>().enabled = false;
            GameObject.Find("Player Two").GetComponent<PlayerMovement>().enabled = true;

            GameObject.Find("Player One").GetComponent<AltGrav>().enabled = true;
            GameObject.Find("Player Two").GetComponent<AltGrav>().enabled = false;

            GameObject.Find("Player One").GetComponent<x>().enabled = false;
            GameObject.Find("Player Two").GetComponent<x>().enabled = true;

            camOne.SetActive(false);
            camTwo.SetActive(true);

            //particles
            sprintOne.SetActive(false);
            sprintTwo.SetActive(true);
        }
    }
}

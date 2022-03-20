using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChecker : MonoBehaviour
{

    private float playerCheck;

    public GameObject camOne;
    public GameObject camTwo;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

        playerCheck = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            playerCheck++;
            Check();
        }

    }

    void Check()
    {
        if (playerCheck % 2 == 0)
        {
            Debug.Log("Even");
            GameObject.Find("Player One").GetComponent<PlayerOneMovement>().enabled = true;
            GameObject.Find("Player Two").GetComponent<PlayerTwoMovement>().enabled = false;

            GameObject.Find("Player One").GetComponent<AltGrav>().enabled = false;
            GameObject.Find("Player Two").GetComponent<AltGrav>().enabled = true;

            camOne.SetActive(true);
            camTwo.SetActive(false);
        }

        if (playerCheck % 2 == 1)
        {
            Debug.Log("Odd");
            GameObject.Find("Player One").GetComponent<PlayerOneMovement>().enabled = false;
            GameObject.Find("Player Two").GetComponent<PlayerTwoMovement>().enabled = true;

            GameObject.Find("Player One").GetComponent<AltGrav>().enabled = true;
            GameObject.Find("Player Two").GetComponent<AltGrav>().enabled = false;

            camOne.SetActive(false);
            camTwo.SetActive(true);
        }
    }
}

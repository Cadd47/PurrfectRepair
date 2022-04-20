using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGManager : MonoBehaviour
{
    public GameObject wood;
    public GameObject stone;
    public GameObject ore;
    public GameObject fish;

    [Header("Side Stuffs")]
    public GameObject oreSpawner;
    public static bool woodGame;
    public static bool oreGame;
    public static bool fishGame;

    void Start()
    {
        wood.SetActive(false);
        stone.SetActive(false);
        ore.SetActive(false);
        fish.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            woodGame = !woodGame;
            CheckMG();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            oreGame = !oreGame;
            CheckMG();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            fishGame = !fishGame;
            CheckMG();
        }

        if(!woodGame && !oreGame && !fishGame)
        {
            MenuManager.canPause = true;
        }
        else
        {
            MenuManager.canPause = false;
        }
    }

    private void CheckMG()
    {
        if (woodGame)
        {
            wood.SetActive(true);
        }
        else
        {
            wood.SetActive(false);
        }

        if (oreGame)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            ore.SetActive(true);
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            ore.SetActive(false);

            foreach(Transform child in oreSpawner.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }

        if (fishGame)
        {
            fish.SetActive(true);
        }
        else
        {
            fish.SetActive(false);
        }
    }
}

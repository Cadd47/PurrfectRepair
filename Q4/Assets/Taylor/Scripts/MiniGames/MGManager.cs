using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGManager : MonoBehaviour
{
    public GameObject wood;
    public GameObject stone;
    public GameObject ore;
    public GameObject fish;

    public static bool woodGame;
    public static bool oreGame;

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
    }

    private void CheckMG()
    {
        if (woodGame)
        {
            MenuManager.canPause = false;

            wood.SetActive(true);
        }
        if (!woodGame)
        {
            MenuManager.canPause = true;

            wood.SetActive(false);
        }

        if (oreGame)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            MenuManager.canPause = false;

            ore.SetActive(true);
        }
        if (!oreGame)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            MenuManager.canPause = true;

            ore.SetActive(false);
        }
    }
}

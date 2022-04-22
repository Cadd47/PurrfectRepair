using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGManager : MonoBehaviour
{
    public GameObject wood;
    public GameObject rog;
    public GameObject ore;
    public GameObject fish;

    public bool woodGame;
    public bool oreGame;
    public bool fishGame;
    public bool rogGame;

    [Header("Side Stuffs")]
    public GameObject oreSpawner;
    public GameObject rogSpawner;

    void Start()
    {
        wood.SetActive(false);
        rog.SetActive(false);
        ore.SetActive(false);
        fish.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            woodGame = !woodGame;
            StartCoroutine(CheckMG());
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            oreGame = !oreGame;
            StartCoroutine(CheckMG());
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            fishGame = !fishGame;
            StartCoroutine(CheckMG());
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            rogGame = !rogGame;
            StartCoroutine(CheckMG());
        }

        if (!woodGame && !oreGame && !fishGame && !rogGame)
        {
            MenuManager.canPause = true;
        }
        else
        {
            MenuManager.canPause = false;
        }
    }

    IEnumerator CheckMG()
    {
        if (woodGame)
        {
            wood.SetActive(true);
        }
        else
        {
            wood.SetActive(false);
        }

        if (fishGame)
        {
            fish.SetActive(true);
        }
        else
        {
            fish.SetActive(false);
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

            while(oreSpawner.transform.childCount > 0)
            {
                foreach (Transform child in oreSpawner.transform)
                {
                    GameObject.Destroy(child.gameObject);
                    yield return null;
                }
            }
        }

        if (rogGame)
        {
            rog.SetActive(true);
        }
        else
        {
            rog.SetActive(false);

            while (rogSpawner.transform.childCount > 0)
            {
                foreach (Transform child in rogSpawner.transform)
                {
                    GameObject.Destroy(child.gameObject);
                    yield return null;
                }
            }
        }
    }
}

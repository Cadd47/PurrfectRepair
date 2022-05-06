using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGManager : MonoBehaviour
{
    PlayerChecker playerChecker;

    public GameObject players;

    [Header("MG Stuffs")]
    public GameObject wood;
    public GameObject rog;
    public GameObject ore;
    public GameObject fish;

    public static bool woodGame;
    public static bool oreGame;
    public static bool fishGame;
    public static bool rogGame;

    [Header("Side Stuffs")]
    public GameObject oreSpawner;
    public GameObject rogSpawner;

    void Start()
    {
        wood.SetActive(false);
        rog.SetActive(false);
        ore.SetActive(false);
        fish.SetActive(false);

        playerChecker = GameObject.Find("Players").GetComponent<PlayerChecker>();
    }

    void Update()
    {
        if (AreaWood.activateMG)
        {
            AreaWood.activateMG = false;
            woodGame = !woodGame;
            StartCoroutine(CheckMG());
        }
        if (AreaOre.activateMG)
        {
            AreaOre.activateMG = false;
            oreGame = !oreGame;
            StartCoroutine(CheckMG());
        }
        if (AreaFish.activateMG)
        {
            AreaFish.activateMG = false;
            fishGame = !fishGame;
            StartCoroutine(CheckMG());
        }
        if (AreaStone.activateMG)
        {
            AreaStone.activateMG = false;
            rogGame = !rogGame;
            StartCoroutine(CheckMG());
        }

        if (!woodGame && !oreGame && !fishGame && !rogGame)
        {
            MenuManager.canPause = true;
            playerChecker.canSwitch = true;
            players.SetActive(true);
        }
        else
        {
            MenuManager.canPause = false;
            playerChecker.canSwitch = false;
            players.SetActive(false);
        }
    }

    public void PleaseCheck()
    {
        StartCoroutine(CheckMG());
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
            FishMG.catchProgress = 0.15f;
            fish.SetActive(true);
        }
        else
        {
            fish.SetActive(false);
        }

        if (oreGame)
        {
            ore.SetActive(true);
        }
        else
        {
            ore.SetActive(false);

            while (oreSpawner.transform.childCount > 0)
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

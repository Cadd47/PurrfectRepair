using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGManager : MonoBehaviour
{
    RogMG rogG;
    OreMG oreG;

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

    public void Start()
    {
        wood.SetActive(false);
        rog.SetActive(false);
        ore.SetActive(false);
        fish.SetActive(false);

        oreG = ore.GetComponent<OreMG>();
    }

    void Update()
    {
        if (!woodGame && !oreGame && !fishGame && !rogGame)
        {
            MenuManager.canPause = true;
        }
        else
        {
            MenuManager.canPause = false;
        }

        //rogG = GameObject.Find("Collector").GetComponent<RogMG>();
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

        if (rogGame)
        {
            rog.SetActive(true);
            rogG = GameObject.Find("Collector").GetComponent<RogMG>();
            rogG.pleaseRog();
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

        if (oreGame)
        {
            ore.SetActive(true);
            oreG.pleaseShine();
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

    }
}

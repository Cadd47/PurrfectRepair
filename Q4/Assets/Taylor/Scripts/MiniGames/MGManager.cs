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

    [Header("Animations")]
    public GameObject woodAni;
    public GameObject oreAni;
    public GameObject fishAni;
    public GameObject rogAni;

    public void Start()
    {
        wood.SetActive(false);
        rog.SetActive(false);
        ore.SetActive(false);
        fish.SetActive(false);

        woodAni.SetActive(false);
        oreAni.SetActive(false);
        fishAni.SetActive(false);
        rogAni.SetActive(false);

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
    }

    public void PleaseCheck()
    {
        StartCoroutine(CheckMG());
    }

    IEnumerator CheckMG()
    {
        if (woodGame)
        {
            woodAni.SetActive(true);
            wood.SetActive(true);
        }
        else
        {
            woodAni.SetActive(false);
            wood.SetActive(false);
        }

        if (fishGame)
        {
            fishAni.SetActive(true);
            FishMG.catchProgress = 0.15f;
            fish.SetActive(true);
        }
        else
        {
            fishAni.SetActive(false);
            fish.SetActive(false);
        }

        if (rogGame)
        {
            rogAni.SetActive(true);
            rog.SetActive(true);
            rogG = GameObject.Find("Collector").GetComponent<RogMG>();
            rogG.pleaseRog();
        }
        else
        {
            rogAni.SetActive(false);
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
            oreAni.SetActive(true);
            ore.SetActive(true);
            oreG.pleaseShine();
        }
        else
        {
            oreAni.SetActive(false);
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

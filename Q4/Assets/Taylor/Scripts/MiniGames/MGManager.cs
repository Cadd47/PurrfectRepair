using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGManager : MonoBehaviour
{
    public GameObject wood;
    public GameObject stone;
    public GameObject ore;
    public GameObject fish;

    public int activateMiniGame;

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
            activateMiniGame++;
            CheckMG();
        }
    }

    private void CheckMG()
    {
        if (activateMiniGame % 2 == 1)
        {
            wood.SetActive(true);
        }

        if (activateMiniGame % 2 == 0)
        {
            wood.SetActive(false);
        }
    }
}

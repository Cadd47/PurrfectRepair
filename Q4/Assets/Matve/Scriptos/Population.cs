using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Population : MonoBehaviour
{
    public static int population;

    public GameObject winScreen;

    void Start()
    {
        population = 0;
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                winScreen.SetActive(true);
            }

            if (population >= 50)
            {
                winScreen.SetActive(true);
            }
        }
        catch
        {
            //shushhhhhhhhhh
        }
    }
}

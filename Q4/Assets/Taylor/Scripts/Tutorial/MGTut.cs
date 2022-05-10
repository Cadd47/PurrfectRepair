using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGTut : MonoBehaviour
{
    public GameObject[] Tut;
    public GameObject bigBoi;
    private int press = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            for (int i = 0; i < Tut.Length; i++)
            {
                Destroy(Tut[i].gameObject);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Tut[press].SetActive(false);
            press++;

            if (press >= Tut.Length)
            {
                for (int i = 0; i < Tut.Length; i++)
                {
                    bigBoi.SetActive(false);

                    press = 0;
                }
            }

            Tut[press].SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class One : MonoBehaviour
{
    public GameObject[] TutP1;

    public GameObject bigBoi;

    private int press = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TutP1[press].SetActive(false);
            press++;

            if (press >= TutP1.Length)
            {
                for (int i = 0; i < TutP1.Length; i++)
                {
                    bigBoi.SetActive(false);

                    press = 0;
                }
            }

            TutP1[press].SetActive(true);
        }
    }
}

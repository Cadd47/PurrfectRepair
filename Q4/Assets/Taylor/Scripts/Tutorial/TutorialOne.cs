using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialOne : MonoBehaviour
{
    public GameObject[] TutP1;

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
                press = 0;
            }

            TutP1[press].SetActive(true);
        }
    }
}

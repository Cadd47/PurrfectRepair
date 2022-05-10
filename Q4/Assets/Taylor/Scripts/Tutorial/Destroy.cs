using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private bool bye = false;

    void Update()
    {
        if (gameObject.activeInHierarchy && Input.GetKeyDown(KeyCode.Space))
        {
            bye = true;
        }

        if (bye)
        {
            gameObject.SetActive(false);
        }
    }
}

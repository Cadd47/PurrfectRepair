using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    void Update()
    {
        if (gameObject.activeInHierarchy && Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(gameObject);
        }
    }
}

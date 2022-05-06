using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaWood : MonoBehaviour
{
    public GameObject E;
    public bool hasPlayer;
    public static bool activateMG;
    private bool active;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && hasPlayer)
        {
            activateMG = !activateMG;
            active = !active;
        }

        if (activateMG)
        {
            if (Input.GetKeyDown(KeyCode.E) && !hasPlayer)
            {
                activateMG = !activateMG;
                active = !active;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && active)
        {
            activateMG = !activateMG;
            active = !active;
        }

        if (hasPlayer)
        {
            E.SetActive(true);
        }
        else
        {
            E.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider area)
    {
        if (area.CompareTag("Player"))
        {
            hasPlayer = true;
        }
    }

    private void OnTriggerExit(Collider area)
    {
        if (area.CompareTag("Player"))
        {
            hasPlayer = false;
        }
    }
}

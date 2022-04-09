using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingChecker : MonoBehaviour
{
    BuildingManager buildingManager;

    private int checkGood = 0;
    private int checkBad = 0;

    void Start()
    {
        buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
    }

    void Update()
    {
        if (buildingManager.selectedObject)
        {
            PlaceCheck();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void PlaceCheck()
    {
        //checks colliders
        Collider[] hitChecks = Physics.OverlapBox(transform.position, new Vector3(10, 50, 10), transform.rotation);
        foreach (Collider hitCollider in hitChecks)
        {
            if (hitCollider.gameObject.tag == "Building")
            {
                checkBad++;
                checkGood = 0;
            }
            else
            {
                checkGood++;
                checkBad = 0;
            }
        }

        if (checkGood > checkBad)
        {
            buildingManager.canPlace = true;
        }
        else
        {
            buildingManager.canPlace = false;
        }
    }
}
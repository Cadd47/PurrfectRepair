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
        if (buildingManager.check == true)
        {
            PlaceCheck();
        }

        if (buildingManager.check == false)
        {
            Destroy(gameObject);
        }
    }


    void PlaceCheck()
    {
        Collider[] hitChecks = Physics.OverlapBox(transform.position, new Vector3(10, 10, 10));

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
            //Debug.Log("Good");
            buildingManager.canPlace = true;
        }
        else
        {
            //Debug.Log("Bad");
            buildingManager.canPlace = false;
        }
    }
}
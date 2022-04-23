using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingChecker : MonoBehaviour
{
    BuildingManager buildingManager;

    private int checkGood = 0;
    private int checkBad = 0;

    private float timerCheck = 0.15f;

    void Start()
    {
        buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
    }

    void Update()
    {
        //Debug.Log("colTest: " + colTest);
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
            if (hitCollider.gameObject.tag == "Untagged")
            {
                checkGood++;
                checkBad = 0;

                timerCheck -= Time.deltaTime;
            }
            else
            {
                checkBad++;
                checkGood = 0;

                timerCheck = 0.15f;
            }
        }

        if (checkGood > checkBad)
        {
            if(timerCheck <= 0.0f)
            {
                buildingManager.canPlace = true;
            }
        }
        else
        {
            buildingManager.canPlace = false;
        }
    }
}
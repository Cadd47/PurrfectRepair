using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildChecker : MonoBehaviour
{

    BuildingManager BuildingManager;

    public Collider[] centerCollider;

    void Start()
    {
        BuildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
    }

    private void Update()
    {
        centerCollider = Physics.OverlapSphere(transform.position, 0.05f);
        if (centerCollider.Length < 0)
        {
            Debug.Log("In");
        }
        else
        {
            Debug.Log("Out");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Building"))
        {
            BuildingManager.canPlace = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Building"))
        {
            BuildingManager.canPlace = true;
        }
    }
}

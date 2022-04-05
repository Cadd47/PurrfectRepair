using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
    public GameObject[] structures;
    public GameObject selectedObject;
    public Material[] materials;
    public bool check = true;
    public bool canPlace = true;

    public Camera buildCamera;
    public float gridSize;

    Vector3 pos;
    public float rotateAmount;

    private RaycastHit hit;
    [SerializeField] private LayerMask layerMask;

    private void Update()
    {
        if(selectedObject != null)
        {
            selectedObject.GetComponent<Collider>();
            selectedObject.transform.position = new Vector3(RoundToGrid(pos.x), 5, RoundToGrid(pos.z));

            if (Input.GetMouseButtonDown(0) && canPlace)
            {
                PlaceObject();
            }

            if(Input.GetKeyDown(KeyCode.R))
            {
                RotateObject();
            }
        }

        UpdateMaterials();
    }

    private void FixedUpdate()
    {
        Ray ray = buildCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            pos = hit.point;
        }
    }

    public void SelectObject(int index)
    {
        check = true;
        selectedObject = Instantiate(structures[index], pos, transform.rotation);
    }

    public void RotateObject()
    {
        selectedObject.transform.Rotate(Vector3.up, rotateAmount);
    }

    void UpdateMaterials()
    {
        if (canPlace)
        {
            selectedObject.GetComponent<MeshRenderer>().material = materials[0];
        }
        else
        {
            selectedObject.GetComponent<MeshRenderer>().material = materials[1];
        }
    }

    public void PlaceObject()
    {
        selectedObject.GetComponent<MeshRenderer>().material = materials[2];

        check = false;
        selectedObject.GetComponent<Collider>().enabled = true;
        selectedObject = null;
    }

    float RoundToGrid(float pos)
    {
        float xDiff = pos % gridSize;
        pos -= xDiff;

        if (xDiff > (gridSize / 2))
        {
            pos += gridSize;
        }
        return pos;
    }
}

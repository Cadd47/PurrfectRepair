using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
    private Vector3 pos;

    public Camera buildingCamera;

    private RaycastHit hit;
    [SerializeField] private LayerMask layerMask;

    public GameObject[] objects;

    public GameObject selectedObject;
    public float gridSize;

    public bool canPlace = true;

    public float rotateAmount;

    [SerializeField] private Material[] materials;

    // Update is called once per frame
    void Update()
    {

        if(selectedObject != null)
        {
            selectedObject.transform.position = new Vector3(RoundToNearestGrid(pos.x), RoundToNearestGrid(pos.y), RoundToNearestGrid(pos.z));

            if (Input.GetMouseButtonDown(0) && canPlace)
            {
                PlaceObject();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                RotateObject();
            }

            UpdateMaterials();
        }
    }

    public void PlaceObject()
    {
        selectedObject.GetComponent<MeshRenderer>().material = materials[2];
        selectedObject = null;
    }

    public void RotateObject()
    {
        selectedObject.transform.Rotate(Vector3.up, rotateAmount);
    }

    private void FixedUpdate()
    {
        Ray ray = buildingCamera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            pos = hit.point;
        }
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

    public void SelectObject(int index)
    {
        selectedObject = Instantiate(objects[index], pos, transform.rotation);
    }

    float RoundToNearestGrid(float pos)
    {
        float xDiff = pos % gridSize;
        pos -= xDiff;
        if(xDiff > (gridSize / 2))
        {
            pos += gridSize;
        }
        return pos;
    }
}

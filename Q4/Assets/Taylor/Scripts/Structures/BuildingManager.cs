using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
    public GameObject[] structures;
    public GameObject selectedObject;
    private MeshRenderer renderer;

    public bool check = true;
    public bool canPlace = true;

    public Camera buildCamera;
    public float gridSize;

    Vector3 pos;
    public float rotateAmount;

    private RaycastHit hit;

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

        if (Physics.Raycast(ray, out hit))
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

    private void UpdateMaterials()
    {
        if (canPlace)
        {
            selectedObject.GetComponent<Renderer>().material.color = new Color(155/255f, 255/255f, 166/255f);
        }
        else
        {
            selectedObject.GetComponent<Renderer>().material.color = new Color(255/255f, 130/255f, 130/255f);
        }
    }

    public void PlaceObject()
    {
        selectedObject.GetComponent<Renderer>().material.color = Color.white;

        check = false;
        selectedObject.GetComponent<Collider>().enabled = true;
        selectedObject = null;
    }

    public float RoundToGrid(float pos)
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
    BuildingMenu buildingMenu;

    public GameObject[] structures;
    public GameObject selectedObject;
    public GameObject howToBuild;
    private MeshRenderer renderer;

    public bool cantSelect = false;
    public bool canPlace = true;

    public Camera buildCamera;
    public float gridSize;

    Vector3 pos;
    public float rotateAmount;
    public static float yCoord;

    private RaycastHit hit;

    void Start()
    {
        buildingMenu = GameObject.Find("BuildingManager").GetComponent<BuildingMenu>();
    }

    private void Update()
    {
        if(buildingMenu.editBuild == true)
        {
            try
            {
                if (selectedObject != null)
                {
                    selectedObject.GetComponent<Collider>().enabled = false;
                    selectedObject.transform.position = new Vector3(RoundToGrid(pos.x), yCoord, RoundToGrid(pos.z));
                    //Place
                    if (Input.GetMouseButtonDown(0) && canPlace)
                    {
                        PlaceObject();
                    }
                    //Rotate
                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        selectedObject.transform.Rotate(Vector3.up, rotateAmount);
                    }
                    //Trash
                    if (Input.GetKeyDown(KeyCode.T))
                    {
                        Destroy(selectedObject);
                        cantSelect = false;
                        selectedObject = null;
                    }
                }
                UpdateMaterials();
            }
            catch
            {
                //No more error lol
            }
        }

        if (Time.timeScale == 0f)
        {
            cantSelect = true;
        }
        if (Time.timeScale == 1f && selectedObject == null)
        {
            cantSelect = false;
        }
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
        if(cantSelect == false)
        {
            Cursor.visible = false;

            Destroy(howToBuild);
            selectedObject = Instantiate(structures[index], pos, transform.rotation);
            cantSelect = true;

            yCoord = selectedObject.transform.position.y * 4;
        }
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

        cantSelect = false;
        selectedObject = null;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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

    public void SmallBuildingY()
    {
        yCoord = 11.55f;
    }
    public void BigBuildingY()
    {
        yCoord = 16.55f;
    }
}
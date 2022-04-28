using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMove : MonoBehaviour
{
    BuildingManager buildingManager;
    BuildingMenu buildingMenu;

    Camera buildCamera;
    Vector3 pos;
    private RaycastHit hit;

    public GameObject colliderCheck;

    public bool hover;

    void Start()
    {
        buildCamera = GameObject.Find("BuildingCamera").GetComponent<Camera>();
        buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
        buildingMenu = GameObject.Find("BuildingManager").GetComponent<BuildingMenu>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && hover == true)
        {
            GameObject.Find("BuildingManager").GetComponent<BuildingManager>().selectedObject = gameObject;

            hover = false;
            buildingManager.cantSelect = true;
            Cursor.visible = false;

            BuildingManager.yCoord = gameObject.transform.position.y;

            colliderCheck.SetActive(true);
            gameObject.GetComponent<Collider>().enabled = false;
        }

        if(buildingManager.selectedObject == null)
        {
            gameObject.GetComponent<Collider>().enabled = true;
        }

        if(buildingMenu.editBuild == false)
        {
            GetComponent<Renderer>().material.color = Color.white;
            hover = false;
        }

        if(Time.timeScale == 0f)
        {
            hover = false;
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

    private void OnMouseEnter()
    {
        if (buildingManager.selectedObject == null && buildingMenu.editBuild == true)
        {
            GetComponent<Renderer>().material.color = new Color(177 / 255f, 188 / 255f, 255 / 255f);
            hover = true;
        }
    }

    private void OnMouseExit()
    {
        if (buildingManager.selectedObject == null && buildingMenu.editBuild == true)
        {
            GetComponent<Renderer>().material.color = Color.white;
            hover = false;
        }
    }
}
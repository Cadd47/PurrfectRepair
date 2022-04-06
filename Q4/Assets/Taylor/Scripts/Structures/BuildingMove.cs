using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMove : MonoBehaviour
{
    BuildingManager buildingManager;

    private MeshRenderer renderer;

    Camera buildCamera;
    Vector3 pos;
    private RaycastHit hit;

    public GameObject colChecker;
    public GameObject grabToMove;

    private bool hover;
    private bool moveBuilding = false;
    private int pick;

    void Start()
    {
        buildCamera = GameObject.Find("BuildingCamera").GetComponent<Camera>();
        buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && hover == true)
        {
            pick++;
            PickOrPlace();
        }

        if (moveBuilding == true)
        {
            this.transform.position = new Vector3(buildingManager.RoundToGrid(pos.x), 5, buildingManager.RoundToGrid(pos.z));
        }

        //UpdateMaterials();
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
        if (buildingManager.check == false)
        {
            grabToMove.SetActive(true);
            GetComponent<Renderer>().material.color = new Color(177 / 255f, 188 / 255f, 255 / 255f);

            hover = true;
        }
    }

    private void OnMouseExit()
    {
        if (buildingManager.check == false)
        {
            grabToMove.SetActive(false);
            GetComponent<Renderer>().material.color = Color.white;

            if(moveBuilding == false)
            {
                hover = false;
            }
        }
    }

    void PickOrPlace()
    {
        if (pick % 2 == 1)
        {
            PickObject();
        }

        if (pick % 2 == 0)
        {
            PutObject();
        }
    }

    public void PickObject()
    {
        //Debug.Log("pick");
        moveBuilding = true;

        colChecker.SetActive(true);
        this.gameObject.GetComponent<Collider>().enabled = false;
    }

    public void PutObject()
    {
        //Debug.Log("place");
        moveBuilding = false;

        colChecker.SetActive(false);
        this.gameObject.GetComponent<Collider>().enabled = true;
        this.gameObject.GetComponent<Renderer>().material.color = Color.white;
    }

    private void UpdateMaterials()
    {
        /*
        if (moveBuilding == true)
        {
            if ()
            {
                this.gameObject.GetComponent<Renderer>().material.color = new Color(155 / 255f, 255 / 255f, 166 / 255f);
            }
            else
            {
                this.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 130 / 255f, 130 / 255f);
            }
        }
        */
    }
}

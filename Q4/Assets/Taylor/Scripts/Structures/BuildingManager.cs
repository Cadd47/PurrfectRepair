using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildingManager : MonoBehaviour
{
    BuildingMenu buildingMenu;
    AutoTextDisable atd;

    public TextMeshProUGUI pointsGained;
    public Material[] materials;

    public GameObject[] structures;
    public GameObject selectedObject;
    private MeshRenderer renderer;

    public bool cantSelect = false;
    public bool canPlace = true;

    private bool one;
    private bool two;
    private bool three;

    public Camera buildCamera;
    public float gridSize;

    Vector3 pos;
    public float rotateAmount;

    private RaycastHit hit;

    void Start()
    {
        buildingMenu = GameObject.Find("BuildingManager").GetComponent<BuildingMenu>();
        atd = GameObject.Find("UpdateText").GetComponent<AutoTextDisable>();
        pointsGained.enabled = false;
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
                    selectedObject.transform.position = new Vector3(RoundToGrid(pos.x), 6.55f, RoundToGrid(pos.z));
                    //Place
                    if (Input.GetMouseButtonDown(0) && canPlace)
                    {
                        PlaceObject();
                    }
                    //Rotate
                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        FindObjectOfType<AudioManager>().Play("RotateBuild");

                        selectedObject.transform.Rotate(Vector3.up, rotateAmount);
                    }
                    //Trash
                    if (Input.GetKeyDown(KeyCode.T))
                    {
                        FindObjectOfType<AudioManager>().Play("TrashBuild");

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
            selectedObject = Instantiate(structures[index], pos, transform.rotation);
            cantSelect = true;

            if (selectedObject.name == "House_1(Clone)")
            {
                one = true;
                two = false;
                three = false;
            }
            if (selectedObject.name == "House_2(Clone)")
            {
                one = false;
                two = true;
                three = false;
            }
            if (selectedObject.name == "House_3(Clone)")
            {
                one = false;
                two = false;
                three = true;
            }
        }
    }

    private void UpdateMaterials()
    {
        if (canPlace)
        {
            selectedObject.transform.Find("Plane").GetComponent<Renderer>().material = materials[0];

        }
        else
        {
            selectedObject.transform.Find("Plane").GetComponent<Renderer>().material = materials[1];
        }
    }

    public void PlaceObject()
    {
        FindObjectOfType<AudioManager>().Play("PlaceBuild");

        selectedObject.GetComponent<Renderer>().material.color = Color.white;
        selectedObject.transform.Find("Plane").gameObject.SetActive(false);

        cantSelect = false;
        selectedObject = null;

        if (one)
        {
            pointsGained.text = "+3 cats";
            pointsGained.enabled = true;
            atd.yourMom.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            atd.FloatText();
            one = false;
        }
        if (two)
        {
            pointsGained.text = "+10 cats";
            pointsGained.enabled = true;
            atd.yourMom.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            atd.FloatText();
            two = false;
        }
        if (three)
        {
            pointsGained.text = "+6 cats";
            pointsGained.enabled = true;
            atd.yourMom.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            atd.FloatText();
            three = false;
        }
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

    //this for fixing the beginning orientation of da long building
    public void LongBoi()
    {
        selectedObject.transform.rotation = Quaternion.Euler(0, 360, 0);
    }
}
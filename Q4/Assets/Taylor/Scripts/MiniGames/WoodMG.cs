using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WoodMG : MonoBehaviour
{
    AreaWood areaWood;

    public GameObject tut;
    public GameObject woodEnd;

    public GameObject arrow;
    public Transform pointA;
    public Transform pointB;

    public float Speed;
    public float Amplitude;
    public float AmplitudeOffset;

    [Header("Resource Implementation")]

    public int currentPoints;
    public int maxPoints = 5;

    public int yield = 5;

    MGManager MGM;
    AutoTextDisable atd;
    MoveWood moveWood;

    public TextMeshProUGUI pointCounter;
    public TextMeshProUGUI pointsGained;

    private bool r = false;
    private bool o = false;
    private bool y = false;
    private bool g = false;
    private bool b = false;

    private void Start()
    {
        MGM = GameObject.Find("MiniGameManager").GetComponent<MGManager>();
        moveWood = GameObject.Find("MiniGameManager").GetComponent<MoveWood>();
        atd = GameObject.Find("UpdateText").GetComponent<AutoTextDisable>();
        areaWood = GameObject.Find("WoodSpawn").GetComponent<AreaWood>();
        pointsGained.enabled = false;
        tut.SetActive(true);
    }

    void Update()
    {
        pointCounter.text = currentPoints.ToString();

        transform.position = Vector3.Lerp(pointA.position, pointB.position, Mathf.Sin(Time.time * Speed) * Amplitude + AmplitudeOffset);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (r)
            {
                areaWood.disableMG();
                AreaWood.active = false;
                MGManager.woodGame = false;
                MGM.PleaseCheck();
            }
            if (o)
            {
                currentPoints += 0;
                pointsGained.text = "+0";
                pointsGained.enabled = true;
                atd.MGFloat();
            }
            if (y)
            {
                currentPoints += 1;
                pointsGained.text = "+1";
                pointsGained.enabled = true;
                atd.MGFloat();
            }
            if (g)
            {
                currentPoints += 2;
                pointsGained.text = "+2";
                pointsGained.enabled = true;
                atd.MGFloat();
            }
            if (b)
            {
                currentPoints += 4;
                pointsGained.text = "+4";
                pointsGained.enabled = true;
                atd.MGFloat();
            }
        }

        if(currentPoints >= maxPoints)
        {
            if (PlayerChecker.playerCheck)
            {
                woodEnd.SetActive(true);

                areaWood.disableMG();
                AreaWood.active = false;
                MGManager.woodGame = false;

                pointsGained.text = "+3 wood";
                pointsGained.enabled = true;
                atd.yourMom.color = new Color(0.588f, 0.882f, 0.588f, 1.0f);
                atd.FloatText();
                moveWood.Move();
                ResourceManager.woodCount += 3;
            }
            else
            {
                woodEnd.SetActive(true);

                areaWood.disableMG();
                AreaWood.active = false;
                MGManager.woodGame = false;

                pointsGained.text = "+6 wood";
                pointsGained.enabled = true;
                atd.yourMom.color = new Color(0.588f, 0.882f, 0.588f, 1.0f);
                atd.FloatText();
                moveWood.Move();
                ResourceManager.woodCount += 6;
            }

            currentPoints = 0;
            MGManager.woodGame = false;
            MGM.PleaseCheck();
        }
    }

    private void OnTriggerEnter(Collider arrow)
    {
        if (arrow.CompareTag("Red"))
        {
            r = true;
        }
        if (arrow.CompareTag("Orange"))
        {
            o = true;
        }
        if (arrow.CompareTag("Yellow"))
        {
            y = true;
        }
        if (arrow.CompareTag("Green"))
        {
            g = true;
        }
        if (arrow.CompareTag("Blue"))
        {
            b = true;
        }
    }

    private void OnTriggerExit(Collider arrow)
    {
        if (arrow.CompareTag("Red"))
        {
            r = false;
        }
        if (arrow.CompareTag("Orange"))
        {
            o = false;
        }
        if (arrow.CompareTag("Yellow"))
        {
            y = false;
        }
        if (arrow.CompareTag("Green"))
        {
            g = false;
        }
        if (arrow.CompareTag("Blue"))
        {
            b = false;
        }
    }
}

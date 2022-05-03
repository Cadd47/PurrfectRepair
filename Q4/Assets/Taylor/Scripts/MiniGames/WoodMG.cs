using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WoodMG : MonoBehaviour
{
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

    public TextMeshProUGUI pointCounter;
    public TextMeshProUGUI pointsGained;

    public GameObject MiniGame;

    private bool r = false;
    private bool o = false;
    private bool y = false;
    private bool g = false;
    private bool b = false;

    private void Start()
    {
        MGM = GameObject.Find("MiniGameManager").GetComponent<MGManager>();
        pointsGained.enabled = false;
    }

    void Update()
    {
        pointCounter.text = currentPoints.ToString();

        transform.position = Vector3.Lerp(pointA.position, pointB.position, Mathf.Sin(Time.time * Speed) * Amplitude + AmplitudeOffset);

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (r)
            {
                MGM.woodGame = false;
                MiniGame.SetActive(false);
            }
            if (o)
            {
                currentPoints += 0;
            }
            if (y)
            {
                currentPoints += 1;
            }
            if (g)
            {
                currentPoints += 2;
            }
            if (b)
            {
                currentPoints += 4;
            }
        }

        if(currentPoints >= maxPoints)
        {
            ResourceManager.woodCount += yield;
            pointsGained.text = "+" + yield.ToString() + " wood";
            pointsGained.enabled = true;
            currentPoints = 0;
            MGM.woodGame = false;
            MiniGame.SetActive(false);
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

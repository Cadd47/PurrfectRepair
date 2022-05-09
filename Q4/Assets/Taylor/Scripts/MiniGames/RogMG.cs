﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RogMG : MonoBehaviour
{
    AreaStone areaStone;

    public GameObject collector;
    public GameObject rogPrefab;

    Rigidbody rb;
    private float Speed = 2000f;

    [Header("Spawn Rog")]
    public GameObject bar;
    public GameObject min;
    public GameObject max;

    public float waitTime;
    public float rogTotal;

    public float collectedRog;

    [Header("Resource Implementation")]
    public int yield;

    public int currentPoints;
    public int maxPoints = 5;

    MGManager MGManager;
    AutoTextDisable atd;

    public TextMeshProUGUI pointCounter;
    public TextMeshProUGUI pointsGained;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        MGManager = GameObject.Find("MiniGameManager").GetComponent<MGManager>();
        areaStone = GameObject.Find("StoneSpawn").GetComponent<AreaStone>();
        atd = GameObject.Find("UpdateText").GetComponent<AutoTextDisable>();
        pointsGained.enabled = false;
    }

    public void Update()
    {
        if (currentPoints >= maxPoints)
        {
            if (PlayerChecker.playerCheck)
            {
                areaStone.disableMG();
                AreaStone.active = false;
                MGManager.rogGame = false;

                pointsGained.text = "+5 rock";
                pointsGained.enabled = true;
                atd.yourMom.color = new Color(1.0f, 0.5f, 0.5f, 1.0f);
                atd.FloatText();
                ResourceManager.stoneCount += 5;
            }
            else
            {
                areaStone.disableMG();
                AreaStone.active = false;
                MGManager.rogGame = false;

                pointsGained.text = "+2 rock";
                pointsGained.enabled = true;
                atd.yourMom.color = new Color(1.0f, 0.5f, 0.5f, 1.0f);
                atd.FloatText();
                ResourceManager.stoneCount += 2;
            }

            currentPoints = 0;
            MGManager.rogGame = false;
            MGManager.PleaseCheck();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(SpawnRog());
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(Speed, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-Speed, 0);
        }

        pointCounter.text = currentPoints.ToString();

        if (Rog.destroyed)
        {
            pointsGained.text = "+1";
            pointsGained.enabled = true;
            atd.MGFloat();
            Rog.destroyed = false;
        }
    }

    private void OnTriggerEnter(Collider collector)
    {
        if (collector.CompareTag("Stone"))
        {
            currentPoints++;
            collectedRog++;
        }
    }

    IEnumerator SpawnRog()
    {
        for (int i = 0; i < rogTotal; i++)
        {
            //Spawn positions
            float xPos = Random.Range(min.transform.position.x, max.transform.position.x);
            float yPos = Random.Range(min.transform.position.y, max.transform.position.y);
            Vector3 spawnPosition = new Vector3(xPos, yPos, 0f);

            //Choose object
            GameObject shiny = Instantiate(rogPrefab, spawnPosition, Quaternion.identity) as GameObject;
            shiny.transform.SetParent(bar.transform);
            shiny.transform.position = spawnPosition;

            yield return new WaitForSeconds(waitTime);
        }
    }
}
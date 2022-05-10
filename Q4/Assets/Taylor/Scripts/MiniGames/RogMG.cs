using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RogMG : MonoBehaviour
{
    AreaStone areaStone;
    MoveStone moveStone;

    public GameObject tut;
    public GameObject stoneEnd;

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
        moveStone = GameObject.Find("MiniGameManager").GetComponent<MoveStone>();
        areaStone = GameObject.Find("StoneSpawn").GetComponent<AreaStone>();
        atd = GameObject.Find("UpdateText").GetComponent<AutoTextDisable>();
        pointsGained.enabled = false;
        tut.SetActive(true);
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
                atd.yourMom.color = new Color(0.686f, 0.686f, 0.686f, 1.0f);
                atd.FloatText();
                moveStone.Move();
                ResourceManager.stoneCount += 5;

                stoneEnd.SetActive(true);
            }
            else
            {
                areaStone.disableMG();
                AreaStone.active = false;
                MGManager.rogGame = false;

                pointsGained.text = "+2 rock";
                pointsGained.enabled = true;
                atd.yourMom.color = new Color(0.686f, 0.686f, 0.686f, 1.0f);
                atd.FloatText();
                moveStone.Move();
                ResourceManager.stoneCount += 2;

                stoneEnd.SetActive(true);
            }

            currentPoints = 0;
            MGManager.rogGame = false;
            MGManager.PleaseCheck();
        }
        else
        {
            if (Rog.destroyed)
            {
                Rog.destroyed = false;
                pointsGained.text = "+1";
                pointsGained.enabled = true;
                atd.MGFloat();
            }
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
    }

    private void OnTriggerEnter(Collider collector)
    {
        if (collector.CompareTag("Stone"))
        {
            currentPoints++;
            collectedRog++;
        }
    }

    public void pleaseRog()
    {
        StartCoroutine(SpawnRog());
    }

    IEnumerator SpawnRog()
    {
        yield return new WaitForSeconds(1f);
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
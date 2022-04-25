using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RogMG : MonoBehaviour
{
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

    MGManager MGM;

    public TextMeshProUGUI pointCounter;
    public TextMeshProUGUI pointsGained;

    public GameObject minigame;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        MGM = GameObject.Find("MiniGameManager").GetComponent<MGManager>();
        pointsGained.enabled = false;
    }

    private void Update()
    {
        pointCounter.text = currentPoints.ToString() + "/" + maxPoints.ToString();

        if (currentPoints >= maxPoints)
        {
            pointsGained.text = "+" + yield.ToString() + " stone";
            pointsGained.enabled = true;
            ResourceManager.stoneCount += yield;
            currentPoints = 0;
            MGM.rogGame = false;
            minigame.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.P))
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
    }

    private void OnTriggerEnter(Collider collector)
    {
        if (collector.CompareTag("Stone"))
        {
            currentPoints++;
            collectedRog++;
            Debug.Log("Rog: " + collectedRog);
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
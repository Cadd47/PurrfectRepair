using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OreMG : MonoBehaviour
{
    public float waitTime;
    public float shinyTotal;

    public GameObject shinyPrefab;
    public GameObject panel;

    public GameObject min;
    public GameObject max;

    [Header("Resource Implementation")]
    public int currentPoints;
    public int maxPoints = 5;

    MGManager MGManager;

    public TextMeshProUGUI pointCounter;
    public TextMeshProUGUI pointsGained;

    private void Start()
    {
        MGManager = GameObject.Find("MiniGameManager").GetComponent<MGManager>();
        pointsGained.enabled = false;
    }

    void Update()
    {
        pointCounter.text = currentPoints.ToString();
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(SpawnShiny());
        }

        if(currentPoints >= maxPoints)
        {
            if (PlayerChecker.playerCheck)
            {
                pointsGained.text = "+1 shiny";
                pointsGained.enabled = true;
                ResourceManager.oreCount += 1;
            }
            else
            {
                pointsGained.text = "+3 shiny";
                pointsGained.enabled = true;
                ResourceManager.oreCount += 3;
            }

            currentPoints = 0;
            MGManager.oreGame = false;
            MGManager.PleaseCheck();
        }
    }

    IEnumerator SpawnShiny()
    {
        for (int i = 0; i < shinyTotal; i++)
        {
            //Spawn positions
            float xPos = Random.Range(min.transform.position.x, max.transform.position.x);
            float yPos = Random.Range(min.transform.position.y, max.transform.position.y);
            Vector3 spawnPosition = new Vector3(xPos, yPos, 0f);

            //Choose object
            GameObject shiny = Instantiate(shinyPrefab, spawnPosition, Quaternion.identity) as GameObject;
            shiny.transform.SetParent(panel.transform);
            shiny.transform.position = spawnPosition;

            yield return new WaitForSeconds(waitTime);
        }
    }
}
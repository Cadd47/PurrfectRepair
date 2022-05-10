using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OreMG : MonoBehaviour
{
    AreaOre areaOre;

    public GameObject tut;
    public GameObject oreEnd;

    public float waitTime;
    public float shinyTotal;

    public GameObject shinyPrefab;
    public GameObject panel;

    public GameObject min;
    public GameObject max;

    [Header("Resource Implementation")]
    public int currentPoints;
    public int maxPoints;

    MGManager MGManager;
    AutoTextDisable atd;
    MoveOre moveOre;

    public TextMeshProUGUI pointCounter;
    public TextMeshProUGUI pointsGained;

    private void Start()
    {
        MGManager = GameObject.Find("MiniGameManager").GetComponent<MGManager>();
        moveOre = GameObject.Find("MiniGameManager").GetComponent<MoveOre>();
        areaOre = GameObject.Find("OreSpawn").GetComponent<AreaOre>();
        atd = GameObject.Find("UpdateText").GetComponent<AutoTextDisable>();
        pointsGained.enabled = false;
        tut.SetActive(true);
    }

    void Update()
    {
        pointCounter.text = currentPoints.ToString();

        if (currentPoints >= maxPoints)
        {
            if (PlayerChecker.playerCheck)
            {
                areaOre.disableMG();
                AreaOre.active = false;
                MGManager.oreGame = false;

                pointsGained.text = "+1 ore";
                pointsGained.enabled = true;
                atd.yourMom.color = new Color(1.0f, 0.686f, 0.392f, 1.0f);
                atd.FloatText();
                moveOre.Move();
                ResourceManager.oreCount += 1;

                oreEnd.SetActive(true);
            }
            else
            {
                areaOre.disableMG();
                AreaOre.active = false;
                MGManager.oreGame = false;

                pointsGained.text = "+3 ore";
                pointsGained.enabled = true;
                atd.yourMom.color = new Color(1.0f, 0.686f, 0.392f, 1.0f);
                atd.FloatText();
                moveOre.Move();
                ResourceManager.oreCount += 3;

                oreEnd.SetActive(true);
            }

            currentPoints = 0;
            MGManager.oreGame = false;
            MGManager.PleaseCheck();
        }
        else
        {
            if (OreShiny.destroyed)
            {
                pointsGained.text = "+1";
                pointsGained.enabled = true;
                atd.OreFloat();
                OreShiny.destroyed = false;
            }
        }
    }

    public void pleaseShine()
    {
        StartCoroutine(SpawnShiny());
    }

    IEnumerator SpawnShiny()
    {
        yield return new WaitForSeconds(1f);

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
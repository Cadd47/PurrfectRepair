using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreMG : MonoBehaviour
{
    public float waitTime = 2;
    public float shinyTotal = 10;
    public GameObject shinyPrefab;
    public GameObject panel;

    float xMin = -220f;
    float xMax = 150f;
    float yMin = -50f;
    float yMax = 800f;

    void Start()
    {
        //StartCoroutine(SpawnShiny());
    }

    IEnumerator SpawnShiny()
    {
        for (int i = 0; i < shinyTotal; i++)
        {
            float xPos = Random.Range(xMin, xMax);
            float yPos = Random.Range(yMin, yMax);
            Vector3 spawnPosition = new Vector3(xPos, yPos, 0f);

            GameObject shiny = Instantiate(shinyPrefab, spawnPosition, Quaternion.identity) as GameObject;
            shiny.transform.parent = panel.transform;
            shiny.transform.position = spawnPosition;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
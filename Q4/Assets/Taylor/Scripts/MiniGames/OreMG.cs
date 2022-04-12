using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreMG : MonoBehaviour
{
    public float waitTime;
    public float shinyTotal;

    public GameObject shinyPrefab;
    public GameObject panel;

    public GameObject min;
    public GameObject max;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(SpawnShiny());
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
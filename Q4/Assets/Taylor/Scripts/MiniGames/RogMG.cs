using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
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
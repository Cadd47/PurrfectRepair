using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOre : MonoBehaviour
{
    public GameObject MG;
    public Transform[] spawnPoint;

    private int randPosition;

    public void Move()
    {
        randPosition = Random.Range(0, spawnPoint.Length);
        MG.transform.position = spawnPoint[randPosition].transform.position;
    }
}

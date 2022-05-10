using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnbabies : MonoBehaviour
{
    public GameObject Cat;
    public Transform spawn;
    Collider col;
    bool placed;
    // Start is called before the first frame update
    void Start()
    {
        col = gameObject.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (col.enabled && !placed)
        {
            AddChild();
            placed = true;
        }

    }

    void AddChild()
    {
        Instantiate(Cat, spawn);
    }

}

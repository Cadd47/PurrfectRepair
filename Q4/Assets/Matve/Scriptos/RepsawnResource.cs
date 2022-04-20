using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepsawnResource : MonoBehaviour
{
    public GameObject resource;
    public GameObject currentResource;
    public float timer;
    public float maxTime;
    public bool occupied;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!occupied)
        {
            if(timer <= maxTime)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0;
                currentResource = Instantiate(resource, gameObject.transform);
            }
        }
    }
}

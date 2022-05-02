using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDebug : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            ResourceManager.woodCount++;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            ResourceManager.stoneCount++;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            ResourceManager.oreCount++;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            ResourceManager.fishCount++;
        }
    }
}

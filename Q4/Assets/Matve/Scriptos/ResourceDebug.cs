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
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ResourceManager.woodCount++;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ResourceManager.stoneCount++;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ResourceManager.oreCount++;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ResourceManager.fishCount++;
        }
    }
}

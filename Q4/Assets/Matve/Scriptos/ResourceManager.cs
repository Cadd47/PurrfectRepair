using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public static int woodCount;
    public static int stoneCount;
    public static int fishCount;
    public static int oreCount;
    public static int witchStuff;

    private void Start()
    {
        woodCount = 0;
        stoneCount = 0;
        fishCount = 0;
        oreCount = 0;
        witchStuff = 0;
    }

    private void Update()
    {
        if(woodCount < 0)
        {
            woodCount = 0;
        }

        if (stoneCount < 0)
        {
            stoneCount = 0;
        }

        if (fishCount < 0)
        {
            fishCount = 0;
        }

        if (oreCount < 0)
        {
            oreCount = 0;
        }

        if (witchStuff < 0)
        {
            witchStuff = 0;
        }
    }
}

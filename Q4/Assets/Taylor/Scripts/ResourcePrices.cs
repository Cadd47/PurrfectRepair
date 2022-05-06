using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourcePrices : MonoBehaviour
{
    [Header("Building 1")]
    public TextMeshProUGUI woodOne;
    public TextMeshProUGUI stoneOne;
    [Header("Building 2")]
    public TextMeshProUGUI woodTwo;
    public TextMeshProUGUI oreOne;
    [Header("Building 3")]
    public TextMeshProUGUI stoneTwo;
    public TextMeshProUGUI oreTwo;
    [Header("AI Spawn")]
    public TextMeshProUGUI fishOne;
    public TextMeshProUGUI fishTwo;
    public TextMeshProUGUI fishThree;

    // Update is called once per frame
    void FixedUpdate()
    {
        //building 1
        woodOne.text = ResourceManager.woodCount.ToString() + "/8";
        stoneOne.text = ResourceManager.stoneCount.ToString() + "/6";
        //building 2
        woodTwo.text = ResourceManager.woodCount.ToString() + "/18";
        oreOne.text = ResourceManager.oreCount.ToString() + "/6";
        //building 3
        stoneTwo.text = ResourceManager.stoneCount.ToString() + "/20";
        oreTwo.text = ResourceManager.oreCount.ToString() + "/12";
        //ai spawner
        fishOne.text = ResourceManager.fishCount.ToString() + "/1";
        fishTwo.text = ResourceManager.fishCount.ToString() + "/1";
        fishThree.text = ResourceManager.fishCount.ToString() + "/2";

        if(ResourceManager.woodCount >= 8)
        {
            woodOne.color = new Color(0.588f, 0.882f, 0.588f, 1.0f);
        }
        else
        {
            woodOne.color = new Color(1.0f, 0.5f, 0.5f, 1.0f);
        }

        if (ResourceManager.woodCount >= 18)
        {
            woodTwo.color = new Color(0.588f, 0.882f, 0.588f, 1.0f);
        }
        else
        {
            woodTwo.color = new Color(1.0f, 0.5f, 0.5f, 1.0f);
        }

        if (ResourceManager.stoneCount >= 6)
        {
            stoneOne.color = new Color(0.686f, 0.686f, 0.686f, 1.0f);
        }
        else
        {
            stoneOne.color = new Color(1.0f, 0.5f, 0.5f, 1.0f);
        }

        if (ResourceManager.stoneCount >= 20)
        {
            stoneTwo.color = new Color(0.686f, 0.686f, 0.686f, 1.0f);
        }
        else
        {
            stoneTwo.color = new Color(1.0f, 0.5f, 0.5f, 1.0f);
        }

        if (ResourceManager.oreCount >= 6)
        {
            oreOne.color = new Color(1.0f, 0.686f, 0.392f, 1.0f);
        }
        else
        {
            oreOne.color = new Color(1.0f, 0.5f, 0.5f, 1.0f);
        }

        if (ResourceManager.oreCount >= 12)
        {
            oreTwo.color = new Color(1.0f, 0.686f, 0.392f, 1.0f);
        }
        else
        {
            oreTwo.color = new Color(1.0f, 0.5f, 0.5f, 1.0f);
        }

        if (ResourceManager.fishCount >= 1)
        {
            fishOne.color = new Color(0.588f, 0.882f, 1.0f, 1.0f);
            fishTwo.color = new Color(0.588f, 0.882f, 1.0f, 1.0f);
        }
        else
        {
            fishOne.color = new Color(1.0f, 0.5f, 0.5f, 1.0f);
            fishTwo.color = new Color(1.0f, 0.5f, 0.5f, 1.0f);
        }

        if (ResourceManager.fishCount >= 2)
        {
            fishThree.color = new Color(0.588f, 0.882f, 1.0f, 1.0f);
        }
        else
        {
            fishThree.color = new Color(1.0f, 0.5f, 0.5f, 1.0f);
        }
    }
}
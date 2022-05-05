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
    }
}

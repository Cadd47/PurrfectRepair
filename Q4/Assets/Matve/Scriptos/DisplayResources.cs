using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayResources : MonoBehaviour
{
    public TextMeshProUGUI wood;
    public TextMeshProUGUI stone;
    public TextMeshProUGUI fish;
    public TextMeshProUGUI ore;
    public TextMeshProUGUI witchStuff;

    void FixedUpdate()
    {
        wood.text = ResourceManager.woodCount.ToString();
        stone.text = ResourceManager.stoneCount.ToString();
        fish.text = ResourceManager.fishCount.ToString();
        ore.text = ResourceManager.oreCount.ToString();
    }
}

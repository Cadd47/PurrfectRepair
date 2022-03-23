using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayResources : MonoBehaviour
{
    public Text wood;
    public Text stone;
    public Text fish;
    public Text ore;
    public Text witchStuff;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        wood.text = ResourceManager.woodCount.ToString();
        stone.text = ResourceManager.stoneCount.ToString();
        fish.text = ResourceManager.fishCount.ToString();
        ore.text = ResourceManager.oreCount.ToString();
        witchStuff.text = ResourceManager.witchStuff.ToString();
    }
}

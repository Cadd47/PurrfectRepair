using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpendCurrency : MonoBehaviour
{
    public int woodCost;
    public int stoneCost;
    public int fishCost;
    public int oreCost;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spend()
    {
        ResourceManager.woodCount -= woodCost;
        ResourceManager.stoneCount -= stoneCost;
        ResourceManager.fishCount -= fishCost;
        ResourceManager.oreCount -= oreCost;
    }
}

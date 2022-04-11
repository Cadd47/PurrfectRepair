using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LimitTheBuy : MonoBehaviour
{
    public Button buy;
    public GameObject building;
    SpendCurrency SC;
    // Start is called before the first frame update
    void Start()
    {
        SC = building.GetComponent<SpendCurrency>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SC.woodCost > ResourceManager.woodCount || SC.stoneCost  > ResourceManager.stoneCount || SC.oreCost > ResourceManager.oreCount)
        {
            buy.interactable = false;
        }
        else
        {
            buy.interactable = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LimitTheBuyAI : MonoBehaviour
{
    public Button buyWood;
    public Button buyStone;
    public Button buyOre;
    public Button buyFish;
    SpawnAI SAI;
    // Start is called before the first frame update
    void Start()
    {
        SAI = GetComponent<SpawnAI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ResourceManager.woodCount <= SAI.wPrice)
        {
            buyWood.interactable = false;
        }
        else
        {
            buyWood.interactable = true;
        }

        if(ResourceManager.stoneCount <= SAI.sPrice)
        {
            buyStone.interactable = false;
        }
        else
        {
            buyStone.interactable = true;
        }
    }
}

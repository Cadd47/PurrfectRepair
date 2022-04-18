using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LimitTheBuyAI : MonoBehaviour
{
    public static int maxAI = 3;
    public static int currentAI;
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
        if(ResourceManager.woodCount <= SAI.wPrice && currentAI <= maxAI)
        {
            buyWood.interactable = false;
        }
        else
        {
            buyWood.interactable = true;
        }

        if(ResourceManager.stoneCount <= SAI.sPrice && currentAI <= maxAI)
        {
            buyStone.interactable = false;
        }
        else
        {
            buyStone.interactable = true;
        }

        if (ResourceManager.oreCount <= SAI.oPrice && currentAI <= maxAI)
        {
            buyOre.interactable = false;
        }
        else
        {
            buyOre.interactable = true;
        }

        if (ResourceManager.fishCount <= SAI.fPrice && currentAI <= maxAI)
        {
            buyFish.interactable = false;
        }
        else
        {
            buyFish.interactable = true;
        }
    }
}

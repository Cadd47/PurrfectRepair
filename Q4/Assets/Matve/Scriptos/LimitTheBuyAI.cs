using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LimitTheBuyAI : MonoBehaviour
{
    public static int maxAI;
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
        if(maxAI > 25)
        {
            maxAI = 25;
        }
        if (currentAI < maxAI)
        {
            if (ResourceManager.fishCount < SAI.wPrice)
            {
                buyWood.interactable = false;
            }
            else
            {
                buyWood.interactable = true;
            }

            if (ResourceManager.fishCount < SAI.sPrice)
            {
                buyStone.interactable = false;
            }
            else
            {
                buyStone.interactable = true;
            }

            if (ResourceManager.fishCount < SAI.oPrice)
            {
                buyOre.interactable = false;
            }
            else
            {
                buyOre.interactable = true;
            }
        }
        else
        {
            currentAI = maxAI;
            buyWood.interactable = false;
            buyStone.interactable = false;
            buyOre.interactable = false;
        }

    }
}

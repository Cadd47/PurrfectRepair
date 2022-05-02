using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CostDisplay : MonoBehaviour
{
    public int Cost;
    TextMeshProUGUI text;
    public string type;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(type == "wood")
        {
            text.text = ResourceManager.woodCount.ToString() + "/" + Cost.ToString();
        }

        if (type == "stone")
        {
            text.text = ResourceManager.stoneCount.ToString() + "/" + Cost.ToString();
        }

        if (type == "ore")
        {
            text.text = ResourceManager.oreCount.ToString() + "/" + Cost.ToString();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTouch : MonoBehaviour
{
    public string type;
    public int value;
    public int minVal;
    public int maxVal;
    AIMovement AIM;
    // Start is called before the first frame update
    void Start()
    {
        value = Random.Range(minVal, maxVal);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"|| other.gameObject.tag == "AI")
        {
            if (type == "wood")
            {
                ResourceManager.woodCount += value;
            }
            else if (type == "stone")
            {
                ResourceManager.stoneCount += value;
            }
            else if (type == "fish")
            {
                ResourceManager.fishCount += value;
            }
            else if (type == "ore")
            {
                ResourceManager.oreCount += value;
            }
            else if (type == "witchStuff")
            {
                ResourceManager.witchStuff += value;
            }
            AIM = other.gameObject.GetComponent<AIMovement>();
            AIM.target = null;
            Destroy(gameObject);
        }

    }
}

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
    ResourceCatalogue RC;
    // Start is called before the first frame update
    void Start()
    {
        RC = GameObject.FindWithTag("ResourceManager").GetComponent<ResourceCatalogue>();
        value = Random.Range(minVal, maxVal);
        if (type == "wood")
        {
            RC.wood.Add(gameObject);
        }
        else if (type == "stone")
        {
            RC.stone.Add(gameObject);
        }
        else if (type == "fish")
        {
            RC.fish.Add(gameObject);
        }
        else if (type == "ore")
        {
            RC.ore.Add(gameObject);
        }
        else if (type == "witchStuff")
        {
            RC.witchStuff.Add(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player"|| other.gameObject.tag == "AI")
        {
            
            if (type == "wood")
            {
                ResourceManager.woodCount += value;
                RC.wood.Remove(gameObject);
            }
            else if (type == "stone")
            {
                ResourceManager.stoneCount += value;
                RC.stone.Remove(gameObject);
            }
            else if (type == "fish")
            {
                ResourceManager.fishCount += value;
                RC.fish.Remove(gameObject);
            }
            else if (type == "ore")
            {
                ResourceManager.oreCount += value;
                RC.ore.Remove(gameObject);
            }
            else
            {
                ResourceManager.witchStuff += value;
                RC.witchStuff.Remove(gameObject);
            }
            AIM = other.gameObject.GetComponent<AIMovement>();
            AIM.stored++;
            AIM.target = null;
            Destroy(gameObject);
            
        }

    }

    
}

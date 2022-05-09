using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTouch : MonoBehaviour
{
    public RepsawnResource spawnParent;
    public string type;
    public int value;
    AIMovement AIM;
    ResourceCatalogue RC;
    // Start is called before the first frame update
    void Start()
    {
        spawnParent = GetComponentInParent<RepsawnResource>();
        spawnParent.currentResource = gameObject;
        spawnParent.occupied = true;
        RC = GameObject.FindWithTag("ResourceManager").GetComponent<ResourceCatalogue>();
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
        else
        {
            RC.witchStuff.Add(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "AI")
        {
            
            if (type == "wood")
            {
                
                RC.wood.Remove(gameObject);
            }
            else if (type == "stone")
            {
                
                RC.stone.Remove(gameObject);
            }
            else if (type == "fish")
            {
                
                RC.fish.Remove(gameObject);
            }
            else if (type == "ore")
            {
                
                RC.ore.Remove(gameObject);
            }
            else
            {
                
                RC.witchStuff.Remove(gameObject);
            }
            AIM = other.gameObject.GetComponent<AIMovement>();
            AIM.stored++;
            AIM.target = null;
            
            Destroy(gameObject);
            
        }
        else if(other.gameObject.tag == "Player")
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

            Destroy(gameObject);
        }

    }

    private void OnDestroy()
    {
        spawnParent.currentResource = null;
        spawnParent.occupied = false;
    }
}

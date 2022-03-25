using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    public int stored;
    public Transform target;
    public Transform home;
    NavMeshAgent agent;
    public ResourceCatalogue RC;
    public string huntType;
    public bool deployed;
    public bool returnHome;
    // Start is called before the first frame update
    void Start()
    {
            RC = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<ResourceCatalogue>();
            agent = GetComponent<NavMeshAgent>();
            home = GameObject.FindGameObjectWithTag("AIHome").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (deployed)
        {
            if (target == null && !returnHome)
            {
                int itemIndex;
                if (huntType == "wood")
                {
                    if (RC.wood.Count == 0)
                    {
                        target = null;
                        returnHome = true;
                    }
                    itemIndex = Random.Range(0, RC.wood.Count);
                    target = RC.wood[itemIndex].transform;
                }
                else if (huntType == "stone")
                {
                    if (RC.stone.Count == 0)
                    {
                        target = null;
                        returnHome = true;
                    }
                    itemIndex = Random.Range(0, RC.stone.Count);
                    target = RC.stone[itemIndex].transform;
                }
                else if (huntType == "fish")
                {
                    if (RC.fish.Count == 0)
                    {
                        target = null;
                        returnHome = true;
                    }
                    itemIndex = Random.Range(0, RC.fish.Count);
                    target = RC.fish[itemIndex].transform;
                }
                else if (huntType == "ore")
                {
                    if (RC.ore.Count == 0)
                    {
                        target = null;
                        returnHome = true;
                    }
                    itemIndex = Random.Range(0, RC.ore.Count);
                    target = RC.ore[itemIndex].transform;
                }
                else
                {
                    if (RC.witchStuff.Count == 0)
                    {
                        target = null;
                        returnHome = true;
                    }
                    itemIndex = Random.Range(0, RC.witchStuff.Count);
                    target = RC.witchStuff[itemIndex].transform;
                }
            }
            if (returnHome)
            {
                target = home;
            }

            if (stored >= 10)
            {
                returnHome = true;
            }

            GoToResource();
        }

    }

    void GoToResource()
    {
        agent.SetDestination(target.position);
    }
}

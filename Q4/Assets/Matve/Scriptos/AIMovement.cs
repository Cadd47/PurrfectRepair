﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    float Timer = 1.0f;
    float daTime;

    public int stored;
    public int maxStored;
    public Transform target;
    public Transform home;
    NavMeshAgent agent;
    public ResourceCatalogue RC;
    public string huntType;
    public bool deployed;
    public bool returnHome;

    ResourceManager RM;
    // Start is called before the first frame update
    void Start()
    {
        RM = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<ResourceManager>();
        RC = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<ResourceCatalogue>();
        agent = GetComponent<NavMeshAgent>();
        home = GameObject.FindGameObjectWithTag("AIHome").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (deployed)
        {
            daTime = 0;
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

            if (stored >= maxStored)
            {
                returnHome = true;
            }

            GoToResource();
        }
        else
        {
            if(Timer <= daTime)
            {
                Timer += Time.deltaTime;
            }
            else
            {
                deployed = true;
            }
        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "AIHome")
        {
            deployed = false;
            if (huntType == "wood")
            {
                ResourceManager.woodCount += stored;
                stored = 0;
            }
            else if (huntType == "stone")
            {
                ResourceManager.stoneCount += stored;
                stored = 0;

            }
            else if (huntType == "fish")
            {
                ResourceManager.fishCount += stored;
                stored = 0;
            }
            else if (huntType == "ore")
            {
                ResourceManager.oreCount += stored;
                stored = 0;
            }
            else
            {
                ResourceManager.witchStuff += stored;
                stored = 0;
            }
            if(LimitTheBuyAI.currentAI <= LimitTheBuyAI.maxAI)
            {
                target = null;
                returnHome = false;
                
            }
            else
            {
                Destroy(gameObject);
                LimitTheBuyAI.currentAI--;
            }
        }
    }

    void GoToResource()
    {
        agent.SetDestination(target.position);
    }
}

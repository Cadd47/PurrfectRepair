using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;
    public ResourceCatalogue RC;
    public string huntType;
    public bool deployed;
    // Start is called before the first frame update
    void Start()
    {
            RC = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<ResourceCatalogue>();
            agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            
        }
        GoToResource();
    }

    void GoToResource()
    {
        agent.SetDestination(target.position);
    }
}

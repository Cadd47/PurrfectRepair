using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;
    public ResourceCatalogue RC;
    // Start is called before the first frame update
    void Start()
    {
            agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        GoToResource();
    }

    void GoToResource()
    {
        agent.SetDestination(target.position);
    }
}

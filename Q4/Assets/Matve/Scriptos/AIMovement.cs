using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Wood").GetComponent<Transform>();
            agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("Wood").GetComponent<Transform>();
        }
    }
}

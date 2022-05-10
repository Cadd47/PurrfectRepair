using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wander : MonoBehaviour
{
    public GameObject walking;
    public GameObject idle;

    Transform t;

    public float wanderRadius;
    public float wanderTimer;

    public string aa;

    private Vector3 target;
    private NavMeshAgent agent;
    public float timer;

    // Use this for initialization
    void OnEnable()
    {
        t = GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;

        
    }

    // Update is called once per frame
    void Update()
    {
        aa = target.ToString();

        timer += Time.deltaTime;

        if(t.position.x == target.x && t.position.z == target.z)
        {
            if(timer <= wanderTimer)
            {
                walking.SetActive(false);
                idle.SetActive(true);
            }

        }

        if (timer >= wanderTimer)
        {
            walking.SetActive(true);
            idle.SetActive(false);
            target = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(target);
            timer = 0;
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}
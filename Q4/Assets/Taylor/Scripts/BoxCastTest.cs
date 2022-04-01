using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCastTest : MonoBehaviour
{
    bool m_HitDetect;

    Collider m_Collider;
    RaycastHit m_Hit;

    void Start()
    {
        m_Collider = GetComponent<Collider>();
    }

    void FixedUpdate()
    {
        //Test to see if there is a hit using a BoxCast
        //Calculate using the center of the GameObject's Collider(could also just use the GameObject's position), half the GameObject's size, the direction, the GameObject's rotation, and the maximum distance as variables.
        //Also fetch the hit data
        m_HitDetect = Physics.BoxCast(m_Collider.bounds.center, transform.localScale, transform.forward, out m_Hit, transform.rotation);
        if (m_HitDetect)
        {
            Debug.Log("Clear");
        }
        else
        {
            Debug.Log("Hit");
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        if (m_HitDetect)
        {
            Gizmos.DrawRay(transform.position, transform.forward * m_Hit.distance);
        }
        else
        {
            Gizmos.DrawRay(transform.position, transform.forward);
        }
    }
}
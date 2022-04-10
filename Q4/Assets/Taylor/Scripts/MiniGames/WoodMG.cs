using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodMG : MonoBehaviour
{
    public GameObject arrow;
    public Transform pointA;
    public Transform pointB;

    public float Speed;
    public float Amplitude;
    public float AmplitudeOffset;

    private bool r = false;
    private bool o = false;
    private bool y = false;
    private bool g = false;
    private bool b = false;

    void Update()
    {
        transform.position = Vector3.Lerp(pointA.position, pointB.position, Mathf.Sin(Time.time * Speed) * Amplitude + AmplitudeOffset);

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (r)
            {
                Debug.Log("r");
            }
            if (o)
            {
                Debug.Log("o");
            }
            if (y)
            {
                Debug.Log("y");
            }
            if (g)
            {
                Debug.Log("g");
            }
            if (b)
            {
                Debug.Log("b");
            }
        }
    }

    private void OnTriggerEnter(Collider arrow)
    {
        if (arrow.CompareTag("Red"))
        {
            r = true;
        }
        if (arrow.CompareTag("Orange"))
        {
            o = true;
        }
        if (arrow.CompareTag("Yellow"))
        {
            y = true;
        }
        if (arrow.CompareTag("Green"))
        {
            g = true;
        }
        if (arrow.CompareTag("Blue"))
        {
            b = true;
        }
    }

    private void OnTriggerExit(Collider arrow)
    {
        if (arrow.CompareTag("Red"))
        {
            r = false;
        }
        if (arrow.CompareTag("Orange"))
        {
            o = false;
        }
        if (arrow.CompareTag("Yellow"))
        {
            y = false;
        }
        if (arrow.CompareTag("Green"))
        {
            g = false;
        }
        if (arrow.CompareTag("Blue"))
        {
            b = false;
        }
    }
}

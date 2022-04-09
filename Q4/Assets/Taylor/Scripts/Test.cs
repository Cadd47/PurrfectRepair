using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform cam; //put the camera in here

    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}

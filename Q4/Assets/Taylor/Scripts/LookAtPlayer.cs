using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform cam;

    void LateUpdate()
    {
        try
        {
            transform.LookAt(transform.position + cam.forward);
        }
        catch
        {
            //shut up dumb camera
        }
    }
}

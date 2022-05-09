using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public ActivePlayer AP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (AP.isP1)
            {
                AP.isP1 = false;
            }
            else
            {
                AP.isP1 = true;
            }
        }
    }
}

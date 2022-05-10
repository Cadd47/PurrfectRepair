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
            if (ActivePlayer.isP1)
            {
                ActivePlayer.isP1 = false;
            }
            else
            {
                ActivePlayer.isP1 = true;
            }
        }
    }
}

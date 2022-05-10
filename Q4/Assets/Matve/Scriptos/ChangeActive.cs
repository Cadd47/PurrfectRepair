using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeActive : MonoBehaviour
{
    public bool p1;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (p1)
        {
            ActivePlayer.isP1 = true;
        }
        else
        {
            ActivePlayer.isP1 = false;
        }
    }
}

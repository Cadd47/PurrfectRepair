using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePlayer : MonoBehaviour
{
    public GameObject P1;
    public GameObject P2;
    public bool isP1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isP1)
        {
            P1.SetActive(true);
            P2.SetActive(false);
        }
        else
        {
            P1.SetActive(false);
            P2.SetActive(true);
        }
    }
}

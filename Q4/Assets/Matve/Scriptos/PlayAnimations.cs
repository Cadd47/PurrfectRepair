using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimations : MonoBehaviour
{
    PlayerMovement PM;

    public GameObject idle;
    public GameObject walk;
    public GameObject run;

    // Start is called before the first frame update
    void Start()
    {
        PM = gameObject.GetComponent<PlayerMovement>();
        idle.SetActive(true);
        walk.SetActive(false);
        run.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PM.enabled == false)
        {
            idle.SetActive(true);
            walk.SetActive(false);
            run.SetActive(false);
        }
        else
        {
            if (PM.isIdle && !PM.isWalking && !PM.isRunning)
            {
                idle.SetActive(true);
                walk.SetActive(false);
                run.SetActive(false);
            }
            else if (!PM.isIdle && PM.isWalking && !PM.isRunning)
            {
                idle.SetActive(false);
                walk.SetActive(true);
                run.SetActive(false);
            }
            else if (!PM.isIdle && !PM.isWalking && PM.isRunning)
            {
                idle.SetActive(false);
                walk.SetActive(false);
                run.SetActive(true);
            }
        }
    }

}

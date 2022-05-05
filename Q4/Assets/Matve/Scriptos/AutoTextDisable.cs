using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AutoTextDisable : MonoBehaviour
{
    public TextMeshProUGUI yourMom;
    public float timeNow;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        yourMom = gameObject.GetComponent<TextMeshProUGUI>();
        yourMom.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (yourMom.enabled)
        {
            if(timer <= timeNow)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0;
                yourMom.enabled = false;
            }
        }
    }
}

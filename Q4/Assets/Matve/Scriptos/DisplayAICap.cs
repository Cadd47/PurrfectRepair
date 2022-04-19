using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayAICap : MonoBehaviour
{
    public TextMeshProUGUI aiText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        aiText.text = LimitTheBuyAI.currentAI.ToString() + "/" + LimitTheBuyAI.maxAI.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPopulation : MonoBehaviour
{
    public int AIvalue;
    public int value;
    Collider col;
    bool placed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(col.enabled && !placed)
        {
            AddPop();
            placed = true;
        }
        
    }

    public void AddPop()
    {
        LimitTheBuyAI.maxAI += AIvalue;
        Population.population += value;
    }

    public void RemovePop()
    {
        LimitTheBuyAI.maxAI += AIvalue;
        Population.population -= value;
    }

    private void OnDestroy()
    {
        RemovePop();
    }
}

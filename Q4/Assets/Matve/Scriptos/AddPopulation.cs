using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPopulation : MonoBehaviour
{
    public int value;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPop()
    {
        Population.population += value;
    }

    public void RemovePop()
    {
        Population.population -= value;
    }
}

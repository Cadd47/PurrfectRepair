using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayPopulation : MonoBehaviour
{
    public TextMeshProUGUI populationText;
    public int winCond;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        populationText.text = Population.population.ToString() + "/" + winCond;
    }
}

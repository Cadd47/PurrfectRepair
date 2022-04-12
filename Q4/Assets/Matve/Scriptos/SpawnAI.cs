using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAI : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject woodHunt;
    public GameObject stoneHunt;
    public GameObject oreHunt;
    public GameObject fishHunt;
    public int wPrice;
    public int sPrice;
    public int oPrice;
    public int fPrice;
    //public GameObject witchHunt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnWood()
    {
        ResourceManager.fishCount -= wPrice;
        Instantiate(woodHunt, spawnPoint);
    }
    public void spawnStone()
    {
        ResourceManager.fishCount -= sPrice;
        Instantiate(stoneHunt, spawnPoint);
    }
    public void spawnOre()
    {
        ResourceManager.fishCount -= oPrice;
        Instantiate(oreHunt, spawnPoint);
    }
    public void spawnFish()
    {
        ResourceManager.fishCount -= fPrice;
        Instantiate(fishHunt, spawnPoint);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMaterial : MonoBehaviour
{
    int selectedColor;

    public Material catSkin1;
    public Material catSkin2;
    public Material catSkin3;

    public SkinnedMeshRenderer walk;
    public SkinnedMeshRenderer idle;
    // Start is called before the first frame update
    void Start()
    {
        selectedColor = Random.Range(1, 3);
        if(selectedColor == 1)
        {
            walk.material = catSkin1;
            idle.material = catSkin1;
        }
        else if(selectedColor == 2)
        {
            walk.material = catSkin2;
            idle.material = catSkin2;
        }
        else
        {
            walk.material = catSkin3;
            idle.material = catSkin3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

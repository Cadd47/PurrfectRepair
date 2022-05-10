using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeRandom : MonoBehaviour
{
    public float min;
    public float max;
    float size;
    Transform tf;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        size = Random.Range(min, max);
        tf.localScale =  new Vector3(size, size, size);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreShiny : MonoBehaviour
{
    Vector3 minScale;
    private Vector3 maxScale;
    private float duration = 5;

    IEnumerator Start()
    {
        minScale = transform.localScale;
        yield return (ScaleShiny(minScale, maxScale, duration));
    }

    IEnumerator ScaleShiny(Vector3 a, Vector3 b, float time)
    {
        int speed = Random.Range(2, 5);

        float i = 0.0f;
        float rate = (1.0f / time) * speed;

        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(a, b, i);
            yield return null;
        }
        Destroy();
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}

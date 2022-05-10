using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OreShiny : MonoBehaviour
{
    Vector3 minScale;
    private Vector3 maxScale;
    private float duration = 5;

    public static bool destroyed;

    GameObject minigame;

    OreMG ORMG;

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
        DestroyOther();
    }

    void Destroy()
    {
        minigame = GameObject.Find("OreMG");
        ORMG = minigame.GetComponent<OreMG>();
        ORMG.currentPoints++;
        destroyed = true;
        Destroy(gameObject);
    }

    void DestroyOther()
    {
        Destroy(gameObject);
    }
}

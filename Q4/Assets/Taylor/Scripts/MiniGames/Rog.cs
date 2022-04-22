using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rog : MonoBehaviour
{
    Vector3 startPos;
    Vector3 endPos;
    private float duration = 5f;
    public float distance;

    IEnumerator Start()
    {
        startPos = transform.position;
        endPos = transform.position + Vector3.down * distance;
        yield return (RogFall(startPos, endPos, duration));
    }

    private void OnTriggerEnter(Collider gameObject)
    {
        if (gameObject.CompareTag("Collector"))
        {
            Destroy();
        }
    }

    IEnumerator RogFall(Vector3 a, Vector3 b, float time)
    {
        float speed = Random.Range(2f, 3.5f);
        float i = 0.0f;
        float rate = (1.0f / time) * speed;

        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            transform.position = Vector3.Lerp(a, b, i);
            yield return null;
        }
        Destroy();
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}

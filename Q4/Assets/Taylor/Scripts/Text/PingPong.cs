using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPong : MonoBehaviour
{
    private float tweenTime = 0.5f;

    private void Start()
    {
        transform.localScale = Vector3.one;
        LeanTween.scale(gameObject, Vector3.one * 1.1f, tweenTime).setLoopPingPong();
    }

    public void hover()
    {
        LeanTween.scale(gameObject, Vector3.one * 1.1f, tweenTime).setLoopPingPong();
    }
}

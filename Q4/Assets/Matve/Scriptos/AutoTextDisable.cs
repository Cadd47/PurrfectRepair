using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AutoTextDisable : MonoBehaviour
{
    public TextMeshProUGUI yourMom;
    public float timeNow;
    public float timer;
    public float duration;
    private float t;

    // Start is called before the first frame update
    void Start()
    {
        yourMom = gameObject.GetComponent<TextMeshProUGUI>();
        yourMom.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (yourMom.enabled)
        {
            if(timer <= timeNow)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0;
                yourMom.enabled = false;
            }
        }
    }

    public void FloatText()
    {
        t = 0;
        timer = 0;
        yourMom.color = new Color(1f, 1f, 1f, 1.0f);
        transform.localPosition = new Vector2(0, 100);
        transform.LeanMoveLocal(new Vector2(0, 300), 1f).setEaseInQuad();
        StartCoroutine(Fade());
    }

    public void MGFloat()
    {
        t = 0;
        timer = 0;
        yourMom.color = new Color(1f, 0.96f, 0.619f, 1.0f);
        transform.localPosition = new Vector2(0, -240);
        StartCoroutine(MGFade());
    }

    public void OreFloat()
    {
        t = 0;
        timer = 0;
        yourMom.color = new Color(1f, 0.96f, 0.619f, 1.0f);
        transform.localPosition = new Vector2(465, 345);
        StartCoroutine(MGFade());
    }

    IEnumerator Fade()
    {
        yield return new WaitForSeconds(3f);

        while (t < 1)
        {
            yourMom.color = Color.Lerp(new Color(1f, 1f, 1f, 1.0f), new Color(1f, 1f, 1f, 0f), t);
            t += Time.deltaTime / duration;
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator MGFade()
    {
        yield return new WaitForSeconds(1f);

        while (t < 1)
        {
            yourMom.color = Color.Lerp(new Color(1f, 1f, 1f, 1.0f), new Color(1f, 1f, 1f, 0f), t);
            t += Time.deltaTime / duration;
            yield return new WaitForEndOfFrame();
        }
    }
}

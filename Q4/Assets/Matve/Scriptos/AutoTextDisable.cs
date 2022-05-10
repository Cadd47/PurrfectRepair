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
    private float y;

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
        y = 0;
        t = 1;
        timer = 0;
        //yourMom.color = new Color(1f, 1f, 1f, 1.0f);
        transform.localPosition = new Vector2(0, 100);
        StartCoroutine(Fade());
    }

    public void MGFloat()
    {
        y = 1;
        t = 0;
        timer = 0;
        yourMom.color = new Color(1f, 0.96f, 0.619f, 1.0f);
        transform.localPosition = new Vector2(0, -240);
        StartCoroutine(MGFade());
    }

    public void OreFloat()
    {
        y = 1;
        t = 0;
        timer = 0;
        yourMom.color = new Color(1f, 0.96f, 0.619f, 1.0f);
        transform.localPosition = new Vector2(465, 345);
        StartCoroutine(MGFade());
    }

    IEnumerator Lean()
    {
        yield return new WaitForSeconds(0.75f);
        transform.LeanMoveLocal(new Vector2(0, 300), 1f).setEaseInQuad();
    }

    IEnumerator Fade()
    {
        StartCoroutine(Lean());
        yield return new WaitForSeconds(1f);

        while (y < 1)
        {
            yourMom.color = Color.Lerp(new Color(1f, 1f, 1f, 1.0f), new Color(1f, 1f, 1f, 0f), y);
            y += Time.deltaTime / duration;
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator MGFade()
    {
        yield return new WaitForSeconds(0.2f);

        while (t < 1)
        {
            yourMom.color = Color.Lerp(new Color(1f, 0.96f, 0.619f, 1.0f), new Color(1f, 0.96f, 0.619f, 0f), t);
            t += Time.deltaTime / duration;
            yield return new WaitForEndOfFrame();
        }
    }
}

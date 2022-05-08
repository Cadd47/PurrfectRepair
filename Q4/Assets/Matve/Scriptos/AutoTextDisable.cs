using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AutoTextDisable : MonoBehaviour
{
    public TextMeshProUGUI yourMom;
    public CanvasGroup background;
    public float timeNow;
    public float timer;

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
        yourMom.color = Color.Lerp(new Color(1f, 0.96f, 0.619f, 1.0f), new Color(1f, 0.96f, 0.619f, 0f), Time.deltaTime);

        transform.localPosition = new Vector2(0, 250);
        transform.LeanMoveLocal(new Vector2(0, 400), 0.5f).setEaseLinear();
        timer = 0;
    }
}

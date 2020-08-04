using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    public float screenFadeSpeed = 0.01f;
    public float startDelay = 0.01f;
    public Image panel;
    public Color color = Color.black;

    public bool IsScreenClear { get; private set; }
    public bool IsScreenSolid { get; private set; }

    void Awake()
    {
        color = new Color(color.r, color.g, color.b, 1);
    }

    // Update is called once per frame
    void Update()
    {
        panel.color = color;

        if (color.a <= 0)
        {
            IsScreenClear = true;
        }
        else if (color.a > 0 && color.a < 1)
        {
            IsScreenClear = false;
            IsScreenSolid = false;
        }
        else if (color.a >= 1)
        {
            IsScreenSolid = true;
        }
    }

    public void CallScreenFadeToSolidCouroutine()
    {
        StartCoroutine(DelayFade(ScreenFadeToSolid()));
    }

    public void CallScreenFadeToClearCouroutine()
    {
        StartCoroutine(DelayFade(ScreenFadeToClear()));
    }

    private IEnumerator DelayFade(IEnumerator delayedCoroutine)
    {
        yield return new WaitForSeconds(startDelay);
        StartCoroutine(delayedCoroutine);
    }

    private IEnumerator ScreenFadeToSolid()
    {
        color = new Color(color.r, color.g, color.b, 0);

        float a = color.a;

        for (float i = 0; i <= 1; i += screenFadeSpeed)
        {
            a += screenFadeSpeed;
            yield return new WaitForSecondsRealtime(screenFadeSpeed);
            color = new Color(color.r, color.g, color.b, a);
        }

        color = new Color(color.r, color.g, color.b, 1);
    }

    private IEnumerator ScreenFadeToClear()
    {
        color = new Color(color.r, color.g, color.b, 1);

        float a = color.a;

        for (float i = 1; i >= 0; i -= screenFadeSpeed)
        {
            a -= screenFadeSpeed;
            yield return new WaitForSecondsRealtime(screenFadeSpeed);
            color = new Color(color.r, color.g, color.b, a);
        }

        color = new Color(color.r, color.g, color.b, 0);
    }
}

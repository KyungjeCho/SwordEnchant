using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClosePanelUI : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 endPos;
    public float speed = 1f;

    public Interpolate.Function interpolate_Func = Interpolate.Ease(Interpolate.EaseType.EaseOutCirc);

    public void OpenPanel()
    {
        StartCoroutine(CoOpenPanel());
    }

    public void ClosePanel()
    {
        StartCoroutine(CoClosePanel());
    }
    IEnumerator CoOpenPanel()
    {
        float timer = 0.0f;

        while (timer < 1f)
        {
            timer += speed * Time.unscaledTime;
            //transform.localPosition = Vector3.Lerp(startPos, endPos, timer);
            transform.localPosition = Interpolate.Ease(this.interpolate_Func, startPos, endPos - startPos, timer, 1f);
            yield return null;
        }
    }

    IEnumerator CoClosePanel()
    {
        float timer = 0.0f;

        while (timer < 1f)
        {
            timer += speed * Time.unscaledTime;
            //transform.localPosition = Vector3.Lerp(endPos, startPos, timer);
            transform.localPosition = Interpolate.Ease(this.interpolate_Func, endPos, startPos - endPos, timer, 1f);
            yield return null;
        }
    }
}

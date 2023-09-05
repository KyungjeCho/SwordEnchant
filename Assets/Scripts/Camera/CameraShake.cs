using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    #region Variables
    public bool start = false;
    public AnimationCurve curve;
    public float duration = 1f;

    #endregion Variables

    // Start is called before the first frame update
    private void Update()
    {
        if (start)
        {
            start = false;
            StartCoroutine(Shake());
        }
    }

    public void ShakeEff()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        Vector3 startPos = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.unscaledDeltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            transform.position = startPos + Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.position = startPos;
    }
}

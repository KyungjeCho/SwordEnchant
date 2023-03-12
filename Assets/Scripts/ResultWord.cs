using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultWord : MonoBehaviour
{

    public float minSize = 0.7f;
    public float maxSize = 2.0f;
    public float delta = 0.1f;
    public float timeIndex = 0.1f;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ShowResult()
    {
        StartCoroutine(MakeBigCoroutine());

        spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
    }

    public void BlindResult()
    {
        spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
    }

    IEnumerator MakeBigCoroutine()
    {
        float currentSize = minSize;
        while(currentSize < maxSize)
        {
            transform.localScale = new Vector3(currentSize, currentSize, 0);
            currentSize += delta;
            yield return new WaitForSeconds(timeIndex);
        }
        yield return null;
    }
}

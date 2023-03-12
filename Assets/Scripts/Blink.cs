using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{  
    float alpha;
    float timer = 0f;

    public float duration = 2f;

    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        Reset();
    }

    public void BlinkAnim()
    {
        if (timer > duration)   
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            int playerLayer = LayerMask.NameToLayer("Player");
            gameObject.layer = playerLayer;
            return;
        }

        if (alpha < 0.5f)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 0.7f - alpha);
        }
        else if (alpha < 1f)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, alpha - 0.3f);
        }
        else
        {
            alpha = 0f;
        }

        alpha += Time.deltaTime;
        timer += Time.deltaTime;
    }

    public void Reset()
    {
        alpha = 0f;
        timer = 0f;
    }
}

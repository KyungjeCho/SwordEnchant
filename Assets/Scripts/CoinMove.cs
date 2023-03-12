using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMove : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Vector2 p1;
    public Vector2 p2;

    float timer = 0f;
    float F_timer = 1f;
    float alpha = 0f;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(CoinFadeOut());
        Destroy(this.gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        p1 = Vector2.MoveTowards(p1, p2, Time.deltaTime * 10f);
        transform.position = Vector2.MoveTowards(transform.position, p1, Time.deltaTime * 10f);
    }

    IEnumerator CoinFadeOut()
    {
        while(alpha < 1f)
        {
            timer += Time.deltaTime / F_timer;
            alpha = Mathf.Lerp(1, 0, timer);
            spriteRenderer.color = new Color(1, 1, 1, alpha);
            yield return null;
        }
        yield return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyText : MonoBehaviour
{
    private Vector3 dir;
    
    private float time;
    private float alpha = 3f;

    public float sizeMin = 0f;
    public float sizeMax = 1f;
    public float currentSize = 0f;

    private TextMeshProUGUI Text;

    void Start()
    {
        Reset();
        Destroy(this.gameObject, 3f);
    }


    void Update()
    {
        if (Text != null)
        {
            currentSize += Time.deltaTime;
            time += Time.deltaTime;
            // 이동
            transform.Translate(dir * Time.deltaTime);

            // fade in -> out
            if (time < alpha)
            {
                if (time / alpha < 0.5f)
                {
                    Text.color = new Color(1f, 1f, 1f, 0.5f + time / alpha);
                }
                if (time / alpha > 0.5f)
                {
                    Text.color = new Color(1f, 1f, 1f, 1.5f - time / alpha);
                }
            }

            // bigger
            if (currentSize < sizeMax)
            {
                transform.localScale = new Vector3 (1f, 1f, 1f) * currentSize;
            }
        }
    }

    public void Reset()
    {
        Text = transform.GetComponentInChildren<TextMeshProUGUI>();

        // Direction
        transform.position = Vector3.zero;
        dir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), -1).normalized;

        // Fade IN OUT
        time = 0f;

        // Size
        currentSize = sizeMin;        
    }

    public void SetText(int gold)
    {
        Text.text = "+ " + gold.ToString();
    }
}

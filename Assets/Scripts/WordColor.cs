using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordColor : MonoBehaviour
{
    public Sword sword;

    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckColor();
    }

    void CheckColor()
    {
        if (sword.enhancementNumber < 10)
        {
            text.color = new Color(1, 1, 1, 1);
        }
        else if (sword.enhancementNumber < 15)
        {
            text.color = Color.blue;
        }
        else if (sword.enhancementNumber < 20)
        {
            text.color = new Color(0.8f, 0, 0.8f, 1);
        }
        else
        {
            text.color = Color.yellow;
        }
    }
}

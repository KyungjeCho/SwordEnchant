using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    public Sprite attackedSprite;
    public Monster stat;

    SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAttacked()
    {
        // change sprite
        spriteRenderer.sprite = attackedSprite;

        // flicking sprite 3 times
        spriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);
        // shake sprite

        // change sprite
    }

    
}

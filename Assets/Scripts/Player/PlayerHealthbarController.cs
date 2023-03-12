using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthbarController : MonoBehaviour
{
    public PlayerStats  stats;
    public Transform    BackgroundBarTransform;
    public Transform    healthBarTransform;
    public Transform    shieldBarTransform;

    public Vector2      startPosition;

    private float       healthBarLength;
    private float       shieldBarLength;
    
    void Start()
    {
        BackgroundBarTransform.position     = startPosition;
        healthBarTransform.position         = startPosition;
        shieldBarTransform.position         = startPosition;
    }

    void Update()
    {
        SetPosition();
    }

    void SetPosition()
    {
        healthBarLength = 2f * stats.Hp     / stats.MaxHp;
        shieldBarLength = 2f * stats.Shield / stats.MaxHp;

        healthBarTransform.localScale = new Vector2(healthBarLength, 1f);
        shieldBarTransform.localScale = new Vector2(shieldBarLength, 1f);

        if (stats.Hp + stats.Shield > stats.MaxHp)
        {
            shieldBarTransform.localPosition = new Vector2(2f + startPosition.x - shieldBarLength, startPosition.y);
        }
        else
        {
            shieldBarTransform.localPosition = new Vector2(startPosition.x + healthBarLength, startPosition.y);
        }
    }
}

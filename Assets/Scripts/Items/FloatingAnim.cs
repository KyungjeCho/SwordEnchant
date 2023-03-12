using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingAnim : MonoBehaviour
{
    public float Speed = 1f;
    public float Length = 1f;

    private float timer;
    private float yPosition;

    void Start()
    {
        
    }

    void Update()
    {
        timer       += Time.deltaTime * Speed;
        yPosition   = Mathf.Sin(timer) * Length;
        transform.position = new Vector2(
            transform.position.x, transform.position.y + yPosition
        );
    }
}

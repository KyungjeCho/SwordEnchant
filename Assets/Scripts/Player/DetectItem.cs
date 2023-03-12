using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectItem : MonoBehaviour
{
    private CircleCollider2D circleCollider2D;
    public PlayerStats stats;

    void Start()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
        circleCollider2D.radius = stats.PickUpArea;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Item")
        {
            other.gameObject.GetComponent<ActiveItemMove>().isAbleToMove = true;
        }
    }
}

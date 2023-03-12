using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDestory : MonoBehaviour
{
    private GameObject Player;

    void Awake()
    {
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        if (
            Mathf.Abs(Player.transform.position.x - transform.position.x) > 42 || 
            Mathf.Abs(Player.transform.position.y - transform.position.y) > 42
        )
        {
            Destroy(gameObject);
        }
    }
}

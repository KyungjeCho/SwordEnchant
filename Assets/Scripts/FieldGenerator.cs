using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldGenerator : MonoBehaviour
{
    public GameObject[] PrefabTiles;
    public GameObject   Player;

    private int bottom;
    private int top;
    private int left;
    private int right;   

    void Awake()
    {
        for (int i = -20; i < 20; i++)
        {
            for (int j = - 20; j < 20; j++)
            {
                int RandomNumber = Random.Range(0, 12);
                GameObject field = Instantiate(PrefabTiles[RandomNumber], new Vector2(2 * i, 2 * j), Quaternion.identity) as GameObject;

                field.transform.parent = transform;
            }
        }

        bottom  = -2;
        top     = 2;
        left    = -2;
        right   = 2;
    }

    void Update()
    {
        if ((int)Player.transform.position.y > top)
        {
            
            for (int i = -20; i < 20; i++)
            {
                int RandomNumber = Random.Range(0, 12);
                GameObject field = Instantiate(
                    PrefabTiles[RandomNumber], 
                    new Vector2(
                        (int)Player.transform.position.x + 2 * i, 
                        top + 38
                    ), 
                    Quaternion.identity
                ) as GameObject;

                field.transform.parent = transform;
            }
            top += 2;
            bottom += 2;
        }
        if ((int)Player.transform.position.y < bottom)
        {
            for (int i = -20; i < 20; i++)
            {
                int RandomNumber = Random.Range(0, 12);
                GameObject field = Instantiate(
                    PrefabTiles[RandomNumber], 
                    new Vector2(
                        (int)Player.transform.position.x + 2 * i, 
                        bottom - 38
                    ), 
                    Quaternion.identity
                ) as GameObject;

                field.transform.parent = transform;
            }
            top -= 2;
            bottom -= 2;
        }
        if ((int)Player.transform.position.x > right)
        {
            for (int i = -20; i < 20; i++)
            {
                int RandomNumber = Random.Range(0, 12);
                GameObject field = Instantiate(
                    PrefabTiles[RandomNumber], 
                    new Vector2(
                        right + 38, 
                        (int)Player.transform.position.y + 2 * i
                    ), 
                    Quaternion.identity
                ) as GameObject;

                field.transform.parent = transform;
            }
            left += 2;
            right += 2;
        }
        if ((int)Player.transform.position.x < left)
        {
            for (int i = -20; i < 20; i++)
            {
                int RandomNumber = Random.Range(0, 12);
                GameObject field = Instantiate(
                    PrefabTiles[RandomNumber], 
                    new Vector2(
                        left - 38, 
                        (int)Player.transform.position.y + 2 * i
                    ), 
                    Quaternion.identity
                ) as GameObject;

                field.transform.parent = transform;
            }
            left -= 2;
            right -= 2;
        }
    }
}

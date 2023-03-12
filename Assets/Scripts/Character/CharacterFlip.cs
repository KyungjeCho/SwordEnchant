using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFlip : MonoBehaviour
{
    public PlayerMove1 playerMove;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMove.FaceDirection == -1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}

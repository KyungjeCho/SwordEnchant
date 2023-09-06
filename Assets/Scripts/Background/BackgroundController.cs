using SwordEnchant.Characters;
using SwordEnchant.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    #region Variables
    public float duration = 23f;

    private Transform playerTr;
    #endregion Variables

    private void Start()
    {
        playerTr = GameManager.Instance.playerTr;
    }

    private void Update()
    {
        float diffX = Mathf.Abs(playerTr.position.x - transform.position.x);
        float diffY = Mathf.Abs(playerTr.position.y - transform.position.y);

        float dirX = playerTr.position.x - transform.position.x < 0 ? -1 : 1;
        float dirY = playerTr.position.y - transform.position.y < 0 ? -1 : 1;

        if (duration < diffX)
            transform.Translate(Vector3.right * dirX * 52);
        
        if (duration < diffY)
            transform.Translate(Vector3.up * dirY * 52);
    }
}

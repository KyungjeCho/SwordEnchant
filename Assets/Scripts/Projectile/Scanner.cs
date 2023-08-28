using SwordEnchant.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    private Transform playerTr;

    public float scanRange;
    public LayerMask targetLayer;
    public RaycastHit2D[] targets;
    public Transform nearestTarget;

    private void Awake()
    {
        if (playerTr == null)
            playerTr = GameManager.Instance.playerTr;

        Scan();
    }
    private void FixedUpdate()
    {
        Scan();
    }
    public void Scan()
    {
        targets = Physics2D.CircleCastAll(playerTr.position, scanRange, Vector2.zero, 0, targetLayer);
        nearestTarget = GetNeareset();
    }
    public Transform GetNeareset()
    {
        Transform result = null;
        float diff = 100;

        foreach (RaycastHit2D target in targets)
        {
            Vector3 myPos = playerTr.position;
            Vector3 targetPos = target.transform.position;
            float curDiff = Vector3.Distance(myPos, targetPos);

            if (curDiff < diff)
            {
                diff = curDiff;
                result = target.transform;

            }
        }

        return result;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        if (nearestTarget != null)
            Gizmos.DrawWireSphere(nearestTarget.position, 2f);

        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(GameManager.Instance.playerTr.position, scanRange);
    }
}

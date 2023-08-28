using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualCollision : MonoBehaviour
{
    public Vector2 boxSize = new Vector2(2, 2);

    public Collider2D[] CheckOverlapBox(LayerMask layerMask)
    {
        return Physics2D.OverlapBoxAll(transform.position, boxSize * 0.5f, layerMask);
    }
    void OnDrawGizmos()
    {
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(Vector3.zero, boxSize);
    }

}

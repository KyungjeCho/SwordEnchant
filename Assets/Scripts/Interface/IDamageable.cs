using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    bool IsAlive
    {
        get;
    }
    void TakeDamage(float damage, GameObject hitEffectPrefabs, Vector3 hitPoint);
}

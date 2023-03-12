using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : LivingEntity
{
    public Monster monsterData;

    protected virtual void OnEnable() 
    {
        base.OnEnable();

        Debug.Log("Child OnEnable");
    }

    public virtual void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {

    }
}

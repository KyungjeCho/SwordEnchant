using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour
{
    public bool dead { get; protected set; }
    public event Action onDeath;

    protected virtual void OnEnable()
    {
        dead = false;
        Debug.Log("Parent OnEnable");
    }

    public virtual void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {

    }

    public virtual void Die()
    {
        if (onDeath != null)
        {
            onDeath();
        }

        dead = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Core
{
    public interface IDamagable
    {
        bool IsAlive
        {
            get;
        }
        void TakeDamage(float damage, GameObject hitEffectPrefabs, Vector3 hitPoint);
    }
}


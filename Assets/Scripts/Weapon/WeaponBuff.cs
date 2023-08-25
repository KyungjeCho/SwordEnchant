using SwordEnchant.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.WeaponSystem
{
    public enum WeaponAttribute
    {
        Damage,
        Size,
        Speed,
        Cooldown,
        Count,
        CriticalDamage,
        CriticalProb
    }

    public enum BuffMode
    { 
        Plus,
        Times
    }

    [Serializable]
    public class WeaponBuff : IModifier<float>
    {
        public float value;
        public BuffMode mode;

        public WeaponBuff(float v, BuffMode m) { value = v; mode = m; }

        public void AddValue(ref float v)
        {
            v += value;

        }
    }

}

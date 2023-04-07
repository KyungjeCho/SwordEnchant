using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Weapon
{
    public enum WeaponAttribute
    {
        Damage,
        Size,
        Speed,
        Cooldown,
        CriticalDamage,
        CriticalProb
    }

    [Serializable]
    public class WeaponBuff
    {
        public WeaponAttribute attribute;
        public float value;

        public WeaponBuff() { }

        public void AddValue(ref float v)
        {
            v += value;
        }
    }

}

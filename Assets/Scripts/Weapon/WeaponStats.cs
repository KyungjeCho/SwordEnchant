using SwordEnchant.Data;
using SwordEnchant.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.WeaponSystem
{
    [Serializable]
    public class WeaponStats
    {
        public ModifiableFloat damage;
        public ModifiableFloat speed;
        public ModifiableFloat size;
        public ModifiableFloat cooldown;
        public ModifiableFloat count;
        public ModifiableFloat criticalDamage;
        public ModifiableFloat criticalProb;

        public WeaponList weaponIndex = WeaponList.None;

        public Action<WeaponStats> OnChangedStats;

        public WeaponStats(WeaponList weaponIndex)
        {
            if (weaponIndex == WeaponList.None)
            {
                Debug.LogWarning("잘못된 WeaponIndex 입니다. : " + weaponIndex);
            }
            this.weaponIndex = weaponIndex;
            Initialize();
        }

        public void Initialize()
        {
            WeaponClip clip = DataManager.WeaponData().weaponClips[(int)weaponIndex];

            damage = new ModifiableFloat(OnModifiedValue);
            speed = new ModifiableFloat(OnModifiedValue);
            size = new ModifiableFloat(OnModifiedValue);
            cooldown = new ModifiableFloat(OnModifiedValue);
            count = new ModifiableFloat(OnModifiedValue);
            criticalDamage = new ModifiableFloat(OnModifiedValue);
            criticalProb = new ModifiableFloat(OnModifiedValue);

            damage.BaseValue = clip.damage;
            speed.BaseValue = clip.speed;
            size.BaseValue = clip.size;
            cooldown.BaseValue = clip.cooldown;
            count.BaseValue = clip.count;
            criticalDamage.BaseValue = clip.criticalDamage;
            criticalProb.BaseValue = clip.criticalProb;
        }

        public void ClearModifier()
        {
            damage.ClearModifier();
            speed.ClearModifier();
            size.ClearModifier();
            cooldown.ClearModifier();
            count.ClearModifier();
            criticalDamage.ClearModifier();
            criticalProb.ClearModifier();
        }
        private void OnModifiedValue(ModifiableFloat value)
        {
            OnChangedStats?.Invoke(this);
        }
    }
}


using SwordEnchant.Data;
using SwordEnchant.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeaponUpgrade 
{
    #region Variables
    public WeaponUpgradeData[] data;

    public int maxGrade = 0;
    #endregion Variables

    #region Methods

    public virtual void Upgrade(int grade, WeaponStats stats)
    { // 강화후 grade
        stats.damage.AddModifier(data[grade - 1].stat[WeaponAttribute.Damage]);
        stats.size.AddModifier(data[grade - 1].stat[WeaponAttribute.Size]);
        stats.speed.AddModifier(data[grade - 1].stat[WeaponAttribute.Speed]);
        stats.cooldown.AddModifier(data[grade - 1].stat[WeaponAttribute.Cooldown]);
        stats.count.AddModifier(data[grade - 1].stat[WeaponAttribute.Count]);
        stats.criticalProb.AddModifier(data[grade - 1].stat[WeaponAttribute.CriticalProb]);
        stats.criticalDamage.AddModifier(data[grade - 1].stat[WeaponAttribute.CriticalDamage]);

        
    }

    public virtual void Downgrade(int grade, WeaponStats stats)
    { // 하락후 grade
        stats.damage.RemoveModifier(data[grade].stat[WeaponAttribute.Damage]);
        stats.size.RemoveModifier(data[grade].stat[WeaponAttribute.Size]);
        stats.speed.RemoveModifier(data[grade].stat[WeaponAttribute.Speed]);
        stats.cooldown.RemoveModifier(data[grade].stat[WeaponAttribute.Cooldown]);
        stats.count.RemoveModifier(data[grade].stat[WeaponAttribute.Count]);
        stats.criticalProb.RemoveModifier(data[grade].stat[WeaponAttribute.CriticalProb]);
        stats.criticalDamage.RemoveModifier(data[grade].stat[WeaponAttribute.CriticalDamage]);
    }

    public virtual void DestroyWeapon(WeaponStats stats, WeaponList index)
    {
        stats.damage.ClearModifier();

    }
    #endregion Methods
}

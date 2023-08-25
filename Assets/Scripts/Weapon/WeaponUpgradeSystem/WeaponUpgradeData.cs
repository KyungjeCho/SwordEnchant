using SwordEnchant.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.WeaponSystem
{
    [Serializable]
    public class WeaponUpgradeData
    {
        #region Variables
        public Dictionary<WeaponAttribute, WeaponBuff> stat;
        #endregion Variables

        public WeaponUpgradeData()
        {
            //stat = new Dictionary<WeaponAttribute, WeaponBuff>();

            //stat.Add(WeaponAttribute.Damage,            new WeaponBuff(0f, BuffMode.Plus));
            //stat.Add(WeaponAttribute.Size,              new WeaponBuff(0f, BuffMode.Plus));
            //stat.Add(WeaponAttribute.Speed,             new WeaponBuff(0f, BuffMode.Plus));
            //stat.Add(WeaponAttribute.Cooldown,          new WeaponBuff(0f, BuffMode.Plus));
            //stat.Add(WeaponAttribute.Count,             new WeaponBuff(0f, BuffMode.Plus));
            //stat.Add(WeaponAttribute.CriticalProb,      new WeaponBuff(0f, BuffMode.Plus));
            //stat.Add(WeaponAttribute.CriticalDamage,    new WeaponBuff(0f, BuffMode.Plus));
        }

        public WeaponUpgradeData(float damage, float size, float speed, 
                                    float cooldown, float count, float criticalProb, float criticalDamage)
        {

            stat = new Dictionary<WeaponAttribute, WeaponBuff>();

            stat.Add(WeaponAttribute.Damage,            new WeaponBuff(damage,          BuffMode.Plus));
            stat.Add(WeaponAttribute.Size,              new WeaponBuff(size,            BuffMode.Times));
            stat.Add(WeaponAttribute.Speed,             new WeaponBuff(speed,           BuffMode.Times));
            stat.Add(WeaponAttribute.Cooldown,          new WeaponBuff(cooldown,        BuffMode.Times));
            stat.Add(WeaponAttribute.Count,             new WeaponBuff(count,           BuffMode.Plus));
            stat.Add(WeaponAttribute.CriticalProb,      new WeaponBuff(criticalProb,    BuffMode.Plus));
            stat.Add(WeaponAttribute.CriticalDamage,    new WeaponBuff(criticalDamage,  BuffMode.Times));
        }
    }
}



using SwordEnchant.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Data
{
    public enum WeaponRarity
    {
        None = -1,
        Common = 0,
        Uncommon = 1,
        Rare = 2,
        Epic = 3,
        Unique = 4,
        Legendary = 5
    }

    public class WeaponClip
    {
        public int realID = 0;

        public string weaponName            = string.Empty;
        public string weaponPath            = string.Empty;
        public string weaponFullPath        = string.Empty;

        public GameObject projectilePrefab  = null;

        public float damage;
        public float size;
        public float speed;
        public float cooldown;
        public float count;         // 투사체 사출량
        public float criticalProb; // 크리 확률
        public float criticalDamage;

        public WeaponRarity rarity = WeaponRarity.None;

        public WeaponClip() { }

        public void PreLoad()
        {
            weaponFullPath = weaponPath + weaponName;
            if (weaponFullPath != string.Empty && projectilePrefab == null)
            {
                projectilePrefab = ResourceManager.Load(weaponFullPath) as GameObject;
            }
        }

        public void ReleaseMonster()
        {
            if (projectilePrefab != null)
            {
                projectilePrefab = null;
            }
        }
    }

}

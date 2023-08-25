using SwordEnchant.Core;
using SwordEnchant.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Data
{
    public enum WeaponRarity
    {
        None = -1,
        Normal = 0,
        Rare = 1,
        Epic = 2,
        Unique = 3,
        Legendary = 4,
        Mythic = 5
    }
    public enum WeaponType
    {
        None = -1,
        MELEE = 0,
        LONGRANGE = 1,
        MAGIC = 2
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
        public string korName;
        public string description;
        public WeaponRarity rarity = WeaponRarity.None;
        public WeaponType type = WeaponType.None;

        public WeaponClip() { }

        public void PreLoad()
        {
            weaponFullPath = weaponPath + weaponName;
            if (weaponFullPath != string.Empty && projectilePrefab == null)
            {
                projectilePrefab = ResourceManager.Load(weaponFullPath) as GameObject;

                //if (PoolManager.Instance.isContain(projectilePrefab) == false)
                //    PoolManager.Instance.CreatePool(projectilePrefab);
            }
        }

        public void ReleaseMonster()
        {
            if (projectilePrefab != null)
            {
                projectilePrefab = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// 
        public GameObject Instantiate(Vector2 Pos)
        {
            if (projectilePrefab == null)
            {
                PreLoad();
            }

            return null;
        }
    }

}

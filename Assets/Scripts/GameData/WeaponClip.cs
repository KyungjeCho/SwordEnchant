using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Data
{
    public class WeaponClip
    {
        public int realID = 0;

        public string weaponName        = string.Empty;
        public string weaponPath        = string.Empty;
        public string weaponFullPath    = string.Empty;

        public float damage;
        public float size;
        public float speed;
        public float cooldown;
        public float count;         // 투사체 사출량
        public float criticalProb; // 크리 확률
        public float criticalDamage;

        public WeaponClip() { }

        public void PreLoad()
        {
            // 나중에 프리펩
        }

        public void ReleaseMonster()
        {
            // 
        }
    }

}

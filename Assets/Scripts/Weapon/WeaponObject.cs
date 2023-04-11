using SwordEnchant.Data;
using SwordEnchant.Managers;
using SwordEnchant.Projectile;
using SwordEnchant.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Weapon
{
    //[CreateAssetMenu(fileName = "New Weapon", menuName = "Data/Weapon")]
    public class WeaponObject //: ScriptableObject
    {
        #region Variables
        public int grade = 0;
        public WeaponList weaponIndex = WeaponList.None;
        public WeaponStats stats;
        public WeaponClip clip;
        public Sprite icon;
         
        private float weaponTimer = 0.0f; // start : cooldown -> 0.0f

        #endregion Variables

        public void OnEnable()
        {
            //if (weaponIndex == WeaponList.None)
            //    return;

            //stats = new WeaponStats(weaponIndex);
            //clip = DataManager.WeaponData().weaponClips[(int)weaponIndex];

            //if (clip == null)
            //    clip.PreLoad();
        }

        public void OnEnter()
        {
            weaponTimer = clip.cooldown;
        }
        public void UpdateTimer(float deltaTime)
        {
            weaponTimer -= deltaTime;
            if (weaponTimer <= 0.0f)
            {
                GenerateProjectile();
                weaponTimer = clip.cooldown;
            }
        }

        public void OnExit()
        {

        }

        public void GenerateProjectile()
        {
            if (weaponTimer > 0.0f || weaponIndex == WeaponList.None)
                return;

            for(int i = 0; i < clip.count; i++)
            {
                //Poolable poolable = PoolManager.Instance.Pop(DataManager.WeaponData().weaponClips[(int)weaponIndex].projectilePrefab);
            }
        }

        
    }

}

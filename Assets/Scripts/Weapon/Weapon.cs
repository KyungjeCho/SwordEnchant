using SwordEnchant.Data;
using SwordEnchant.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Weapon
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Data/Weapon")]
    public class Weapon : ScriptableObject
    {
        #region Variables
        public int grade = 0;
        public WeaponList weaponIndex = WeaponList.None;
        public WeaponStats stats;
        public WeaponClip clip;
        public Sprite icon;
         
        private float weaponTimer; // start : cooldown -> 0.0f

        #endregion Variables

        public void OnEnable()
        {
            stats = new WeaponStats(weaponIndex);
            clip = DataManager.WeaponData().weaponClips[(int)weaponIndex];
            clip.PreLoad();
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
                // Projectile 생성 (오브젝트 풀)
                //clip.projectilePrefab;
            }
        }
    }

}

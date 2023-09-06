using SwordEnchant.Data;
using SwordEnchant.Managers;
using SwordEnchant.Projectile;
using SwordEnchant.UI;
using SwordEnchant.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.WeaponSystem
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Data/WeaponObject")]
    public class WeaponObject : ScriptableObject
    {
        #region Variables
        public WeaponList           weaponIndex;
        public Sprite               icon        = null; // Weapon Slot UI Icon

        public SlotNodeController   slotUI      = null;

        [SerializeField]
        private WeaponStats stats       = null;
        private WeaponClip  clip        = null;
        private float       cooldownTimer = 0.0f; // start : cooldown -> 0.0f
        public int          maxGrade    = 5;
        public  int         Grade       { get ; set; }
        public WeaponStats  Stats       => stats;

        public WeaponClip   Clip        => clip;
        public float        CooldownTimer => cooldownTimer;

        #endregion Variables

        #region OnEnable Method
        public void OnValidate()
        {
            if (weaponIndex == WeaponList.None)
                return;
            // WeaponList를 이용하여 Stats과 Clip 등록
            stats   = new WeaponStats(weaponIndex);
            clip    = DataManager.WeaponData().weaponClips[(int)weaponIndex];
            Grade   = 0;
            // Clip 에 있는 투사체 프리펩 PoolManager에 등록
            clip.PreLoad();

            //if (weaponIndex == WeaponList.None)
            //    return;

            //stats = new WeaponStats(weaponIndex);
            //clip = DataManager.WeaponData().weaponClips[(int)weaponIndex];

            //if (clip == null)
            //    clip.PreLoad();

            //slotNodePrefab = Resources.Load("Prefabs/UI/SlotNode") as GameObject;
            //slotParent = GameObject.Find("Canvas/WeaponInventoryPanel").transform;
        }
        public void RegisterPool()
        {
            if (clip.projectilePrefab == null || PoolManager.Instance == null)
                return;

            if (PoolManager.Instance.IsContain(clip.projectilePrefab) == false)
                PoolManager.Instance.CreatePool(clip.projectilePrefab);

        }
        #endregion OnEnable Method
        public void OnEnter()
        {
            cooldownTimer = clip.cooldown;

            slotUI = UIManager.Instance.CreateSlot();
            slotUI.InitUI(icon);
        }
        public void UpdateTimer(float deltaTime)
        {
            cooldownTimer -= deltaTime;
            if (cooldownTimer <= 0.0f)
            {
                cooldownTimer = clip.cooldown;
            }

            if (slotUI != null)
            {
                slotUI.UpdateCooldown(cooldownTimer / clip.cooldown);
            }
        }

        public void OnExit()
        {

        }

        public void GenerateProjectile()
        {
            //if (cooldownTimer > 0.0f || weaponIndex == WeaponList.None)
            //    return;

            //for(int i = 0; i < clip.count; i++)
            //{
            //    Poolable poolable = PoolManager.Instance.Pop(DataManager.WeaponData().weaponClips[(int)weaponIndex].projectilePrefab);
            //    ProjectileController projectileController = poolable.GetComponent<ProjectileController>();

                
            //    if (projectileController != null)
            //    {
            //        projectileController.parent = this;
            //        projectileController.OnEnter();                    
            //    }
            //}
        }

    }
}

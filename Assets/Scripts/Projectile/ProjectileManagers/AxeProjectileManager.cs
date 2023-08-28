using SwordEnchant.Characters;
using SwordEnchant.Managers;
using SwordEnchant.UI;
using SwordEnchant.Util;
using SwordEnchant.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Projectile
{
    public class AxeProjectileManager : BaseProjectileManager
    {
        private int currentCount;
        protected override void Update()
        {
            base.Update();
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            if (weaponObject == null)
            {
                weaponObject = Resources.Load("WeaponSystem/Sword") as WeaponObject;
            }
        }

        public override void Shot()
        {
            currentCount = 0;

            StartCoroutine(WaitForShot());


        }

        IEnumerator WaitForShot()
        {
            yield return new WaitForSeconds(0.3f);

            currentCount++;
            // shot
            DataManager.WeaponData().weaponClips[(int)weaponObject.weaponIndex].PreLoad();
            Debug.Log(DataManager.WeaponData().weaponClips[(int)weaponObject.weaponIndex].projectilePrefab);

            Poolable poolable = PoolManager.Instance.Pop(DataManager.WeaponData().weaponClips[(int)weaponObject.weaponIndex].projectilePrefab);

            AxeController sc = poolable.GetComponent<AxeController>();

            sc.OnEnter();

            if (currentCount >= (int)weaponObject.Stats.count.ModifiedValue)
                yield return null;
            else
                StartCoroutine(WaitForShot());
        }
    }

}


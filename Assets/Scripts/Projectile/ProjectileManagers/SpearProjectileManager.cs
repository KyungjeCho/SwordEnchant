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
    public class SpearProjectileManager : BaseProjectileManager
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
                weaponObject = Resources.Load("WeaponSystem/Spear") as WeaponObject;
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

            SpearController sc = poolable.GetComponent<SpearController>();
            
            sc.OnEnter();
            //SoundManager.Instance.PlayOneShotEffect((int)SoundList.Zap_C_02, sc.transform.position, 1f);

            if (currentCount >= (int)weaponObject.Stats.count.ModifiedValue)
                yield return null;
            else
                StartCoroutine(WaitForShot());
        }
    }

}


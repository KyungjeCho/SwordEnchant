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
    public class SwordProjectileManager : BaseProjectileManager
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
            
            SwordController sc = poolable.GetComponent<SwordController>();
            float degree;

            if (GameManager.Instance.playerTr.GetComponent<BehaviourController>().GetDir.x > 0)
                degree = 180f / (1f + weaponObject.Stats.count.ModifiedValue) * currentCount - 90f;
            else
                degree = 180f / (1f + weaponObject.Stats.count.ModifiedValue) * currentCount + 90f;

            sc.SetPosition(MathHelper.DegreeToVector2(degree));

            if (GameManager.Instance.playerTr.GetComponent<BehaviourController>().GetDir.x > 0)
                degree = 180f / (1f + weaponObject.Stats.count.ModifiedValue) * currentCount - 90f;
            else
                degree = 180f / (1f + weaponObject.Stats.count.ModifiedValue) * currentCount + 270f;
            sc.SetAngle(new Vector3(0f, 0f, degree));


            //sc.OnEnter();
            //SoundManager.Instance.PlayOneShotEffect((int)SoundList.Zap_C_02, sc.transform.position, 1f);

            if (currentCount >= (int)weaponObject.Stats.count.ModifiedValue)
                yield return null;
            else
                StartCoroutine(WaitForShot());
        }
    }

}


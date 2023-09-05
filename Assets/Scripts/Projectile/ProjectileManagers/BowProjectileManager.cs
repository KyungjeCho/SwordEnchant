using SwordEnchant.Characters;
using SwordEnchant.Managers;
using SwordEnchant.Util;
using SwordEnchant.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SwordEnchant.Projectile
{
    public class BowProjectileManager : BaseProjectileManager
    {
        private int currentCount;
        private Collider2D[] colliders;
        private Transform target;

        protected override void Update()
        {
            base.Update();
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            if (weaponObject == null)
            {
                weaponObject = Resources.Load("WeaponSystem/Bow") as WeaponObject;
                
            }
            DataManager.WeaponData().weaponClips[(int)weaponObject.weaponIndex].PreLoad();
        }

        public override void Shot()
        {
            currentCount = 0;

            colliders = Physics2D.OverlapCircleAll(
                GameManager.Instance.playerTr.position, 10f, LayerMask.GetMask(TagAndLayerKey.Enemy));

            if (colliders.Length > 0)
            {
                colliders.OrderBy(x =>
                    Vector2.Distance(GameManager.Instance.playerTr.position, x.transform.position)
                );
            }

            StartCoroutine(WaitForShot());
        }

        IEnumerator WaitForShot()
        {
            yield return new WaitForSeconds(0.2f);

            currentCount++;
            // shot
            Poolable poolable = PoolManager.Instance.Pop(DataManager.WeaponData().weaponClips[(int)weaponObject.weaponIndex].projectilePrefab);
            ArrowController controller = poolable.GetComponent<ArrowController>();

            controller.Number = currentCount - 1;
            controller.OnEnter();

            if (currentCount >= (int)weaponObject.Stats.count.ModifiedValue)
                yield return null;
            else
                StartCoroutine(WaitForShot());
        }
    }

}

//using SwordEnchant.Characters;
//using SwordEnchant.Managers;
//using SwordEnchant.Util;
//using SwordEnchant.WeaponSystem;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;

//namespace SwordEnchant.Projectile
//{
//    public class DaggerProjectileManager : BaseProjectileManager
//    {
//        private int currentCount;
//        private Transform target;

//        protected override void Update()
//        {
//            base.Update();
//        }

//        protected override void OnEnable()
//        {
//            base.OnEnable();

//            if (weaponObject == null)
//            {
//                weaponObject = Resources.Load("WeaponSystem/Sword") as WeaponObject;
//            }
//        }

//        public override void Shot()
//        {
//            currentCount = 0;

//            Collider2D[] colliders = Physics2D.OverlapCircleAll(
//                GameManager.Instance.playerTr.position, 10f, LayerMask.GetMask(TagAndLayerKey.Enemy));

//            if (colliders.Length > 0)
//            {
//                Collider2D coll = colliders.OrderBy(x => 
//                    Vector2.Distance(GameManager.Instance.playerTr.position, x.transform.position)
//                ).ToList()[0];

//                this.target = coll.gameObject.transform;
//            }

//            StartCoroutine(WaitForShot());
//        }

//        IEnumerator WaitForShot()
//        {
//            yield return new WaitForSeconds(0.2f);

//            currentCount++;
//            // shot
//            Poolable poolable = PoolManager.Instance.Pop(DataManager.WeaponData().weaponClips[(int)weaponObject.weaponIndex].projectilePrefab);
//            DaggerController controller = poolable.GetComponent<DaggerController>();

//            controller.SetTargetObject(target);
//            controller.OnEnter();

//            if (currentCount >= (int)weaponObject.Stats.count.ModifiedValue)
//                yield return null;
//            else
//                StartCoroutine(WaitForShot());
//        }
//    }

//}

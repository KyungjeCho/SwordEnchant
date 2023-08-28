using System.Collections;
using System.Collections.Generic;
using SwordEnchant.Core;
using UnityEngine;
using SwordEnchant.WeaponSystem;
using SwordEnchant.Managers;
using SwordEnchant.Data;
using SwordEnchant.Util;

namespace SwordEnchant.Projectile
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class ProjectileController : MonoBehaviour
    {
        #region Variables
        public WeaponObject weaponObject = null; 
        public WeaponList index = WeaponList.None;

        public SoundList shootSound;
        public EffectList hitEffect;

        protected Transform target;
        protected Vector3 direction;

        [SerializeField]
        protected float timeToSelfDestruct = 10.0f;
        #endregion Variables

        #region Virtual Methods
        public virtual void OnEnter()
        {
            transform.localScale = Vector3.one * weaponObject.Stats.size.ModifiedValue;
        }
        #endregion Vritual Methods

        #region Unity Methods
        public virtual void Awake()
        {
            if (weaponObject == null)
                weaponObject = WeaponDataManager.Instance.GetWeaponObject(index);

            
        }
        protected virtual void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.CompareTag(TagAndLayerKey.Enemy))
            {
                // 충돌 했을 경우

                // 몬스터에 대미지 입힌다
                IDamagable damagable = other.GetComponent<IDamagable>();
                //if (damagable != null)
                //    damagable.TakeDamage();
            }
        }
        #endregion Unity Methods

        

        #region Helper Methods
        /// <summary>
        /// 투사체가 나아갈 방향과 자신의 회전값
        /// </summary>
        /// <param name="startRotZ">원본 스트라이트가 얼마나 기울어 있는지</param>
        public void CalcDirectionRotation(float startRotZ = 0f)
        {
            float rotationZ = 0f;

            if (target != null && index != WeaponList.None)
            {
                direction = (target.position - transform.position).normalized;
            }
            else
            {
                Vector3 randDir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
                direction = (randDir - transform.position).normalized;
            }

            rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ + startRotZ);
        }

        /// <summary>
        /// 일정 시간이 지나면 오브젝트가 다시 풀로 돌아가게 하는 코루틴
        /// </summary>
        /// <returns></returns>
        protected IEnumerator SelfDestruct()
        {
            yield return new WaitForSeconds(timeToSelfDestruct);
            PoolManager.Instance.Push(GetComponent<Poolable>());
        }
        #endregion Helper Methods
    }
}
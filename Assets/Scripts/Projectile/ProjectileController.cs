using System.Collections;
using System.Collections.Generic;
using SwordEnchant.Core;
using UnityEngine;
using SwordEnchant.WeaponSystem;
using SwordEnchant.Managers;
using SwordEnchant.Data;

namespace SwordEnchant.Projectile
{
    public enum ProjectileType
    {
        NonPierce,
        Pierce
    }

    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class ProjectileController : MonoBehaviour
    {
        #region Variables
        public WeaponObject parent = null; // TODO: Delete
        public WeaponList index = WeaponList.None;

        public SoundList shootSound;
        public ProjectileType type;

        protected Transform target;
        protected Rigidbody2D myRigidbody2D;
        protected Vector3 direction;

        [SerializeField]
        protected float timeToSelfDestruct = 10.0f;

        protected bool collided = false; 
        #endregion Variables

        #region Unity Methods
        public virtual void OnEnable() 
        {
            if (parent == null)
                parent = WeaponDataManager.Instance.GetWeaponObject(index);

            myRigidbody2D = GetComponent<Rigidbody2D>();
            transform.localScale = Vector3.one * parent.Stats.size.ModifiedValue;

        }

        protected virtual void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.tag == "Enemy" && collided == false)
            { 
                IDamagable damagable        = other.gameObject.GetComponent<IDamagable>();

                if (damagable != null)
                {
                    damagable.TakeDamage(parent.Stats.damage.ModifiedValue, parent.Stats.criticalDamage.ModifiedValue, parent.Stats.criticalProb.ModifiedValue,  DataManager.EffectData().GetClip((int)EffectList.Hit_1).effectPrefab, other.ClosestPoint(transform.position));
                    
                }
            }
            
        }
        #endregion Unity Methods

        #region Abstract Methods
        public abstract void SetTargetObject(Transform target);
        
        public abstract void SetTargetObject();
        #endregion Abstract Methods

        #region Virtual Methods
        public virtual void OnEnter()
        {

            SoundClip clip = DataManager.SoundData().soundClips[(int)shootSound];
            SoundManager.Instance.PlayEffectSound(clip, GameManager.Instance.playerTr.position, clip.maxVolume);

            collided = false;
        }

        public virtual void OnExit()
        {

        }
        #endregion Vritual Methods

        #region Helper Methods
        /// <summary>
        /// 투사체가 나아갈 방향과 자신의 회전값
        /// </summary>
        /// <param name="startRotZ">원본 스트라이트가 얼마나 기울어 있는지</param>
        public void CalcDirectionRotation(float startRotZ = 0f)
        {
            if (target != null && index != WeaponList.None)
            {
                direction = (target.position - transform.position).normalized;
                float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ +  startRotZ);
            }
            else
            {
                Vector3 randDir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
                direction = (randDir - transform.position).normalized;
                float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ + startRotZ);
            }
        }
        #endregion Helper Methods
    }
}
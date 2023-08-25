using System.Collections;
using System.Collections.Generic;
using SwordEnchant.Core;
using UnityEngine;
using SwordEnchant.WeaponSystem;
using SwordEnchant.Managers;

namespace SwordEnchant.Projectile
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class ProjectileController : MonoBehaviour
    {
        #region Variables
        public WeaponObject parent = null;

        protected Transform target;
        protected Rigidbody2D myRigidbody2D;

        [SerializeField]
        protected float timeToSelfDestruct = 10.0f;

        protected bool collided = false;
        #endregion Variables

        #region Unity Methods
        void Start()
        {
            myRigidbody2D = GetComponent<Rigidbody2D>();
        }

        void OnEnable() 
        {
            myRigidbody2D = GetComponent<Rigidbody2D>();
            transform.localScale = Vector3.one * parent.Stats.size.ModifiedValue;
        }

        protected virtual void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.tag == "Enemy")
            {
                if (collided)
                {
                    return;
                }

                IDamagable damagable = other.gameObject.GetComponent<IDamagable>();
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
            transform.localScale = Vector3.one * parent.Stats.size.ModifiedValue;
        }

        public virtual void OnExit()
        {

        }
        #endregion Vritual Methods
        
        
    }
}
using System.Collections;
using System.Collections.Generic;
using SwordEnchant.Core;
using UnityEngine;
using SwordEnchant.Weapon;

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
        private float timeToSelfDestruct = 10.0f;

        private bool collided = false;
        #endregion Variables

        #region Unity Methods
        void Start()
        {
            myRigidbody2D = GetComponent<Rigidbody2D>();
        }

        void OnEnable() 
        {
            
        }

        protected virtual void OnTriggerEnter2D(Collider2D other) 
        {
            if (collided)
            {
                return;
            }    

            collided = true;
            IDamagable damagable = other.gameObject.GetComponent<IDamagable>();
            
            if (damagable != null)
            {
                damagable.TakeDamage(1f, null, Vector2.zero);
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

        }

        public virtual void OnExit()
        {

        }
        #endregion Vritual Methods
        
        
    }
}
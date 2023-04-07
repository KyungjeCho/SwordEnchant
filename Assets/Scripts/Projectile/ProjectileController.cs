using System.Collections;
using System.Collections.Generic;
using SwordEnchant.Core;
using UnityEngine;
using UnityEngine.Pool;
using SwordEnchant.Weapon;

namespace SwordEnchant.Projectile
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class ProjectileController : MonoBehaviour
    {
        #region Variables
        public IObjectPool<GameObject> Pool;
        //public Weapon parent;
        protected Transform _target;
        protected Rigidbody2D _rigidbody2d;

        [SerializeField]
        private float _timeToSelfDestruct = 10.0f;

        private bool _collided = false;
        #endregion Variables

        #region Unity Methods
        void Awake()
        {
            _rigidbody2d = GetComponent<Rigidbody2D>();
        }
        void OnEnable() 
        {
            StartCoroutine(SelfDestruct());
        }

        protected virtual void OnTriggerEnter2D(Collider2D other) 
        {
            if (_collided)
            {
                return;
            }    

            _collided = true;
            IDamagable damagable = other.gameObject.GetComponent<IDamagable>();
            Debug.Log("충돌");
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
        IEnumerator SelfDestruct()
        {
            yield return new WaitForSeconds(_timeToSelfDestruct);

            ReturnToPool();
        }

        private void ReturnToPool()
        {
            Pool.Release(this.gameObject);
        }

        
    }
}
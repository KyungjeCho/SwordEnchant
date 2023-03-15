using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace SwordEnchant.Projectile
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class ProjectileController : MonoBehaviour
    {
        #region Variables
        public IObjectPool<GameObject> Pool;

        protected Transform _target;
        protected Rigidbody2D _rigidbody2d;

        [SerializeField]
        private float _timeToSelfDestruct = 10.0f;

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
        #endregion Unity Methods

        #region Abstract Methods
        public abstract void SetTargetObject(Transform target);
        
        public abstract void SetTargetObject();
        #endregion Abstract Methods

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
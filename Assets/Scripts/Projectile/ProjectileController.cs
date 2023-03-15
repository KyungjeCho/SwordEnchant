using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace SwordEnchant.Projectile
{
    public abstract class ProjectileController : MonoBehaviour
    {
        #region Variables
        public IObjectPool<GameObject> Pool;

        private GameObject _targetObject;
        private Rigidbody2D _rigidbody2d;
        [SerializeField]
        private float _timeToSelfDestruct = 10.0f;

        #endregion Variables
        void OnEnable() 
        {
            StartCoroutine(SelfDestruct());
        }

        public abstract void SetTargetObject(GameObject targetObject);
        
        public abstract void SetTargetObject();

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


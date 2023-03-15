using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace SwordEnchant.Projectile
{
    public class ProjectileObjectPool : MonoBehaviour
    {
        #region Variables
        public int maxPoolSize = 10;
        public int stackDefaultCapacity = 10;

        public ProjectileController prefabForObjectPool;

        public IObjectPool<GameObject> Pool
        {
            get
            {
                if (_pool == null)
                    _pool = new ObjectPool<GameObject>(
                        CreatedPooledItem,
                        OnTakeFromPool,
                        OnReturnedToPool,
                        OnDestroyPoolObject,
                        true,
                        stackDefaultCapacity,
                        maxPoolSize);
                return _pool;
            }
        }

        private IObjectPool<GameObject> _pool;

        #endregion Variables

        private GameObject CreatedPooledItem()
        {
            var go = Instantiate(prefabForObjectPool, Vector3.zero, Quaternion.identity);

            go.Pool = Pool;

            return go.gameObject;
        }

        private void OnReturnedToPool(GameObject projectile)
        {
            projectile.gameObject.SetActive(false);

        }

        private void OnTakeFromPool(GameObject projectile)
        {
            projectile.gameObject.SetActive(true);
        }

        private void OnDestroyPoolObject(GameObject projectile)
        {
            Destroy(projectile.gameObject);
        }

        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ProjectileObjectPool : MonoBehaviour
{
    public int maxPoolSize = 10;
    public int stackDefaultCapacity = 10;

    public IObjectPool<ProjectileController> Pool
    {
        get
        {
            if (_pool == null)
                _pool = new ObjectPool<ProjectileController>(
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

    private IObjectPool<ProjectileController> _pool;

    private ProjectileController CreatedPooledItem()
    {
        // 게임 오브젝트 
        var go = GameObject.CreatePrimitive(PrimitiveType.Cube);

        ProjectileController projectile = go.AddComponent<ProjectileController>();

        go.name = "Projectile";
        projectile.Pool = Pool;

        return projectile;
    }

    private void OnReturnedToPool(ProjectileController projectile)
    {
        projectile.gameObject.SetActive(false);

    }

    private void OnTakeFromPool(ProjectileController projectile)
    {
        projectile.gameObject.SetActive(true);
    }

    private void OnDestroyPoolObject(ProjectileController projectile)
    {
        Destroy(projectile.gameObject);
    }

    
}

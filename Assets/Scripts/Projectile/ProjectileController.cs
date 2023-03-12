using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class ProjectileController : MonoBehaviour
{
    public IObjectPool<ProjectileController> Pool { get; set; }
    public Projectile ProjectileData;

    private GameObject _targetObject;
    private Rigidbody2D _rigidbody2d;

    [SerializeField]
    private float _timeToSelfDestruct = 100.0f;
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
        Pool.Release(this);
    }


}

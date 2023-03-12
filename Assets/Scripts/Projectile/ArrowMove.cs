using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ArrowMove : MonoBehaviour, IProjectileMove
{
    public IObjectPool<ArrowMove> ProjectilePool { get; set; }
    public GameObject TestTarget;

    [Range(1f, 10f)]
    public float Speed;

    private float angle;
    private ProjectileController _projectileContorller;

    private Rigidbody2D _rigidbody2d;

    [SerializeField]
    private float timeToSelfDestruct = 100.0f;

    void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _rigidbody2d.velocity = transform.right * Speed;
    }
    void OnEnable() 
    {
        if (!TestTarget)
            return;
        
        angle = Mathf.Atan2(TestTarget.transform.position.y - transform.position.y, 
                            TestTarget.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void OnDisable()
    {

    }

    void FixedUpdate()
    {

    }

    public void Move()
    {
        
    }

    private void Destruct()
    {

    }

    private void ReturnToPool()
    {
        ProjectilePool.Release(this);
    }

    IEnumerator SelfDesturct()
    {
        yield return new WaitForSeconds(timeToSelfDestruct);
        
    }
}

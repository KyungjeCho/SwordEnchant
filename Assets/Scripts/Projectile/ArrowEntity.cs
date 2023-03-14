using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ArrowEntity : ProjectileEntity
{
    #region Variables
    public IObjectPool<ArrowEntity> Pool { get; set; }
    #endregion Variables

    #region UNITY_Methods
    void OnEnable()
    {
        StartCoroutine(SelfDestruct());
    }
    #endregion UNITY_Methods

    #region Override_Methods
    protected override void ReturnToPool()
    {
        Pool.Release(this);
    }

    protected override IEnumerator SelfDestruct()
    {
        yield return null;
    }
    #endregion Override_Methods
}

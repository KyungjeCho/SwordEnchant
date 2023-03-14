using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody2D)),RequireComponent(typeof(Animator))]
public abstract class ProjectileEntity : MonoBehaviour
{
    #region Variables

    [SerializeField]
    protected float _timeToSelfDestruct = 3.0f;
    #endregion Variables

    #region Abstract_Methods
    protected abstract void ReturnToPool();
    protected abstract IEnumerator SelfDestruct();
    #endregion Abstract_Methods


}

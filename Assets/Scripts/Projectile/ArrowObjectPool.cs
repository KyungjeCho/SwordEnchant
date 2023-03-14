using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ArrowObjectPool : MonoBehaviour
{
    #region Variables
    // Must: Test Prefab must be deleted!
    public GameObject TestPrefab;
    public int maxPoolSize = 10;
    public int stackDefaultCapacity = 10;
    
    // public IObjectPool<ArrowEntity> Pool
    // {
    //     get
    //     {
    //         if (_pool == null)
    //             _pool = new ObjectPool<ArrowEntity>(

    //             )
    //     }
    // }

    private IObjectPool<ArrowEntity> _pool;

    #endregion Variables

    #region Pool_Helper_Methods
    private ArrowEntity CreatedPooledItem()
    {

        return new ArrowEntity();
    }
    #endregion Pool_Helper_Methods   
}

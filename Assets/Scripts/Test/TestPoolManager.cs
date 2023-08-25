using SwordEnchant.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPoolManager : MonoBehaviour
{
    public GameObject testPrefab;

    // Start is called before the first frame update
    void Start()
    {
        if (testPrefab != null)
        {
            PoolManager.Instance.CreatePool(testPrefab, 10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

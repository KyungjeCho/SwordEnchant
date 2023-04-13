using SwordEnchant.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Managers
{
    public class PoolManager : MonoSingleton<PoolManager>
    {
        private Dictionary<string, Pool> pool = new Dictionary<string, Pool>();
        private Transform root;

        public Dictionary<string, Pool> Pool => pool;

        private void Awake()
        {
            Init();
        }
        public void Init()
        {
            if (root == null)
            {
                root = new GameObject { name = "@Pool_Root" }.transform;
                DontDestroyOnLoad(root);
            }
        }

        public void CreatePool(GameObject original, int poolSize = 10)
        {
            Pool pool = new Pool();
            pool.Init(original, poolSize);
            pool.Root.parent = this.root;

            this.pool.Add(original.name, pool);
        }

        public void Push(Poolable poolable)
        {
            string name = poolable.gameObject.name;

            if (pool.ContainsKey(name) == false)
            {
                Destroy(poolable.gameObject);
                return;
            }

            pool[name].Push(poolable);
        }

        public Poolable Pop(GameObject original, Transform parent = null)
        {
            if (pool.ContainsKey(original.name) == false)
            {
                CreatePool(original);
            }

            return pool[original.name].Pop(parent);
        }

        public bool isContain(GameObject original)
        {
            return pool.ContainsKey(original.name);
        }
        public bool isContain(string originalName)
        {
            return pool.ContainsKey(originalName);
        }

        public GameObject GetOriginal(string name)
        {
            if (pool.ContainsKey(name) == false)
            {
                return null;
            }

            return pool[name].Original;
        }

        public void Clear()
        {
            foreach (Transform child in root)
                Destroy(child.gameObject);

            pool.Clear();
        }
    }
}

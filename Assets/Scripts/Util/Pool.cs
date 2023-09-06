using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SwordEnchant.Util
{
    public class Pool
    {
        public GameObject original { get; private set; }
        public Transform root { get; set; }

        public int maxPoolSize { get; private set; }

        private Stack<Poolable> poolStack = new Stack<Poolable>();

        public void Init(GameObject original, int poolSize = 10)
        {
            this.original = original;
            maxPoolSize = poolSize;
            root = new GameObject().transform;
            root.name = $"{original.name}_Root";

            for (int i = 0; i < maxPoolSize; i++)
            {
                Push(Create());
            }
        }

        private Poolable Create()
        {
            GameObject go = Object.Instantiate<GameObject>(original);
            go.name = original.name;

            if (go.GetComponent<Poolable>() == null)
                return go.AddComponent<Poolable>();
            else
                return go.GetComponent<Poolable>();
        }

        public void Push(Poolable poolable)
        {
            if (poolable == null)
                return;

            poolable.transform.parent = root;

            poolable.gameObject.SetActive(false);
            poolable.isUsing = false;

            poolStack.Push(poolable);
        }

        /// <summary>
        /// 풀에서 하나의 오브젝트를 Pop 시키는 메서드
        /// </summary>
        public Poolable Pop(Transform parent)
        {
            Poolable poolable;

            if (poolStack.Count > 0)
                poolable = poolStack.Pop();
            else
                poolable = Create();

            poolable.gameObject.SetActive(true);

            
            if (parent != null)
                poolable.transform.parent = parent;

            poolable.isUsing = true;

            return poolable;
        }
    }
}



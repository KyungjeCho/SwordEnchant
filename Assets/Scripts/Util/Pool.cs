using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SwordEnchant.Util
{
    public class Pool
    {
        public GameObject Original { get; private set; }
        public Transform Root { get; set; }

        public int MaxPoolSize { get; private set; }

        private Stack<Poolable> poolStack = new Stack<Poolable>();

        public void Init(GameObject original, int poolSize = 10)
        {
            Original = original;
            MaxPoolSize = poolSize;
            Root = new GameObject().transform;
            Root.name = $"{original.name}_Root";

            for (int i = 0; i < MaxPoolSize; i++)
            {
                Push(Create());
            }
        }

        private Poolable Create()
        {
            GameObject go = Object.Instantiate<GameObject>(Original);
            go.name = Original.name;

            if (go.GetComponent<Poolable>() == null)
                return go.AddComponent<Poolable>();
            else
                return go.GetComponent<Poolable>();
        }

        public void Push(Poolable poolable)
        {
            if (poolable == null)
                return;

            poolable.transform.parent = Root;

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



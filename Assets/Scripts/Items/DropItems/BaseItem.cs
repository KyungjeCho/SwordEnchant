using SwordEnchant.Managers;
using SwordEnchant.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace SwordEnchant.Item
{
    public enum ItemState
    {
        IDLE, TRACKING, 
    }

    public abstract class BaseItem : MonoBehaviour
    {
        #region Variables

        private Transform playerTr;
        #endregion Variables

        #region Unity Methods
        // Start is called before the first frame update
        protected virtual void Start()
        {
            playerTr = GameManager.Instance.playerTr;

            //transform.DOLocalMoveY(transform.position.y + 1f, 1.0f)
            //    .SetLoops(-1, LoopType.Yoyo)
            //    .SetEase(Ease.InOutSine);
        }

        // Update is called once per frame
        void Update()
        {

        }
        #endregion Unity Methods

        #region Virtual Methods
        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                // Use
                Use();

                // Destroy
                Poolable poolable = GetComponent<Poolable>();
                
                if (PoolManager.Instance.isContain(gameObject) && poolable != null)
                    PoolManager.Instance.Push(poolable); 
                else
                    Destroy(gameObject); // 풀에 등록되지 않으면

            }
        }
        #endregion Virtual Methods

        #region Abstract Methods
        public abstract void Use();
        #endregion Abstract Methods
    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using SwordEnchant.Core;
using SwordEnchant.Managers;
using SwordEnchant.Util;
using UnityEngine;

namespace SwordEnchant.Characters
{
    public class MonsterStats
    {
        public float health;
        public float speed;
        public float damage;
        public float defence;
        public float size;

        public MonsterStats(MonsterList index)
        {
            health = DataManager.MonsterData().monsterClips[(int)index].health;
            speed = DataManager.MonsterData().monsterClips[(int)index].speed;
            damage = DataManager.MonsterData().monsterClips[(int)index].damage;
            defence = DataManager.MonsterData().monsterClips[(int)index].defence;
            size = DataManager.MonsterData().monsterClips[(int)index].size;
        }
    }

    [Serializable]
    public class DropItem
    {
        public GameObject dropItemObj;
        [Range(0f, 1f)]
        public float dropRate;
    }

    public abstract class EnemyController : MonoBehaviour, IMoveable
    {
        #region Variables
        protected DamageFlash damageFlash;

        protected StateMachine<EnemyController> stateMachine;

        private Transform target = null;
        public Transform Target => target;

        public MonsterList data;

        protected MonsterStats stats;

        public MonsterStats Stats => stats;

        protected Vector3 direction = Vector3.zero;
        public Vector3 Direction => direction;

        public List<DropItem> dropItems = new List<DropItem>();

        #endregion Variables


        #region Unity Methods
        protected virtual void Start()
        {
            damageFlash = GetComponent<DamageFlash>();

            stateMachine = new StateMachine<EnemyController>(this, new IdleState());
            stats = new MonsterStats(data);
        }

        protected virtual void Update()
        {
            if (stats.health <= 0f)
            {
                Kill();
            }
        }

        protected virtual void FixedUpdate()
        {
            stateMachine.Update(Time.fixedDeltaTime);
        }
        #endregion Unity Methods

        #region Abstract Methods
        public abstract void Move();
        public abstract void CalculateDirection();
        #endregion Abstract Methods

        #region Virtual Methods
        public virtual void Knockback()
        {

        }
        #endregion Virtual Methods

        #region Helper Methods
        public void FindPlayer()
        {
            Transform playerTr = GameManager.Instance.playerTr;
            if (playerTr == null)
            {
                Debug.LogWarning("Player 게임 오브젝트를 현재 씬에서 찾을 수 없습니다");
                return;
            }
            else 
            {
                target = playerTr;
            }
        }

        public void ResetHealth()
        {
            stats = new MonsterStats(data);
        }

        public void Kill()
        {
            if (stats.health > 0f)
                return;

            damageFlash.SetFlashAmount(0f);

            foreach(DropItem item in dropItems)
            {
                float rand = UnityEngine.Random.Range(0f, 1f);

                if (rand <= item.dropRate)
                {
                    Poolable po = PoolManager.Instance.Pop(item.dropItemObj);
                    Vector3 randomPos = UnityEngine.Random.insideUnitCircle;
                    po.transform.position = transform.position + randomPos;
                }
            }

            PoolManager.Instance.Push(GetComponent<Poolable>());
        }
        #endregion Helper Methods
    }
}


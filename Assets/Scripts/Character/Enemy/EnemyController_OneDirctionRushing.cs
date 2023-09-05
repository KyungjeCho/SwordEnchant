using System.Collections;
using System.Collections.Generic;
using SwordEnchant.Core;
using SwordEnchant.Managers;
using SwordEnchant.Util;
using UnityEngine;

namespace SwordEnchant.Characters
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyController_OneDirctionRushing : EnemyController, IDamagable
    {
        #region Variables
        private Rigidbody2D             _rigidbody2D;

        [SerializeField]
        private float                   _elapsedTime = 0f;
        public float                    attackCooldown = 1f;
        public SoundList                soundIndex;

        public bool IsAlive => throw new System.NotImplementedException();
        #endregion Variables


        #region Unity Methods
        protected override void Start()
        {
            base.Start();
            
            stateMachine.AddState(new MoveState());

            _rigidbody2D     = GetComponent<Rigidbody2D>();
            _elapsedTime    = attackCooldown; // 시작하자마자 쿨타임 채우기
        }
        protected override void Update()
        {
            base.Update();
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            _elapsedTime += Time.fixedDeltaTime;
            if (_elapsedTime > attackCooldown)
                _elapsedTime = attackCooldown;
        }

        protected virtual void OnCollisionStay2D(Collision2D other)
        {
            Debug.Log("충돌 처리 전 ");
            if (_elapsedTime < attackCooldown)
            {
                return;
            }


            if (other.gameObject.tag == "Player")
            {
                IDamagable damagable = other.gameObject.GetComponent<IDamagable>();
                if (damagable != null)
                {
                    damagable.TakeDamage(stats.damage, 0f, 0f, null, Vector3.zero);
                    _elapsedTime = 0f;
                }
            }
        }

        #endregion Unity Methods

        #region Moveable Interface
        public override void Move()
        {
            _rigidbody2D.velocity = -_direction * stats.speed * Time.deltaTime * 100; 
        }

        #endregion Moveable Interface

        #region Helper Methods
        public override void CalculateDirection()
        {
            if (Target == null)
            {
                return;
            }

            _direction = (transform.position - Target.position).normalized;
            _direction.z = 0f;
        }

        public void TakeDamage(float damage, float criticalDamage, float criticalProb, GameObject hitEffectPrefabs, Vector3 hitPoint)
        {
            float totalDamage = Formula.TotalDamage(damage, criticalDamage, stats.defence, Formula.IsCritical(criticalProb));
            stats.health -= totalDamage;

            SoundManager.Instance.PlayEffectSound(DataManager.SoundData().soundClips[(int)soundIndex]);
            UIManager.Instance.CreateDamageText(transform.position, -(int)totalDamage);

            damageFlash.CallDamageFlash();
        }
        #endregion Helper Methods
    }
}

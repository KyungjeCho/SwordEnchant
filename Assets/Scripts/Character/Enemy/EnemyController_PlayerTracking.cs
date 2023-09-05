using System.Collections;
using System.Collections.Generic;
using SwordEnchant.Core;
using SwordEnchant.Managers;
using SwordEnchant.Util;
using UnityEngine;

namespace SwordEnchant.Characters
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyController_PlayerTracking : EnemyController, IDamagable
    {
        #region Variables
        private Rigidbody2D _rigidbody2d;

        [SerializeField]
        private float _elapsedTime = 0f;
        public float attackCooldown = 1f;
        public SoundList soundIndex;

        public bool IsAlive => throw new System.NotImplementedException();
        #endregion Variables
        #region Unity Methods
        protected override void Start()
        {
            base.Start();
            
            stateMachine.AddState(new MoveState());
            stateMachine.AddState(new KnockbackState());

            _rigidbody2d = GetComponent<Rigidbody2D>();
            _elapsedTime = attackCooldown; // 시작하자마자 쿨타임 채우기
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

        #region Move Strategy Methods
        public override void Move()
        {
            CalculateDirection();
            //_controller.Move(-_direction * 1 * Time.deltaTime);
            _rigidbody2d.velocity = -_direction * stats.speed * Time.deltaTime * 100;

            if (_direction.x < 0)
                transform.localScale = new Vector3(-1f, 1f, 1f) * stats.size;
            else if (_direction.x > 0)
                transform.localScale = new Vector3(1f, 1f, 1f) * stats.size;
        }

        public override void Knockback()
        {
            _rigidbody2d.velocity = _direction * stats.speed * Time.deltaTime * 300;
        }
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
            float totalDamage = Formula.TotalDamage(damage, 1f, stats.defence, Formula.IsCritical(criticalProb));
            stats.health -= totalDamage;

            SoundManager.Instance.PlayEffectSound(DataManager.SoundData().soundClips[(int)soundIndex]);
            UIManager.Instance.CreateDamageText(transform.position, -(int)totalDamage);
            
            stateMachine.ChangeState<KnockbackState>();

            EffectManager.Instance.EffectOneShot((int)EffectList.HitEffect, hitPoint);

            damageFlash.CallDamageFlash();
        }
        #endregion Move Strategy Method

        #region Helper Methods

        #endregion Helper Methods
    }
}

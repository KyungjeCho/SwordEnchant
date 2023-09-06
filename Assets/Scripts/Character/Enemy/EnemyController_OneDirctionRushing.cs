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
        private Rigidbody2D             myRigidbody2D;

        [SerializeField]
        private float                   elapsedTime = 0f;
        public float                    attackCooldown = 1f;
        public SoundList                soundIndex;

        public bool IsAlive => throw new System.NotImplementedException();
        #endregion Variables


        #region Unity Methods
        protected override void Start()
        {
            base.Start();
            
            stateMachine.AddState(new MoveState());

            myRigidbody2D = GetComponent<Rigidbody2D>();
            elapsedTime = attackCooldown; // 시작하자마자 쿨타임 채우기
        }
        protected override void Update()
        {
            base.Update();
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            elapsedTime += Time.fixedDeltaTime;
            if (elapsedTime > attackCooldown)
                elapsedTime = attackCooldown;
        }

        protected virtual void OnCollisionStay2D(Collision2D other)
        {
            if (elapsedTime < attackCooldown)
            {
                return;
            }


            if (other.gameObject.tag == "Player")
            {
                IDamagable damagable = other.gameObject.GetComponent<IDamagable>();
                if (damagable != null)
                {
                    damagable.TakeDamage(stats.damage, 0f, 0f, null, Vector3.zero);
                    elapsedTime = 0f;
                }
            }
        }

        #endregion Unity Methods

        #region Moveable Interface
        public override void Move()
        {
            myRigidbody2D.velocity = -direction * stats.speed * Time.deltaTime; 
        }

        #endregion Moveable Interface

        #region Helper Methods
        public override void CalculateDirection()
        {
            if (Target == null)
            {
                return;
            }

            direction = (transform.position - Target.position).normalized;
            direction.z = 0f;
        }

        public void TakeDamage(float damage, float criticalDamage, float criticalProb, GameObject hitEffectPrefabs, Vector3 hitPoint)
        {
            float totalDamage = Formula.TotalDamage(damage, 1f, stats.defence, Formula.IsCritical(criticalProb));
            stats.health -= totalDamage;

            SoundManager.Instance.PlayEffectSound(DataManager.SoundData().soundClips[(int)soundIndex]);
            UIManager.Instance.CreateDamageText(transform.position, -(int)totalDamage);

            EffectManager.Instance.EffectOneShot((int)EffectList.HitEffect, hitPoint);

            damageFlash.CallDamageFlash();
        }
        #endregion Helper Methods
    }
}

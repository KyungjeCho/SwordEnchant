using System.Collections;
using System.Collections.Generic;
using SwordEnchant.Core;
using UnityEngine;

namespace SwordEnchant.Characters
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyController_OneDirctionRushing : EnemyController
    {
        #region Variables
        private Rigidbody2D             _rigidbody2D;

        [SerializeField]
        private float                   _elapsedTime = 0f;
        public float                    attackCooldown = 5f;
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

            _elapsedTime += Time.deltaTime;
            if (_elapsedTime > attackCooldown)
                _elapsedTime = attackCooldown;
        }

        protected virtual void OnCollisionEnter2D(Collision2D other) 
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
                    damagable.TakeDamage(1f, null, Vector3.zero);
                    _elapsedTime = 0f;
                }
            }
        }
        #endregion Unity Methods

        #region Moveable Interface
        public override void Move()
        {
            //_controller.Move(-_direction * 10 * Time.deltaTime);
            _rigidbody2D.AddForce(-_direction * 10 * Time.deltaTime);
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
        #endregion Helper Methods
    }
}

using System.Collections;
using System.Collections.Generic;
using SwordEnchant.Core;
using UnityEngine;

namespace SwordEnchant.Characters
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyController_PlayerTracking : EnemyController
    {
        #region Variables
        private Rigidbody2D _rigidbody2d;
        #endregion Variables
        #region Unity Methods
        protected override void Start()
        {
            base.Start();
            
            stateMachine.AddState(new MoveState());

            _rigidbody2d = GetComponent<Rigidbody2D>();            
        }
        #endregion Unity Methods

        #region Move Strategy Methods
        public override void Move()
        {
            CalculateDirection();
            //_controller.Move(-_direction * 1 * Time.deltaTime);
            _rigidbody2d.velocity = -_direction * 100 * Time.deltaTime;
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
        #endregion Move Strategy Method

        #region Helper Methods

        #endregion Helper Methods
    }
}

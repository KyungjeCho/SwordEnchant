using System.Collections;
using System.Collections.Generic;
using SwordEnchant.Core;
using UnityEngine;

namespace SwordEnchant.Characters
{
    public class EnemyController_PlayerTracking : EnemyController
    {
        #region Variables
        private CharacterController _controller;
        #endregion Variables
        #region Unity Methods
        protected override void Start()
        {
            base.Start();
            
            stateMachine.AddState(new MoveState());

            _controller = GetComponent<CharacterController>();            
        }
        #endregion Unity Methods

        #region Move Strategy Methods
        public override void Move()
        {
            CalculateDirection();
            _controller.Move(-_direction * 1 * Time.deltaTime);
            
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

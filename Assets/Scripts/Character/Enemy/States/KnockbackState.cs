using SwordEnchant.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Core
{
    public class KnockbackState : State<EnemyController>
    {
        #region Variables
        private Rigidbody2D myRigidbody2D;

        private float duration = 0.1f;
        private float timer = 0.0f;
        #endregion Variables

        #region Override Methods
        public override void OnInitialized()
        {
            myRigidbody2D = context.GetComponent<Rigidbody2D>();
        }

        public override void OnEnter()
        {
            context.FindPlayer();
            context.CalculateDirection();

            timer = 0.0f;
        }

        public override void OnExit()
        {

        }
        #endregion Override Methods

        #region Update Method   
        public override void Update(float deltaTime)
        {
            timer += deltaTime;

            context.Knockback();
            if (timer >= duration && context is EnemyController_PlayerTracking)
            {
                stateMachine.ChangeState<MoveState>();
            }
        }
        #endregion Update Method
    }
}


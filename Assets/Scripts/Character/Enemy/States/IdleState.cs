using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordEnchant.Characters;

namespace SwordEnchant.Core
{
    public class IdleState : State<EnemyController>
    {
        #region Variables
        private CharacterController controller;
        #endregion Variables

        #region Override Methods
        public override void OnInitialized()
        {
            controller = context.GetComponent<CharacterController>();
        }

        public override void OnEnter()
        {
            
        }

        public override void OnExit()
        {
            
        }
        #endregion Override Methods

        #region Update Method   
        public override void Update(float deltaTime)
        {
            if (context is EnemyController_Directional)
                stateMachine.ChangeState<MoveState>();
        }
        #endregion Update Method
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordEnchant.Characters;

namespace SwordEnchant.Core
{
    public class MoveState : State<EnemyController>
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
            context.FindPlayer();
            context.CalculateDirection();
            
        }

        public override void OnExit()
        {
            
        }
        #endregion Override Methods

        #region Update Method   
        public override void Update(float deltaTime)
        {
            context.Move();
        }
        #endregion Update Method
    }
}

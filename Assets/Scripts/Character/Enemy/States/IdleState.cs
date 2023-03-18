using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordEnchant.Core;

namespace SwordEnchant.Characters
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
            
        }
        #endregion Update Method
    }
}

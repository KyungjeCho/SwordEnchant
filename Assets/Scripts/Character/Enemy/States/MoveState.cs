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

        //private IMoveStrategy moveStrategy;
        #endregion Variables

        #region Override Methods
        public override void OnInitialized()
        {
            //controller = context.GetComponent<CharacterController>();
        }

        public override void OnEnter()
        {
            //moveStrategy = context.GetComponent<IMoveStrategy>();
        }

        public override void OnExit()
        {
            
        }
        #endregion Override Methods

        #region Update Method   
        public override void Update(float deltaTime)
        {
            //moveStrategy?.Move();
        }
        #endregion Update Method
    }
}

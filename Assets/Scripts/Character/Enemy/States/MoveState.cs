using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordEnchant.Characters;

namespace SwordEnchant.Core
{
    public class MoveState : State<EnemyController>
    {

        #region Override Methods
        public override void OnInitialized()
        {

        }

        public override void OnEnter()
        {
            context.FindPlayer();
            context.CalculateDirection();

            if (context.Direction.x < 0)
                context.transform.localScale = new Vector3(-1f, 1f, 1f) * context.Stats.size;
            else if (context.Direction.x > 0)
                context.transform.localScale = new Vector3(1f, 1f, 1f) * context.Stats.size;
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

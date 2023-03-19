using System.Collections;
using System.Collections.Generic;
using SwordEnchant.Core;
using UnityEngine;

namespace SwordEnchant.Characters
{
    [RequireComponent(typeof(CharacterController))]
    public /*abstract*/ class EnemyController : MonoBehaviour/*, IMoveStrategy */
    {
        #region Variables
        protected StateMachine<EnemyController> stateMachine;
        // Todo: Monster animation 구현
        //protected Animator animator; 
        #endregion Variables

        #region Unity Methods
        protected virtual void Start()
        {
            stateMachine = new StateMachine<EnemyController>(this, new IdleState());
        }

        protected virtual void Update()
        {
            stateMachine.Update(Time.deltaTime);
        }
        #endregion Unity Methods

        #region Abstract Methods
        //public abstract void Move();
        #endregion Abstract Methods
        #region Helper Methods

        // public R ChangeState<R>() where R : State<EnemyController>
        // {
        //     return stateMachine.ChangeState<R>();
        // }

        #endregion Helper Methods
    }
}


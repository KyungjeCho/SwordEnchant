using System.Collections;
using System.Collections.Generic;
using SwordEnchant.Core;
using UnityEngine;

namespace SwordEnchant.Characters
{
    [RequireComponent(typeof(CharacterController))]
    public abstract class EnemyController : MonoBehaviour
    {
        #region Variables
        protected StateMachine<EnemyController> stateMachine;
        // Todo: Monster animation 구현
        //protected Animator animator; 
        #endregion Variables

        #region Properties
        
        #endregion Properties

        #region Unity Methods
        protected virtual void Start()
        {
            stateMachine = new StateMachine<EnemyController>(this, new IdleState());
        }

        protected virtual void Update()
        {

        }
        #endregion Unity Methods

        #region Helper Methods

        #endregion Helper Methods
    }
}


using System.Collections;
using System.Collections.Generic;
using SwordEnchant.Core;
using UnityEngine;

namespace SwordEnchant.Characters
{
    public class EnemyController_Directional : EnemyController
    {
        #region Variables
        //private Vector3 _direction = Vector2.zero;
        //public Transform testTransform;

        private CharacterController _controller;
        #endregion Variables
        #region Unity Methods
        protected override void Start()
        {
            base.Start();
            
            stateMachine.AddState(new MoveState());

            //_controller = GetComponent<CharacterController>();
            
           // _direction = (transform.position - testTransform.position).normalized; 
           // _direction.z = 0f;
            
        }
        #endregion Unity Methods

        #region Move Strategy Methods
        // public override void Move()
        // {
        //     //_controller.Move(_direction * 100 * Time.deltaTime);
        // }
        #endregion Move Strategy Method
    }
}

using System.Collections;
using System.Collections.Generic;
using SwordEnchant.Core;
using UnityEngine;

namespace SwordEnchant.Characters
{
    [RequireComponent(typeof(CharacterController))]
    public abstract class EnemyController : MonoBehaviour, IMoveable
    {
        #region Variables
        protected StateMachine<EnemyController> stateMachine;
        // Todo: Monster animation 구현
        //protected Animator animator; 
        private Transform _target = null;
        public Transform Target => _target;

        protected Vector3 _direction = Vector3.zero;
        public Vector3 Direction => _direction;
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
        public abstract void Move();
        public abstract void CalculateDirection();
        #endregion Abstract Methods
        #region Helper Methods
        public void FindPlayer()
        {
            GameObject go = GameObject.FindGameObjectWithTag("Player");
            if (go == null)
            {
                Debug.LogWarning("Player 게임 오브젝트를 현재 씬에서 찾을 수 없습니다");
                return;
            }
            else 
            {
                _target = go.transform;
            }
        }
        #endregion Helper Methods
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Characters
{
    public class MoveBehaviour : GenericBehaviour
    {
        #region Speed 
        // TODO: Change Stat Component
        public float speed = 1.0f;
        #endregion Speed

        #region Caching
        private CircleCollider2D circleCollider;
        private Transform myTransform;
        #endregion Caching

        #region Unity Methods
        private void Start()
        {
            myTransform = transform;
            circleCollider = GetComponent<CircleCollider2D>();

            behaviourController.SubScribeBehaviour(this);
            behaviourController.RegisterBehaviour(behaviourCode);
        }
        #endregion Unity Methods
        #region Mamagement Methods
        void MovementManagement(float horizontal, float vertical)
        {
            Vector2 direction = new Vector2(horizontal, vertical).normalized * speed * Time.deltaTime;
            behaviourController.GetRigidbody.velocity = direction;

            if (horizontal == 0 && vertical == 0)
                behaviourController.GetRigidbody.velocity = Vector2.zero;

            // flip
            if (horizontal < 0)
                myTransform.localScale = new Vector3(1f, 1f, 1f);
            else if (horizontal > 0)
                myTransform.localScale = new Vector3(-1f, 1f, 1f);
        }
        #endregion Management Methods

        #region Override Methods
        public override void LocalFixedUpdate()
        {
            MovementManagement(behaviourController.GetH, behaviourController.GetV);
        }
        #endregion Override Methods
    }
}


using SwordEnchant.EventBus;
using SwordEnchant.Managers;
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
        private Animator myAnimator;
        private CharacterStat stat;
        #endregion Caching

        #region Unity Methods
        private void Start()
        {
            myTransform = transform;
            circleCollider = GetComponent<CircleCollider2D>();
            myAnimator = GetComponentInChildren<Animator>();
            stat = GetComponent<CharacterStat>();

            behaviourController.SubScribeBehaviour(this);
            behaviourController.RegisterBehaviour(behaviourCode);
            speed = stat.characterObject.Stats.speed.ModifiedValue;

            stat.characterObject.Stats.OnChangedStats += (characterStat) =>
            {
                speed = stat.characterObject.Stats.speed.ModifiedValue;
            };
        }
        private void OnEnable()
        {
            BattleEventBus.Subscribe(BattleEventType.DIE, Die);
        }

        private void OnDisable()
        {
            BattleEventBus.Unsubscribe(BattleEventType.DIE, Die);
        }
        #endregion Unity Methods
        #region Mamagement Methods
        void MovementManagement(float horizontal, float vertical)
        {
            Vector2 direction = new Vector2(horizontal, vertical).normalized * 300  * speed * Time.deltaTime;
            behaviourController.GetRigidbody.velocity = direction;

            if (horizontal == 0 && vertical == 0)
            {
                behaviourController.GetRigidbody.velocity = Vector2.zero;
                if (myAnimator != null)
                    myAnimator.SetBool("IsMove", false);
            }
            else
            {
                if (myAnimator != null)
                    myAnimator.SetBool("IsMove", true);
            }


            // flip
            if (horizontal < 0)
                myTransform.localScale = new Vector3(-1f, 1f, 1f);
            else if (horizontal > 0)
                myTransform.localScale = new Vector3(1f, 1f, 1f);
        }

        #endregion Management Methods

        #region Override Methods
        public override void LocalFixedUpdate()
        {
            MovementManagement(behaviourController.GetH, behaviourController.GetV);
        }
        #endregion Override Methods

        public void Die()
        {
            myAnimator.SetTrigger("Dead");

            UIManager.Instance.OpenGameOverPanel();

            Time.timeScale = 0f;
        }
    }
}


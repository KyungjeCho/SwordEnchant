using SwordEnchant.Characters;
using SwordEnchant.Managers;
using SwordEnchant.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Projectile
{
    public class SwordController : ProjectileController
    {
        private Transform playerTr;
        private Animator animator;

        // Start is called before the first frame update
        void Start()
        {
            playerTr = GameObject.Find("Player").transform;
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (animator == null)
                animator = GetComponent<Animator>();
            
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && 
                animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                PoolManager.Instance.Push(GetComponent<Poolable>());
            }
        }

        public override void OnEnter()
        {
            if (playerTr == null)
                playerTr = GameObject.Find(GameObjectName.Player).transform;

            BehaviourController bc = playerTr.GetComponent<BehaviourController>();

            if (bc == null)
                return;

            SetPosition(bc.GetDir);
        }

        public override void SetTargetObject(Transform target)
        {
            
        }

        public override void SetTargetObject()
        {
            
        }

        public void SetPosition(Vector3 direction)
        {
            if (playerTr == null)
                playerTr = GameObject.Find("Player").transform;

            transform.position = playerTr.position + (direction * 2f);

            
            if (direction.x < 0f && transform.localScale.x > 0.0f) // flip
                transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
            else if (direction.x > 0f && transform.localScale.x < 0.0f)
                transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
        }

        public void SetAngle(Vector3 direction)
        {

            transform.rotation = Quaternion.Euler(direction);
        }
    }

}
using SwordEnchant.Managers;
using SwordEnchant.Util;
using SwordEnchant.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Animations;
using UnityEngine;

namespace SwordEnchant.Projectile
{
    public class BearTrapController : ProjectileController
    {
        #region Variables
        private Transform playerTr;
        private Vector2 direction;

        public float speed = 0.01f;
        public float timer = 0f;

        private Vector3 currentPos;
        private Animator myAnimator;

        private int OnTrapID = Animator.StringToHash("OnTrap");
        private int DefaultID = Animator.StringToHash("Default");
        #endregion Variables

        public override void OnEnter()
        {
            base.OnEnter();

            if (parent == null)
                parent = Resources.Load(PathName.WeaponObjectPath + "/BearTrap") as WeaponObject;
            collided = false;
            myRigidbody2D = GetComponent<Rigidbody2D>();
            myAnimator = GetComponent<Animator>();

            myAnimator.SetTrigger(DefaultID);

            transform.position = GameManager.Instance.playerTr.position;
            if (target != null && parent != null)
            {
                direction = (target.position - transform.position).normalized;
                float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                //transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
                //myRigidbody2D.AddForce(direction * parent.Stats.speed.ModifiedValue);
            }
            else
            {
                Vector3 randDir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
                direction = (randDir - transform.position).normalized;
                float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                //transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
                //myRigidbody2D.AddForce(direction * parent.Stats.speed.ModifiedValue);
            }

            StartCoroutine(SelfDestruct());

            timer = 0f;

            currentPos = GameManager.Instance.playerTr.position;
        }

        public void Update()
        {
            if (timer < 1f)
            {
                timer += speed * Time.deltaTime;
                transform.position = Vector3.Slerp(currentPos, direction * 0.6f, timer);
            }
        }
        protected override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);

            if (other.tag == "Enemy")
            {
                collided = false;

                //PoolManager.Instance.Push(GetComponent<Poolable>());
                if (myAnimator == null)
                    myAnimator = GetComponent<Animator>();
                myAnimator.SetTrigger(OnTrapID);

                StartCoroutine(SelfDestruct(1f));
            }

        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Enemy")
            {
                collided = false;
            }
        }
        public override void SetTargetObject(Transform target)
        {
            this.target = target;
        }

        public override void SetTargetObject()
        {
            target.position = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
        }

        public IEnumerator SelfDestruct()
        {
            yield return new WaitForSeconds(timeToSelfDestruct);
            PoolManager.Instance.Push(GetComponent<Poolable>());
        }
        public IEnumerator SelfDestruct(float time)
        {
            yield return new WaitForSeconds(time);
            PoolManager.Instance.Push(GetComponent<Poolable>());
        }
    }
}


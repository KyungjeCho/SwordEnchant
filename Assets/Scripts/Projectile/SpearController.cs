using SwordEnchant.Characters;
using SwordEnchant.Managers;
using SwordEnchant.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Projectile
{
    [RequireComponent(typeof(Poolable))]
    public class SpearController : ProjectileController
    {
        private Transform playerTr;
        private Animator animator;

        private Vector2 endPos;
        private Rigidbody2D rigidbody2D;

        public float force;
        public float height;
        public bool isGround = false;
        public bool isPlayEffect = false;
        public EffectList effectIndex;
        public override void OnEnable()
        {
            base.OnEnable();

            if (playerTr == null)
                playerTr = GameManager.Instance.playerTr;

            if (rigidbody2D == null)
                rigidbody2D = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position.y < endPos.y)
                isGround = true;
        }
        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            base.OnTriggerEnter2D(collision);
            if (collision.CompareTag("Enemy") && collided == false && isGround)
            {
                collided = true;
                Poolable poolable = GetComponent<Poolable>();
                if (poolable.isUsing)
                    PoolManager.Instance.Push(GetComponent<Poolable>());
                else
                    Destroy(gameObject);
            }
        }

        private void FixedUpdate()
        {
            if (isGround == false)
            {
                rigidbody2D.AddForce(Vector2.down * Time.fixedDeltaTime * force);
            }
            else
            {
                if (isPlayEffect == false)
                {
                    EffectManager.Instance.EffectOneShot((int)effectIndex, transform.position);
                    isPlayEffect = true;
                }
                isGround = true;
                rigidbody2D.velocity = Vector2.zero;
                StartCoroutine(SelfDestruct());
            }
        }
        public override void OnEnter()
        {
            base.OnEnter();

            SetTargetObject();

            endPos = target.position;

            SetPosition();
            isGround = false;
        }

        public override void SetTargetObject(Transform target)
        {
            
        }

        public override void SetTargetObject()
        {
            Scanner scanner = GameManager.Instance.scanner;
            target = scanner.targets[Random.Range(0, scanner.targets.Length)].transform;

            if (target == null)
            {
                int random = Random.Range(0, 360);
                float x = Mathf.Cos(random * Mathf.Deg2Rad) * 5f;
                float y = Mathf.Sin(random * Mathf.Deg2Rad) * 5f;

                Vector2 pos = transform.position + new Vector3(x, y, 0);
                target = new GameObject().transform;
                target.position = pos;
            }
        }

        public void SetPosition()
        {
            transform.position = endPos + Vector2.up * height;
        }
        public IEnumerator SelfDestruct()
        {
            yield return new WaitForSeconds(timeToSelfDestruct);
            PoolManager.Instance.Push(GetComponent<Poolable>());
        }
    }
}
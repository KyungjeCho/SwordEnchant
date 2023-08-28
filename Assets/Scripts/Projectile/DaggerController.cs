using SwordEnchant.Characters;
using SwordEnchant.Managers;
using SwordEnchant.Util;
using SwordEnchant.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SwordEnchant.Projectile
{
    public class DaggerController : ProjectileController
    {
        private Transform playerTr;
        private Rigidbody2D myRigidbody2D;

        // Start is called before the first frame update
        public override void Awake()
        {
            base.Awake();

            myRigidbody2D = GetComponent<Rigidbody2D>();
            playerTr = GameManager.Instance.playerTr;
        }

        public override void OnEnter()
        {
            base.OnEnter();

            SetPosition();

            SetDirection();

            myRigidbody2D.velocity = direction * stats.speed.ModifiedValue;

            float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

            StartCoroutine(SelfDestruct());
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);

            if (other.CompareTag(TagAndLayerKey.Enemy))
            {
                PoolManager.Instance.Push(GetComponent<Poolable>());
            }
        }

        public void SetDirection()
        {
            BehaviourController bc = playerTr.GetComponent<BehaviourController>();

            Vector2 emptyDir = Vector2.zero;

            if (bc.GetDir.x < -0.4f)
                emptyDir += Vector2.left;
            if (bc.GetDir.x > 0.4f)
                emptyDir += Vector2.right;
            if (bc.GetDir.y > 0.4f)
                emptyDir += Vector2.up;
            if (bc.GetDir.y < -0.4f)
                emptyDir += Vector2.down;

            emptyDir.Normalize();
            direction = emptyDir;
        }
        public void SetPosition()
        {
            transform.position = playerTr.position;
        }
    }

}

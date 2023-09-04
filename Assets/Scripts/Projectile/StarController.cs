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
    public class StarController : ProjectileController
    {
        private Transform playerTr;
        private Rigidbody2D myRigidbody2D;

        public float rotSpeed;
        public float space;
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

            StartCoroutine(SelfDestruct());
        }
        public void Update()
        {
            transform.Rotate(new Vector3(0f, 0f, Time.deltaTime * rotSpeed));

            // 카메라 모서리에 부딪쳤을 경우
            if (transform.position.y > CameraRes.top.y - space) // top
                myRigidbody2D.velocity = new Vector2(
                    myRigidbody2D.velocity.x, -Mathf.Abs(myRigidbody2D.velocity.y));
            if (transform.position.y < CameraRes.bottom.y + space) // bottom
                myRigidbody2D.velocity = new Vector2(
                    myRigidbody2D.velocity.x, Mathf.Abs(myRigidbody2D.velocity.y));
            if (transform.position.x < CameraRes.left.x + space)
                myRigidbody2D.velocity = new Vector2(
                    Mathf.Abs(myRigidbody2D.velocity.x), myRigidbody2D.velocity.y);
            if (transform.position.x > CameraRes.right.x - space)
                myRigidbody2D.velocity = new Vector2(
                    -Mathf.Abs(myRigidbody2D.velocity.x), myRigidbody2D.velocity.y);
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);

            if (other.CompareTag(TagAndLayerKey.Enemy))
            {
                SetDirection();
                myRigidbody2D.velocity = direction * stats.speed.ModifiedValue;
            }
        }

        public void SetDirection()
        {
            Vector2 randCirclePos = Random.insideUnitCircle;
            direction = randCirclePos.normalized;
        }
        public void SetPosition()
        {
            transform.position = playerTr.position;
        }
    }

}

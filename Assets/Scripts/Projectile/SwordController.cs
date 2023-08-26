using SwordEnchant.Characters;
using SwordEnchant.Core;
using SwordEnchant.Data;
using SwordEnchant.Managers;
using SwordEnchant.Util;
using SwordEnchant.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Projectile
{
    [RequireComponent(typeof(Poolable))]
    public class SwordController : ProjectileController
    {
        private Transform playerTr;
        private Animator animator;

        private Rigidbody2D rigidbody2D;
        public float startSpeed = 500;

        private bool isPoolable;
        public override void OnEnable()
        {
            base.OnEnable();

            if (rigidbody2D == null)
                rigidbody2D = GetComponent<Rigidbody2D>();

            if (playerTr == null)
                playerTr = GameManager.Instance.playerTr;

        }
        // Start is called before the first frame update
        void Start()
        {
            if (playerTr == null)
                playerTr = GameManager.Instance.playerTr;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            rigidbody2D.AddForce(direction * Time.fixedDeltaTime * startSpeed);

            if (rigidbody2D.velocity.magnitude > parent.Stats.speed.ModifiedValue)
                rigidbody2D.velocity = direction * parent.Stats.speed.ModifiedValue;
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
            if (other.CompareTag("Enemy") && collided == false)
            {
                collided = true;
                Poolable poolable = GetComponent<Poolable>();
                if (poolable.isUsing)
                    PoolManager.Instance.Push(GetComponent<Poolable>());
                else
                    Destroy(gameObject);
            }
        }

        public override void OnEnter()
        {
            SoundClip clip = DataManager.SoundData().soundClips[(int)shootSound];
            SoundManager.Instance.PlayEffectSound(clip, playerTr.position, clip.maxVolume);

            collided = false;

            SetPosition();

            SetTargetObject();

            CalcDirectionRatation(-90f);
        }

        public override void SetTargetObject(Transform target)
        {
            
        }

        public override void SetTargetObject()
        {
            target = GameManager.Instance.scanner.nearestTarget;
        }

        public void SetPosition()
        {
            if (playerTr == null)
                playerTr = GameManager.Instance.playerTr;

            transform.position = playerTr.position;
        }

        public void SetAngle(Vector3 direction)
        {

            transform.rotation = Quaternion.Euler(direction);
        }
    }

}
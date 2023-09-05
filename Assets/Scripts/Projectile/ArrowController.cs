using SwordEnchant.Managers;
using SwordEnchant.Util;
using SwordEnchant.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SwordEnchant.Projectile
{
    public class ArrowController : ProjectileController
    {
        #region Variables
        private Transform playerTr;
        private Rigidbody2D myRigidbody2D;
        private Scanner scanner;

        public int Number { get; set; } = 0;
        #endregion Variables

        public override void Awake()
        {
            base.Awake();

            myRigidbody2D = GetComponent<Rigidbody2D>();
            playerTr = GameManager.Instance.playerTr;
            scanner = GameManager.Instance.scanner;
        }

        public override void OnEnter()
        {
            base.OnEnter();

            SetPosition();

            SetTargetObject();
            
            CalcDirectionRotation();
            
            myRigidbody2D.velocity = direction * stats.speed.ModifiedValue;

            StartCoroutine(SelfDestruct());
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);

            if (other.tag == "Enemy")
            {
                PoolManager.Instance.Push(GetComponent<Poolable>());
            }

        }
        public void SetTargetObject()
        {
            if (scanner == null)
                scanner = GameManager.Instance.scanner;

            scanner.Scan();

            if (Number == 0)
            {
                target = scanner.nearestTarget;
            }
            else
            {
                
                if (scanner.targets.Length != 0)
                    target = scanner.targets[Random.Range(0, scanner.targets.Length)].transform;
                else
                    target = null;
            }
        }
        public void SetPosition()
        {
            transform.position = playerTr.position;
        }
    }
}


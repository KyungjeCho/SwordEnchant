using SwordEnchant.Managers;
using SwordEnchant.Util;
using SwordEnchant.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SwordEnchant.Projectile
{
    public class BoomerangController : ProjectileController
    {
        #region Variables
        private Transform playerTr;
        private Rigidbody2D myRigidbody2D;
        private Scanner scanner;

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
            //parent = Resources.Load(PathName.WeaponObjectPath + "/" + GameObjectName.Bow) as WeaponObject;
            //collided = false;
            //myRigidbody2D = GetComponent<Rigidbody2D>();

            //transform.position = GameManager.Instance.playerTr.position;
            //if (target != null && parent != null)
            //{
            //    direction = (target.position - transform.position).normalized;
            //    float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //    transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            //    myRigidbody2D.AddForce(direction * parent.Stats.speed.ModifiedValue);
            //}
            //else
            //{
            //    Vector3 randDir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
            //    direction = (randDir - transform.position).normalized;
            //    float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //    transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            //    myRigidbody2D.AddForce(direction * parent.Stats.speed.ModifiedValue);
            //}

            StartCoroutine(SelfDestruct());
        }

        public void Update()
        {
            transform.Rotate(new Vector3(0f, 0f, Time.deltaTime * 400f));
        }

        public void FixedUpdate()
        {
            myRigidbody2D.AddForce(-direction * stats.speed.ModifiedValue);
        }

        public void SetTargetObject()
        {
            if (scanner == null)
                scanner = GameManager.Instance.scanner;

            target = scanner.targets[Random.Range(0, scanner.targets.Length)].transform;
        }
        public void SetPosition()
        {
            transform.position = playerTr.position;
        }
    }
}


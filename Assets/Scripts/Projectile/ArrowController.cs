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

        #endregion Variables

        public override void OnEnter()
        {
            base.OnEnter();

            parent = Resources.Load(PathName.WeaponObjectPath + "/" + GameObjectName.Bow) as WeaponObject;
            collided = false;
            myRigidbody2D = GetComponent<Rigidbody2D>();

            transform.position = GameManager.Instance.playerTr.position;
            if (target != null && parent != null)
            {
                Vector2 direction = (target.position - transform.position).normalized;
                float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
                myRigidbody2D.AddForce(direction * parent.Stats.speed.ModifiedValue);
            }
            else
            {
                Vector3 randDir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
                Vector2 direction = (randDir - transform.position).normalized;
                float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
                myRigidbody2D.AddForce(direction * parent.Stats.speed.ModifiedValue);
            }
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);

            if (other.tag == "Enemy")
            {
                collided = true;

                PoolManager.Instance.Push(GetComponent<Poolable>());
            }

        }
        public override void SetTargetObject(Transform target)
        {
            this.target = target;
        }

        public override void SetTargetObject()
        {
            if (playerTr == null)
                playerTr = GameObject.Find(GameObjectName.Player).transform;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(playerTr.position, 10f, LayerMask.GetMask(TagAndLayerKey.Enemy));

            if (colliders.Length > 0)
            {
                Collider2D coll = colliders.OrderBy(x => Vector2.Distance(playerTr.position, x.transform.position)).ToList()[0];
                this.target = coll.gameObject.transform;
            }
        }

        public IEnumerator SelfDestruct()
        {
            yield return new WaitForSeconds(timeToSelfDestruct);
            PoolManager.Instance.Push(GetComponent<Poolable>());
        }
    }
}


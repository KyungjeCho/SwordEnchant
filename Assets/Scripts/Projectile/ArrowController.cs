using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Projectile
{
    public class ArrowController : ProjectileController
    {
        #region Variables
        public float speed = 100.0f;
        public Transform Target;
        #endregion Variables
        void OnEnable()
        {
            if (Target != null)
            {
                Vector2 direction = (Target.position - transform.position).normalized;
                float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
                _rigidbody2d.AddForce(direction * speed);
            }
            else
            {
                Vector2 randomDir = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f)).normalized;
                float rotationZ = Mathf.Atan2(randomDir.y, randomDir.x) * Mathf.Rad2Deg;

                transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
                _rigidbody2d.AddForce(randomDir * speed);
            }

        }
        public override void SetTargetObject(Transform target)
        {
            _target = target;
        }

        public override void SetTargetObject()
        {
            
        }
    }
}


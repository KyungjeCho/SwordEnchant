using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Projectile
{
    public class ArrowController : ProjectileController
    {
        #region Variables
        public float speed = 100.0f;
        #endregion Variables
        void OnEnable()
        {
            Vector2 randomDir = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f)).normalized;
            float rotationZ = Mathf.Atan2(randomDir.y, randomDir.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            _rigidbody2d.AddForce(randomDir * speed);
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


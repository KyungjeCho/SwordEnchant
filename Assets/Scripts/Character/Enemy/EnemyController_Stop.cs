using System.Collections;
using System.Collections.Generic;
using SwordEnchant.Core;
using UnityEngine;

namespace SwordEnchant.Characters
{
    public class EnemyController_Stop : EnemyController, IDamagable
    {
        #region Variables
        private CharacterController _controller;

        // TODO: health 부분은 Attribute data 로 변경 예정
        public float maxHealth => 100f;
        private float health;
        #endregion Variables

        #region Properties
        #endregion Properties
        #region Unity Methods
        protected override void Start()
        {
            base.Start();

            _controller = GetComponent<CharacterController>();          

            health = maxHealth;  
        }
        #endregion Unity Methods

        #region Move Methods
        public override void Move()
        {
            return;
        }
        public override void CalculateDirection()
        {
            _direction = Vector3.zero;
        }
        #endregion Move Method

        #region Damagable Methods
        public bool IsAlive => (health > 0);
        public void TakeDamage(float damage, float criticalDamage, float criticalProb, GameObject hitEffectPrefabs, Vector3 hitPoint)
        {
            if (!IsAlive)
            {
                return;
            }

            health -= damage;
            Debug.Log("데미지: " + damage);
            
            if (IsAlive)
            {

            }
            else
            {

            }
        }
        #endregion Damagable Methods
        #region Helper Methods
        #endregion Helper Methods
    }
}

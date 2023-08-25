using System.Collections;
using System.Collections.Generic;
using SwordEnchant.Core;
using SwordEnchant.Util;
using UnityEngine;

namespace SwordEnchant.Characters
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour, IDamagable
    {
        #region Variables
        public float health;
        private float maxHealth = 100f;

        #endregion Variables

        #region Unity Methods
        private void Update() 
        {
            
        }
        #endregion Unity Methods   

        #region IDamagable Interface
        public bool IsAlive => (health > 0);

        public void TakeDamage(float damage, float criticalDamage, float criticalProb, GameObject hitEffect, Vector3 hitPoint)
        {
            float totalDamage = Formula.TotalDamage(damage, 1f, 0f, Formula.IsCritical(criticalProb));
            health -= totalDamage;
        }
        #endregion IDamagable Interface
    }
}


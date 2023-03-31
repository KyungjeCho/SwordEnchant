using System.Collections;
using System.Collections.Generic;
using SwordEnchant.Core;
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

        public void TakeDamage(float damage, GameObject hitEffect, Vector3 hitPoint)
        {
            Debug.Log("플레이어 충돌");
        }
        #endregion IDamagable Interface
    }
}


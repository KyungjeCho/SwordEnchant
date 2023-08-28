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
        #region Variables
        private Transform playerTr;
        private Animator animator;
        
        // ���� ���� Sword Projectile �� ������ ���� 
        [SerializeField]
        private float spaceY;

        // ���� ���� Sword �߿� ���° ����
        [HideInInspector]
        public int Number { get; set; } = 0;

        public LayerMask targetMask;

        public ManualCollision attackCollision;

        #endregion Varaibles

        public override void Awake()
        {
            base.Awake();

            playerTr = GameManager.Instance.playerTr;
            animator = GetComponent<Animator>();
            attackCollision = GetComponent<ManualCollision>();
        }

        private void Update()
        {
            
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {

        }

        public override void OnEnter()
        {
            base.OnEnter();
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

        public void ExecuteAttack()
        {
            Collider2D[] colliders = attackCollision?.CheckOverlapBox(targetMask);

            foreach (Collider2D col in colliders)
            {
                //col.gameObject.GetComponent<IDamagable>()?.TakeDamage(damage, effectPrefab);
            }

        }
    }

}
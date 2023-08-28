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

        [HideInInspector]
        public ManualCollision attackCollision;

        #endregion Varaibles

        public override void Awake()
        {
            base.Awake();

            playerTr = GameManager.Instance.playerTr;
            animator = GetComponent<Animator>();
            attackCollision = GetComponent<ManualCollision>();
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {

        }

        public override void OnEnter()
        {
            base.OnEnter();

            SetPosition();

            StartCoroutine(SelfDestruct());
        }

        public void SetPosition()
        {
            if (playerTr == null)
                playerTr = GameManager.Instance.playerTr;


            if (Number % 2 == 0)
            {
                // ���� ���� ������ �ٶ󺸰� ������
                if (playerTr.localScale.x < 0)
                {
                    if (transform.localScale.x > 0)
                        transform.localScale = new Vector3(transform.localScale.x * -1,
                                                        transform.localScale.y,
                                                        transform.localScale.z);
                    transform.position = playerTr.position + Vector3.left * 3f +
                                        Vector3.up * spaceY * (Number / 2);
                } 
                else  // ���� �÷��̾ ������ �ٶ󺸰� ������
                {
                    if (transform.localScale.x < 0)
                        transform.localScale = new Vector3(transform.localScale.x * -1,
                                                            transform.localScale.y,
                                                            transform.localScale.z);
                    transform.position = playerTr.position + Vector3.right * 3f +
                                        Vector3.up * spaceY * (Number / 2);
                }
            }
            else
            {
                // ���� �÷��̾ ������ �ٶ󺸰� ������
                if (playerTr.localScale.x > 0)
                {
                    if (transform.localScale.x > 0)
                        transform.localScale = new Vector3(transform.localScale.x * -1,
                                                        transform.localScale.y,
                                                        transform.localScale.z);
                    transform.position = playerTr.position + Vector3.left * 3f +
                                        Vector3.up * spaceY * (Number / 2);
                }
                else // ���� ���� ������ �ٶ󺸰� ������
                {
                    if (transform.localScale.x < 0)
                        transform.localScale = new Vector3(transform.localScale.x * -1,
                                                        transform.localScale.y,
                                                        transform.localScale.z);
                    transform.position = playerTr.position + Vector3.right * 3f +
                                        Vector3.up * spaceY * (Number / 2);
                }
            }
        }

        public void ExecuteAttack()
        {
            Collider2D[] colliders = attackCollision?.CheckOverlapBox(targetMask);

            foreach (Collider2D col in colliders)
            {
                col.gameObject.GetComponent<IDamagable>()?.TakeDamage(
                    stats.damage.ModifiedValue, stats.criticalDamage.ModifiedValue,
                    stats.criticalProb.ModifiedValue, null, col.transform.position);

            }

        }
    }

}
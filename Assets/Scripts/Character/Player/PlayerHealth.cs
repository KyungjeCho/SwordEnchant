using SwordEnchant.Core;
using SwordEnchant.EventBus;
using SwordEnchant.Managers;
using SwordEnchant.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SwordEnchant.Characters
{
    public class PlayerHealth : MonoBehaviour, IDamagable
    {
        #region Variables
        public float health = 100f;
        public Transform healthHUD;

        private float totalHealth;
        private Image healthBar;
        private CharacterStat stat;
        private DamageFlash damageFlash;

        public float TotalHealth => totalHealth;

        public Action HealthUpEvent;
        #endregion Variables

        #region Unity Methods
        private void Awake()
        {
            stat = GetComponent<CharacterStat>();
            health = stat.characterObject.Stats.maxHp.ModifiedValue;
            totalHealth = health;

            healthBar = healthHUD.Find("Canvas/HealthBar/FrontImg").GetComponent<Image>();
        }

        void Start()
        {
            stat = GetComponent<CharacterStat>();
            health = stat.characterObject.Stats.maxHp.ModifiedValue;
            totalHealth = health;

            healthBar = healthHUD.Find("Canvas/HealthBar/FrontImg").GetComponent<Image>();
            damageFlash = GetComponent<DamageFlash>();

            HealthUpEvent += UpdateHealth;
            stat.characterObject.Stats.OnChangedStats += (characterStats) => UpdateHealth();
        }
        #endregion Unity Methods

        public bool IsAlive => health > 0f;
        public void TakeDamage(float damage, float criticalDamage, float criticalProb, GameObject hitEffectPrefabs, Vector3 hitPoint)
        {
            float totalDamage = Formula.TotalDamage(damage, criticalDamage, 0f, Formula.IsCritical(criticalProb));
            health -= totalDamage;

            UIManager.Instance.CreateDamageText(transform.position, -(int)totalDamage);

            // 카메라 세이크 효과
            CameraShake shakeEff = Camera.main.GetComponent<CameraShake>();
            shakeEff.ShakeEff();

            // 데미지 플래쉬
            damageFlash.CallDamageFlash();

            // 블러드 이펙트
            if (health < totalHealth * 0.3f)
            {
                UIManager.Instance.OpenBloodEffImg();
            }

            // 이펙트 사운드 출력
            SoundManager.Instance.PlayEffectSound(DataManager.SoundData().soundClips[(int)SoundList.Hurt]);
            UpdateHealthBar();

            if (IsAlive != true)
            {
                BattleEventBus.Publish(BattleEventType.DIE);
            }
        }

        public void UpdateHealthBar()
        {
            healthBar.fillAmount = health / totalHealth;
        }

        public void UpdateHealth()
        {
            totalHealth = stat.characterObject.Stats.maxHp.ModifiedValue;
        }
    }
}


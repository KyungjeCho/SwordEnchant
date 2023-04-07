using SwordEnchant.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Data
{
    [CreateAssetMenu(fileName = "Monster Stats", menuName = "Stats System/Monster Stats")]
    public class MonsterStats : ScriptableObject
    {
        public ModifiableFloat  health;
        public ModifiableFloat  speed;
        public ModifiableFloat  damage;
        public ModifiableFloat  defence;
        public ModifiableFloat  size;

        public MonsterList monsterIndex;

        public Action<MonsterStats> OnChangedStats;

        public float Health
        {
            get; set;
        }

        public float HealthPercentage
        {
            get
            {
                float _health = Health;
                float _maxHealth = _health;
                _maxHealth = health.ModifiedValue;

                return (_maxHealth > 0 ? ((float) _health / (float)_maxHealth) : 0f);
            }
        }

        public void OnEnable()
        {
            Initialize();
        }

        public float AddHealth(int value)
        {
            Health += value;

            OnChangedStats?.Invoke(this);

            return Health;
        }

        [NonSerialized]
        private bool isInitialized = false;
        public void Initialize()
        {
            if (isInitialized)
            {
                return;
            }

            isInitialized = true;

            MonsterClip clip = DataManager.MonsterData().monsterClips[(int)monsterIndex];
            
            health = new ModifiableFloat(OnModifiedValue);
            speed = new ModifiableFloat(OnModifiedValue);
            damage = new ModifiableFloat(OnModifiedValue);
            defence = new ModifiableFloat(OnModifiedValue);
            size = new ModifiableFloat(OnModifiedValue);

            health.BaseValue = (int)clip.health;
            speed.BaseValue = clip.speed;
            damage.BaseValue = (int)clip.damage;
            defence.BaseValue = (int)clip.defence;
            size.BaseValue = clip.size;

            Health = health.ModifiedValue;
        }

        private void OnModifiedValue(ModifiableInt value)
        {
            OnChangedStats?.Invoke(this);
        }
        private void OnModifiedValue(ModifiableFloat value)
        {
            OnChangedStats?.Invoke(this);
        }
        
    }
}

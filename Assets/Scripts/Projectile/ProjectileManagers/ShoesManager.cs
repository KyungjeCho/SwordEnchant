using SwordEnchant.Characters;
using SwordEnchant.Data;
using SwordEnchant.Managers;
using SwordEnchant.Util;
using SwordEnchant.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SwordEnchant.Projectile
{
    public class ShoesManager : BaseProjectileManager
    {
        private int currentCount;
        private Collider2D[] colliders;
        private Transform target;

        protected override void Update()
        {
            base.Update();
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            if (weaponObject == null)
            {
                weaponObject = Resources.Load("WeaponSystem/Boomerang") as WeaponObject;
            }

            Transform playerTr = GameManager.Instance.playerTr;
            CharacterStat playerStat = playerTr.GetComponent<CharacterStat>();

            playerStat.characterObject.Stats.speed.AddModifier(new CharacterBuff(0.1f));
        }

        public override void Shot()
        {
            
        }
    }

}

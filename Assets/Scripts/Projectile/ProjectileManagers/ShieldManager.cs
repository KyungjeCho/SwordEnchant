using SwordEnchant.Managers;
using SwordEnchant.WeaponSystem;

using UnityEngine;

namespace SwordEnchant.Projectile
{
    public class ShieldManager : BaseProjectileManager
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

            playerStat.characterObject.Stats.defence.AddModifier(new CharacterBuff(0.5f));
        }

        public override void Shot()
        {

        }
    }

}

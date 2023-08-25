using SwordEnchant.Managers;
using SwordEnchant.UI;
using SwordEnchant.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Projectile
{
    public abstract class BaseProjectileManager : MonoBehaviour
    {
        #region Variables
        public WeaponObject weaponObject;

        [HideInInspector]
        public SlotNodeController slotUI;
        [HideInInspector]
        public CharacterStat stat;
        protected float elapsedTime = 0f;
        #endregion Variables

        #region Unity Methods
        protected virtual void Update()
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime > weaponObject.Stats.cooldown.ModifiedValue * stat.characterObject.Stats.cooldown.ModifiedValue)
            {
                Shot();
                elapsedTime = 0f;
            }

            if (slotUI != null)
            {
                slotUI.UpdateCooldown(elapsedTime / weaponObject.Stats.cooldown.ModifiedValue * stat.characterObject.Stats.cooldown.ModifiedValue);
            }
        }
        #endregion Unity Methods
        #region Virtual Methods
        protected virtual void OnEnable()
        {
            elapsedTime = 0.0f;

            slotUI = UIManager.Instance.CreateSlot();
            slotUI.InitUI(weaponObject.icon);

            stat = GameManager.Instance.playerTr.GetComponent<CharacterStat>();
        }

        private void OnDisable()
        {
            weaponObject.Stats.ClearModifier();
        }
        #endregion Virtual Methods

        #region Abstract Methods
        public abstract void Shot();

        #endregion Abstract Methods
    }

}

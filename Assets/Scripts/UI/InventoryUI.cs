using SwordEnchant.Weapon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SwordEnchant.UI
{
    [RequireComponent(typeof(EventTrigger))]
    public abstract class InventoryUI : MonoBehaviour
    {
        #region Variables
        public WeaponInventory inventory;
        private WeaponInventory previousInventory;

        public Dictionary<GameObject, WeaponInventorySlot> slotUIs = new Dictionary<GameObject, WeaponInventorySlot>();
        #endregion Variables

        #region Unity Methods
        private void Awake()
        {
            
        }
        private void Start()
        {
            
        }
        #endregion Unity Methods

        #region Methods
        public abstract void CreateSlots();

        public void OnPostUpdate(WeaponInventorySlot slot)
        {
            if (slot == null || slot.slotUI == null)
            {
                return;
            }

            slot.slotUI.transform.GetChild(0).GetComponent<Image>().sprite = slot.weapon.weaponIndex == WeaponList.None ? null : slot.weapon.icon;
        }
        #endregion Methods
    }
}


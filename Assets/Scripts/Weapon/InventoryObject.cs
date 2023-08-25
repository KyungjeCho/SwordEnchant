using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SwordEnchant.WeaponSystem
{
    [CreateAssetMenu(fileName = "New Inventory", menuName = "InventorySystem/Inventory")]
    public class InventoryObject : ScriptableObject
    {
        #region Variables

        [SerializeField]
        private Inventory container = new Inventory();

        public Action<WeaponList> OnSellItem;
        #endregion Variables

        #region Properties
        public WeaponInventorySlot[] Slots => container.slots;

        public int EmptySlotCount
        { 
            get
            {
                int counter = 0;
                foreach(WeaponInventorySlot slot in Slots)
                {
                    if (slot.weaponIndex == WeaponList.None)
                    {
                        counter++;
                    }
                }

                return counter;
            }
        }
        #endregion Properties

        #region Methods
        public bool AddItem(WeaponList weaponList, int amount)
        {
            WeaponInventorySlot slot = FindItemInInventory(weaponList);
            if (slot == null)
            {
                return false;
            }
            else
            {
                slot.AddAmount(amount);
            }

            return true;
        }

        public WeaponInventorySlot FindItemInInventory(WeaponList index)
        {
            return Slots.FirstOrDefault(i => i.weaponIndex == index);
        }

        public bool IsContainItem(WeaponList index)
        {
            return Slots.FirstOrDefault(i => i.weaponIndex == index) != null;
        }
        #endregion Methods

        public void SellWeapon(WeaponInventorySlot slotToUse)
        {
            if (slotToUse.weaponIndex == WeaponList.None)
                return;

            WeaponList weaponIndex = slotToUse.weaponIndex;
            slotToUse.UpdateSlot(slotToUse.weaponIndex, slotToUse.amount - 1);

            OnSellItem.Invoke(weaponIndex);
        }
    }
    [Serializable]
    public class Inventory
    {
        #region Variables
        public WeaponInventorySlot[] slots = new WeaponInventorySlot[24];
        #endregion Variables

        #region Methods
        public void Clear()
        {
            foreach (WeaponInventorySlot slot in slots)
            {
                slot.UpdateSlot(slot.weaponIndex, 0);
            }
        }

        public bool IsContain(WeaponList index)
        {
            return Array.Find(slots, i => i.weaponIndex == index) != null;
        }
        #endregion Methods
    }
}


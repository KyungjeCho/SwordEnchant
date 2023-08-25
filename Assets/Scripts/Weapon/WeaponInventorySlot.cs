using SwordEnchant.Projectile;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.WeaponSystem
{
    [Serializable]
    public class WeaponInventorySlot
    {
        #region Variables
        [NonSerialized]
        public GameObject slotUI;
        [NonSerialized]
        public InventoryObject parent;

        [NonSerialized]
        public Action<WeaponInventorySlot> OnPreUpdate;
        [NonSerialized]
        public Action<WeaponInventorySlot> OnPostUpdate;

        public WeaponList weaponIndex;
        public BaseProjectileManager pm; // -> 

        public bool isEmpty;
        public int amount;
        #endregion Varaibles


        public WeaponInventorySlot() => UpdateSlot(WeaponList.None, 0);

        public WeaponInventorySlot(WeaponList index, int amount) => UpdateSlot(index, amount);

        public void RemoveWeapon() => UpdateSlot(weaponIndex, 0);
        public void AddAmount(int value) => UpdateSlot(weaponIndex, amount += value);


        public void UpdateSlot(WeaponList index, int amount)
        {
            if (amount <= 0)
            {
                return;
            }

            OnPreUpdate?.Invoke(this);
            this.weaponIndex    = index;
            this.amount         = amount;
            OnPostUpdate?.Invoke(this);
        }
    }
}


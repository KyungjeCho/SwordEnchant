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
        public Action<WeaponInventorySlot> OnPreUpdate;
        [NonSerialized]
        public Action<WeaponInventorySlot> OnPostUpdate;

        public WeaponList weaponIndex;
        public BaseProjectileManager pm;

        public bool isEmpty;
        #endregion Varaibles


        public WeaponInventorySlot() => UpdateSlot(WeaponList.None, true);

        public WeaponInventorySlot(WeaponList index, bool empty=false) => UpdateSlot(index, false);

        public void RemoveWeapon() => UpdateSlot(weaponIndex, true);
        public void AddAmount(int value) => UpdateSlot(weaponIndex, false);

        public void UpdateSlot(WeaponList index, bool empty)
        {
            OnPreUpdate?.Invoke(this);
            this.weaponIndex    = index;
            this.isEmpty        = empty;
            OnPostUpdate?.Invoke(this);
        }
    }
}


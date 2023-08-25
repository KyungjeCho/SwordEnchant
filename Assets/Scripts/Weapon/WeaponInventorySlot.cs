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
        [NonSerialized]
        public GameObject slotUI;
        [NonSerialized]
        public WeaponInventory parent;

        [NonSerialized]
        public Action<WeaponInventorySlot> OnPreUpdate;
        [NonSerialized]
        public Action<WeaponInventorySlot> OnPostUpdate;

        public WeaponObject weapon;
        public BaseProjectileManager pm;

        public bool isEmpty;

        //public WeaponInventorySlot() => UpdateSlot(new WeaponObject(), true);
        //public WeaponInventorySlot(WeaponObject weapon, bool isEmpty) => UpdateSlot(weapon, isEmpty);

        //public void RemoveWeapon() => UpdateSlot(new WeaponObject(), true);
        //public void AddWeapon(bool isEmpty) => UpdateSlot(weapon, isEmpty);

        //public void UpdateSlot(WeaponObject weapon, bool isEmpty = false)
        //{
        //    OnPreUpdate?.Invoke(this);

        //    this.weapon = weapon;
        //    this.isEmpty = isEmpty;

        //    OnPostUpdate?.Invoke(this);
        //}
    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Weapon
{
    [Serializable]
    public class WeaponInventorySlot
    {
        [NonSerialized]
        public GameObject slotUI;

        [NonSerialized]
        public Action<WeaponInventorySlot> OnPreUpdate;
        [NonSerialized]
        public Action<WeaponInventorySlot> OnPostUpdate;

        public Weapon weapon;

        public bool isEmpty;

        public WeaponInventorySlot() => UpdateSlot(new Weapon(), true);
        public WeaponInventorySlot(Weapon weapon, bool isEmpty) => UpdateSlot(weapon, isEmpty);

        public void RemoveWeapon() => UpdateSlot(new Weapon(), true);
        public void AddWeapon(bool isEmpty) => UpdateSlot(weapon, isEmpty);

        public void UpdateSlot(Weapon weapon, bool isEmpty = false)
        {
            OnPreUpdate?.Invoke(this);

            this.weapon = weapon;
            this.isEmpty = isEmpty;

            OnPostUpdate?.Invoke(this);
        }
    }
}


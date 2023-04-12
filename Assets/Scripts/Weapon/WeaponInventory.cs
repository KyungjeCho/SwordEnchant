using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace SwordEnchant.Weapon
{
    public class WeaponInventory : MonoBehaviour
    {
        public WeaponInventorySlot[] slots = new WeaponInventorySlot[6];
        
        private void Update()
        {
            foreach(WeaponInventorySlot slot in slots)
            {
                if (slot.isEmpty == true)
                    continue;

                if (slot.weapon.weaponIndex == WeaponList.None)
                    continue;

                slot.weapon.UpdateTimer(Time.deltaTime);
            }
        }

        public bool AddWeapon(WeaponObject weapon)
        {
            if (IsContain(weapon))
            {
                return false;
            }
            slots[GetFullSlotCount()].weapon = weapon;
            slots[GetFullSlotCount()].AddWeapon(false);

            return true;
        }

        public WeaponInventorySlot FindWeaponInInventory(WeaponObject weapon)
        {
            return slots.FirstOrDefault(i => i.weapon.clip.weaponName == weapon.clip.weaponName);
        }
        public void Clear()
        {
            foreach(WeaponInventorySlot slot in slots)
            {
                slot.UpdateSlot(new WeaponObject(), false);
            }
        }

        public bool IsContain(WeaponObject weaponObject)
        {
            return Array.Find(slots, i => i.weapon.clip.realID == weaponObject.clip.realID) != null;
        }

        public int GetFullSlotCount()
        {
            return Array.FindAll(slots, i => i.isEmpty == false).Length;
        }

        public int GetEmptySlotCount()
        {
            return Array.FindAll(slots, i => i.isEmpty == true).Length;
        }
    }
}


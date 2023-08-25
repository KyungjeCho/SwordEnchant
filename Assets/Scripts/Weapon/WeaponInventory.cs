using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace SwordEnchant.WeaponSystem
{
    public class WeaponInventory : MonoBehaviour
    {
        public WeaponInventorySlot[] slots = new WeaponInventorySlot[6];

        private void Start()
        {
            if (GetFullSlotCount() > 0)
            {
                foreach (WeaponInventorySlot slot in slots)
                {
                    if (slot.isEmpty == true)
                        continue;

                    if (slot.weaponIndex == WeaponList.None)
                        continue;

                    slot.pm.gameObject.SetActive(true);
                    //slot.weapon.OnEnter();
                }
            }
        }
        private void Update()
        {
            
            foreach (WeaponInventorySlot slot in slots)
            {
                if (slot.isEmpty == true)
                    continue;

                //if (slot.weaponObject.weaponIndex == WeaponList.None)
                //    continue;

                // TODO: change 
                //slot.weapon.UpdateTimer(Time.deltaTime);
            }
            
        }

        public bool AddWeapon(WeaponObject weapon)
        {
            //if (IsContain(weapon))
            //{
            //    return false;
            //}
            if (ProjectileManagersDB.Instance.GetPM(weapon.weaponIndex) == null)
                return false;

            //slots[GetFullSlotCount()].weaponObject = weapon;
            slots[GetFullSlotCount()].pm = ProjectileManagersDB.Instance.GetPM(weapon.weaponIndex);
            slots[GetFullSlotCount()].pm.gameObject.SetActive(true);
            slots[GetFullSlotCount()].isEmpty = false;
            //weapon.OnEnter();
            //slots[GetFullSlotCount()].AddWeapon(false);

            return true;
        }

        public WeaponInventorySlot FindWeaponInInventory(WeaponObject weapon)
        {
            return new WeaponInventorySlot(); // slots.FirstOrDefault(i => i.weaponObject.Clip.weaponName == weapon.Clip.weaponName);
        }
        public void Clear()
        {
            foreach(WeaponInventorySlot slot in slots)
            {
                //slot.UpdateSlot(new WeaponObject(), false);
            }
        }

        public bool IsContain(WeaponObject weaponObject)
        {
            return true; // Array.Find(slots, i => i.weaponObject == weaponObject) != null;
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


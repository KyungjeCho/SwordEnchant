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
        public WeaponObjectDB db;
        public List<WeaponList> canUpgradeWeaponLists = new List<WeaponList>();
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
                }
            }
            for (int i = 0; i < db.weaponObjects.Length; i++)
            {
                canUpgradeWeaponLists.Add(db.weaponObjects[i].weaponIndex);
            }
        }

        private void Update()
        {
            foreach (WeaponInventorySlot slot in slots)
            {
                if (slot.isEmpty == true)
                    continue;
            }
            
        }

        public bool AddWeapon(WeaponList weapon)
        {
            if (IsContain(weapon))
            {
                return false;
            }
            if (ProjectileManagersDB.Instance.GetPM(weapon) == null)
                return false;

            slots[GetFullSlotCount()].weaponIndex = weapon;
            slots[GetFullSlotCount()].pm = ProjectileManagersDB.Instance.GetPM(weapon);
            slots[GetFullSlotCount()].pm.gameObject.SetActive(true);
            slots[GetFullSlotCount()].isEmpty = false;

            return true;
        }

        public WeaponInventorySlot FindWeaponInInventory(WeaponList weapon)
        {
            return slots.FirstOrDefault(i => i.weaponIndex == weapon);
        }
        public void Clear()
        {
            foreach(WeaponInventorySlot slot in slots)
            {
                //slot.UpdateSlot(new WeaponObject(), false);
            }
        }

        public bool IsContain(WeaponList weapon)
        {
            return Array.Find(slots, i => i.weaponIndex == weapon) != null;
        }

        public int GetFullSlotCount()
        {
            return Array.FindAll(slots, i => i.isEmpty == false).Length;
        }

        public int GetEmptySlotCount()
        {
            return Array.FindAll(slots, i => i.isEmpty == true).Length;
        }

        //public bool CanAddOrUpgrade()
        //{
        //    if ()
        //}
    }
}


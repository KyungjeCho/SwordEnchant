using SwordEnchant.UI;
using SwordEnchant.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponUpgradeInventoryUI : InventoryUI
{
    public GameObject[] slots = null;

    public Dictionary<GameObject, WeaponObject> slotWeapon = new Dictionary<GameObject, WeaponObject>();
    public override void CreateSlots()
    {
        //slotUIs = new Dictionary<GameObject, SwordEnchant.WeaponSystem.WeaponInventorySlot>();

        //for (int i = 0; i < inventory.GetFullSlotCount(); i++)
        //{
        //    GameObject slotGO = slots[i];
        //    AddEvent(slotGO, EventTriggerType.PointerClick, (data) => { OnClick(slotGO, (PointerEventData)data); });

        //    if (inventory.slots[i].isEmpty)
        //        slotWeapon.Add(slotGO, null);
        //    else
        //    {
        //        slotWeapon.Add(slotGO, inventory.slots[i].weapon);
        //        SlotNodeController nc = slotGO.GetComponent<SlotNodeController>();
        //        nc.InitUI(inventory.slots[i].weapon.icon, false);
        //    }
        //}
    }

    private void OnEnable()
    {
        slotUIs = new Dictionary<GameObject, SwordEnchant.WeaponSystem.WeaponInventorySlot>();
        slotWeapon = new Dictionary<GameObject, WeaponObject>();
        for (int i = 0; i < inventory.GetFullSlotCount(); i++)
        {
            GameObject slotGO = slots[i];
            AddEvent(slotGO, EventTriggerType.PointerClick, (data) => { OnClick(slotGO, (PointerEventData)data); });

            if (inventory.slots[i].isEmpty)
                slotWeapon.Add(slotGO, null);
            else
            {
                slotWeapon.Add(slotGO, inventory.slots[i].weapon);
                SlotNodeController nc = slotGO.GetComponent<SlotNodeController>();
                nc.InitUI(inventory.slots[i].weapon.icon, false);
            }
        }
    }
    public void OnClick(GameObject go, PointerEventData data)
    {
        Debug.Log(slotWeapon[go].Clip.weaponName);

        WeaponUpgradeManager.Instance.SelectedWeaponObject = slotWeapon[go];
        WeaponUpgradeManager.Instance.UpdateUI();

        if (WeaponUpgradeManager.Instance.isOpenInfoPanel == false)
        {
            WeaponUpgradeManager.Instance.OpenInfoPanel();
        }
    }
}

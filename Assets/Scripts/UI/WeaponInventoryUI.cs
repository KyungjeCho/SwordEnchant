using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SwordEnchant.UI
{
    public class WeaponInventoryUI : InventoryUI
    {
        public GameObject[] staticSlots = null;

        public override void CreateSlots()
        {
            slotUIs = new Dictionary<GameObject, WeaponSystem.WeaponInventorySlot>();
            for (int ii = 0; ii < staticSlots.Length; ii++)
            {
                GameObject slotGO = staticSlots[ii];

                AddEvent(slotGO, EventTriggerType.PointerClick, (data) => { OnClick(slotGO, (PointerEventData)data); });

                inventoryObject.Slots[ii].slotUI = slotGO;
                slotUIs.Add(slotGO, inventoryObject.Slots[ii]);
            }
            
        }
    }

}

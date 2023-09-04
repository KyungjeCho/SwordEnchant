using SwordEnchant.Managers;
using SwordEnchant.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SwordEnchant.UI
{
    [RequireComponent(typeof(EventTrigger))]
    public abstract class InventoryUI : MonoBehaviour
    {
        #region Variables
        public InventoryObject inventoryObject;

        public WeaponInventory inventory;
        private WeaponInventory previousInventory;

        public Dictionary<GameObject, WeaponInventorySlot> slotUIs = new Dictionary<GameObject, WeaponInventorySlot>();
        #endregion Variables

        #region Unity Methods
        private void Awake()
        {
            CreateSlots();

            for (int ii = 0; ii < inventoryObject.Slots.Length; ii++)
            {
                inventoryObject.Slots[ii].parent = inventoryObject;
                inventoryObject.Slots[ii].OnPostUpdate += OnPostUpdate;
            }
        }

        protected virtual void Start()
        {
            for (int ii = 0; ii < inventoryObject.Slots.Length; ++ii)
            {
                inventoryObject.Slots[ii].UpdateSlot(inventoryObject.Slots[ii].weaponIndex, inventoryObject.Slots[ii].amount);
            }
        }
        #endregion Unity Methods

        #region Methods
        public abstract void CreateSlots();

        public void OnPostUpdate(WeaponInventorySlot slot)
        {
            slot.slotUI.transform.GetChild(0).GetComponent<Image>().sprite = slot.weaponIndex == WeaponList.None ? null : WeaponDataManager.Instance.GetWeaponObject(slot.weaponIndex).icon;
            slot.slotUI.transform.GetChild(0).GetComponent<Image>().color = slot.weaponIndex == WeaponList.None ? new Color(1f, 1f, 1f, 0f) : new Color(1f, 1f, 1f, 1f);
            //slot.slotUI.GetComponentInChildren<TextMeshProUGUI>().text = slot.weaponIndex == WeaponList.None ? string.Empty : slot.amount.ToString("n0");
        }

        protected void AddEvent(GameObject go, EventTriggerType type, UnityAction<BaseEventData> action)
        {
            EventTrigger trigger = go.GetComponent<EventTrigger>();
            if (!trigger)
            {
                Debug.LogWarning("No EventTrigger component found!");
                return;
            }

            EventTrigger.Entry eventTrigger = new EventTrigger.Entry { eventID = type };
            eventTrigger.callback.AddListener(action);
            trigger.triggers.Add(eventTrigger);
        }

        public virtual void OnClick(GameObject go, PointerEventData data)
        {

        }
        #endregion Methods
    }
}


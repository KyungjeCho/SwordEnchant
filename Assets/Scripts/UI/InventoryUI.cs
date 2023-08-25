using SwordEnchant.Managers;
using SwordEnchant.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
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

            //for (int i = 0; i < inventoryObject.Slots.Length; i++)
            //{
            //    inventoryObject.Slots[i].parent         = inventoryObject;
            //    inventoryObject.Slots[i].OnPostUpdate   += OnPostUpdate;
            //}
        }

        protected virtual void Start()
        {
            //for (int i = 0; i < inventoryObject.Slots.Length; i++)
            //{
            //    inventoryObject.Slots[i].UpdateSlot(inventoryObject.Slots[i].weaponIndex, inventoryObject.Slots[i].amount);
            //}
        }
        #endregion Unity Methods

        #region Methods
        public abstract void CreateSlots();

        public void OnPostUpdate(WeaponInventorySlot slot)
        {
            //slot.slotUI.transform.GetChild(0).GetComponent<Image>().sprite = slot.weaponIndex == WeaponList.None ? null : DataManager.WeaponData().weaponClips[slot.weaponIndex].
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

        public void OnEnterInterface(GameObject go)
        {
            
        }

        public void OnExitInterface(GameObject go)
        {

        }

        public void OnEnter(GameObject go)
        {

        }

        public void OnExit(GameObject go)
        {

        }
        #endregion Methods
    }
}


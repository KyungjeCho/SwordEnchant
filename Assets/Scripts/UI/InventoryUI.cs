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
        public WeaponInventory inventory;
        private WeaponInventory previousInventory;

        public Dictionary<GameObject, WeaponInventorySlot> slotUIs = new Dictionary<GameObject, WeaponInventorySlot>();
        #endregion Variables

        #region Unity Methods
        private void Awake()
        {
            
        }
        private void Start()
        {
            
        }
        #endregion Unity Methods

        #region Methods
        public abstract void CreateSlots();

        public void OnPostUpdate(WeaponInventorySlot slot)
        {
            if (slot == null || slot.slotUI == null)
            {
                return;
            }

            slot.slotUI.transform.GetChild(0).GetComponent<Image>().sprite = slot.weapon.weaponIndex == WeaponList.None ? null : slot.weapon.icon;
            slot.slotUI.transform.GetChild(0).GetComponent<Image>().color = slot.weapon.weaponIndex == WeaponList.None ? new Color(1, 1, 1, 0) : new Color(1, 1, 1, 1);
            
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


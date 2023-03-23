using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Data
{
    [Serializable]
    public class ModifiableInt
    {
        #region Variables
        [SerializeField]
        private int baseValue;

        [SerializeField]
        private int modifiedValue;

        public int BaseValue
        {
            get => baseValue;
            set
            {
                baseValue = value;
                UpdateModifiedValue();
            }
        }

        public int ModifiedValue
        {
            get => modifiedValue;
            set => modifiedValue = value;
        }

        private event Action<ModifiableInt> OnModifiedValue;

        private List<IModifier<int>> modifiers = new List<IModifier<int>>();
        #endregion Variables

        public ModifiableInt(Action<ModifiableInt> method = null)
        {
            ModifiedValue = baseValue;
            RegisterModEvent(method);
        }

        public void RegisterModEvent(Action<ModifiableInt> method)
        {
            if (method != null)
            {
                OnModifiedValue += method;
            }
        }

        public void UnregisterModEvent(Action<ModifiableInt> method)
        {
            if (method != null)
            {
                OnModifiedValue -= method;
            }
        }

        private void UpdateModifiedValue()
        {
            int valueToAdd = 0;
            foreach(IModifier<int> modifier in modifiers)
            {
                modifier.AddValue(ref valueToAdd);
            }

            ModifiedValue = baseValue + valueToAdd;

            OnModifiedValue?.Invoke(this);
        }

        public void AddModifier(IModifier<int> modifier)
        {
            modifiers.Add(modifier);
            UpdateModifiedValue();
        }

        public void RemoveModifier(IModifier<int> modifier)
        {
            modifiers.Remove(modifier);
            UpdateModifiedValue();
        }
    }
}


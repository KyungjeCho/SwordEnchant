using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Data
{
    [Serializable]
    public class ModifiableFloat
    {
        #region Variables
        [SerializeField]
        private float baseValue;

        [SerializeField]
        private float modifiedValue;

        public float BaseValue
        {
            get => baseValue;
            set
            {
                baseValue = value;
                UpdateModifiedValue();
            }
        }

        public float ModifiedValue
        {
            get => modifiedValue;
            set => modifiedValue = value;
        }

        private event Action<ModifiableFloat> OnModifiedValue;

        private List<IModifier<float>> modifiers = new List<IModifier<float>>();
        #endregion Variables

        public ModifiableFloat(Action<ModifiableFloat> method = null)
        {
            ModifiedValue = baseValue;
            RegisterModEvent(method);
        }

        public void RegisterModEvent(Action<ModifiableFloat> method)
        {
            if (method != null)
            {
                OnModifiedValue += method;
            }
        }

        public void UnregisterModEvent(Action<ModifiableFloat> method)
        {
            if (method != null)
            {
                OnModifiedValue -= method;
            }
        }

        private void UpdateModifiedValue()
        {
            float valueToAdd = 0;
            foreach(IModifier<float> modifier in modifiers)
            {
                modifier.AddValue(ref valueToAdd);
            }

            ModifiedValue = baseValue + valueToAdd;

            OnModifiedValue?.Invoke(this);
        }

        public void AddModifier(IModifier<float> modifier)
        {
            modifiers.Add(modifier);
            UpdateModifiedValue();
        }

        public void RemoveModifier(IModifier<float> modifier)
        {
            modifiers.Remove(modifier);
            UpdateModifiedValue();
        }

        public void ClearModifier()
        {
            modifiers.Clear();
            UpdateModifiedValue();
        }

        public void PrintModifier()
        {
            Debug.Log(modifiers.Count);

        }
    }
}


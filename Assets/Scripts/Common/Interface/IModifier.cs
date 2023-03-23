using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Data
{
    public interface IModifier<T>
    {
        void AddValue(ref T baseValue);
    }
}


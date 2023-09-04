using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.WeaponSystem
{
    [CreateAssetMenu(fileName = "New Weapon Database", menuName = "Data/WeaponObjectDatabase")]
    public class WeaponObjectDB : ScriptableObject
    {
        public WeaponObject[] weaponObjects;
        
    }
}


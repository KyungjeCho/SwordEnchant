using SwordEnchant.Data;
using SwordEnchant.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Managers
{
    public class WeaponDataManager : MonoSingleton<WeaponDataManager>
    {
        #region Varaibles
        public WeaponObject[] weaponObjectDB = new WeaponObject[18];
        #endregion Variables

        #region Methods

        public WeaponObject GetWeaponObject(WeaponList index)
        {
            foreach(WeaponObject weaponObject in weaponObjectDB)
            {
                if (weaponObject == null)
                    continue;

                if (weaponObject.weaponIndex == index)
                    return weaponObject;
            }
            return null;
        }
        #endregion Methods
    }

}

using SwordEnchant.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwordUpgrade : BaseWeaponUpgrade
{
    #region Constructor
    public SwordUpgrade()
    {
        maxGrade = 5;

        data = new WeaponUpgradeData[maxGrade];
                //                      Damage  Size Speed   cool   count      CP       CD
        data[0] = new WeaponUpgradeData(1f,     0f,     0f,     0f,     0f,     0f,     0f);
        data[1] = new WeaponUpgradeData(2f,   0.1f,     0f,  -0.5f,     0f,   0.1f,   0.1f);
        data[2] = new WeaponUpgradeData(3f,   0.2f,     0f,  -0.5f,     1f,   0.1f,   0.1f);
        data[3] = new WeaponUpgradeData(5f,   0.1f,     0f,  -0.5f,     1f,  0.15f,   0.1f);
        data[4] = new WeaponUpgradeData(7f,   0.0f,     0f,  -0.5f,     0f,   0.1f,   0.1f);
    }
    #endregion Constructor
}

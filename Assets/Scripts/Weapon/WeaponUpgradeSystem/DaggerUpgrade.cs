using SwordEnchant.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerUpgrade : BaseWeaponUpgrade
{
    #region Constructor
    public DaggerUpgrade()
    {
        maxGrade = 5;

        data = new WeaponUpgradeData[maxGrade];

        data[0] = new WeaponUpgradeData(1f, 1f, 1.1f, 1f, 0f, 0f, 1f);
        data[1] = new WeaponUpgradeData(2f, 1.1f, 1.1f, 0.95f, 0f, 0.1f, 1.1f);
        data[2] = new WeaponUpgradeData(3f, 1.3f, 1.1f, 0.9f, 1f, 0.2f, 1.1f);
        data[3] = new WeaponUpgradeData(5f, 1.4f, 1.1f, 0.85f, 1f, 0.25f, 1.3f);
        data[4] = new WeaponUpgradeData(7f, 1f, 1.1f, 0.8f, 0f, 0.3f, 1.3f);
    }
    #endregion Constructor
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgradeDB : MonoSingleton<WeaponUpgradeDB>
{
    #region Variables
    [HideInInspector]
    public Dictionary<WeaponList, BaseWeaponUpgrade> db = new Dictionary<WeaponList, BaseWeaponUpgrade>();
    public List<int> RequiredGold = new List<int>();
    #endregion Variables

    #region Unity Methods
    private void Awake()
    {
        db.Add(WeaponList.Sword, new SwordUpgrade());
        db.Add(WeaponList.Dagger, new DaggerUpgrade());
        db.Add(WeaponList.Bow, new BowUpgrade());
        db.Add(WeaponList.Boomerang, new BoomerangUpgrade());
        db.Add(WeaponList.Flurry, new StarUpgrade());
        
    }
    #endregion Unity Methods
}

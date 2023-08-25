using SwordEnchant.Projectile;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponObjectManager
{
    public WeaponList index;
    public BaseProjectileManager pm;
}

public class ProjectileManagersDB : MonoSingleton<ProjectileManagersDB>
{
    public List<WeaponObjectManager> db = new List<WeaponObjectManager>();
    
    public BaseProjectileManager GetPM(WeaponList index)
    {
        for (int i = 0; i < db.Count; i++)
        {
            if (db[i].index == index)
                return db[i].pm;
        }

        return null;
    }
}

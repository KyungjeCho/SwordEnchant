using SwordEnchant.Data;
using SwordEnchant.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Managers
{
    public class WeaponDataManager : MonoSingleton<WeaponDataManager>
    {
        public Dictionary<WeaponType, WeaponTypeObject> typeDB = new Dictionary<WeaponType, WeaponTypeObject>();

        private void Start()
        {
            typeDB.Add(WeaponType.MELEE,        Resources.Load<WeaponTypeObject>(PathName.WeaponTypeObjectPath + "/" + GameObjectName.Melee));
            typeDB.Add(WeaponType.LONGRANGE,    Resources.Load<WeaponTypeObject>(PathName.WeaponTypeObjectPath + "/" + GameObjectName.LongRange));
            typeDB.Add(WeaponType.MAGIC,        Resources.Load<WeaponTypeObject>(PathName.WeaponTypeObjectPath + "/" + GameObjectName.Magic));

        }
        
    }

}

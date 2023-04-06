using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordEnchant.Data;

namespace SwordEnchant.Managers
{
    public class DataManager : MonoBehaviour
    {
        private static MonsterData monsterData = null;
        private static WeaponData weaponData = null;

        // Start is called before the first frame update
        void Start()
        {
            if (monsterData == null)
            {
                monsterData = ScriptableObject.CreateInstance<MonsterData>();
                monsterData.LoadData();
            }
            if (weaponData == null)
            {
                weaponData = ScriptableObject.CreateInstance<WeaponData>();
                weaponData.LoadData();
            }
        }

        public static MonsterData MonsterData()
        {
            if (monsterData == null)
            {
                monsterData = ScriptableObject.CreateInstance<MonsterData>();
                monsterData.LoadData();
            }
            return monsterData;
        }

        public static WeaponData WeaponData()
        {
            if (weaponData == null)
            {
                weaponData = ScriptableObject.CreateInstance<WeaponData>();
                weaponData.LoadData();
            }
            return weaponData;
        }
    }
}



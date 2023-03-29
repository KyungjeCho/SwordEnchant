using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordEnchant.Data;

namespace SwordEnchant.Managers
{
    public class DataManager : MonoBehaviour
    {
        private static MonsterData monsterData = null;

        // Start is called before the first frame update
        void Start()
        {
            if (monsterData == null)
            {
                monsterData = ScriptableObject.CreateInstance<MonsterData>();
                monsterData.LoadData();
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
    }
}



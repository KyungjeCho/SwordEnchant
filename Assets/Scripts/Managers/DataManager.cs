using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordEnchant.Data;

namespace SwordEnchant.Managers
{
    public class DataManager : MonoBehaviour
    {
        private static SoundData soundData = null;
        private static EffectData effectData = null;
        private static MonsterData monsterData = null;
        private static WeaponData weaponData = null;
        private static CharacterData characterData = null;

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
            if (soundData == null)
            {
                soundData = ScriptableObject.CreateInstance<SoundData>();
                soundData.LoadData();
            }

            if (characterData == null)
            {
                characterData = ScriptableObject.CreateInstance<CharacterData>();
                characterData.LoadData();
            }
            if (effectData == null)
            {
                effectData = ScriptableObject.CreateInstance<EffectData>();
                effectData.LoadData();
            }
        }
        public static EffectData EffectData()
        {
            if (effectData == null)
            {
                effectData = ScriptableObject.CreateInstance<EffectData>();
                effectData.LoadData();
            }
            return effectData;
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

        public static SoundData SoundData()
        {
            if (soundData == null)
            {
                soundData = ScriptableObject.CreateInstance<SoundData>();
                soundData.LoadData();
            }
            return soundData;
        }

        public static CharacterData CharacterData()
        {
            if (characterData == null)
            {
                characterData = ScriptableObject.CreateInstance<CharacterData>();
                characterData.LoadData();
            }
            return characterData;
        }
    }
}



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
        public Dictionary<WeaponType, WeaponTypeObject> typeDB = new Dictionary<WeaponType, WeaponTypeObject>();

        public Dictionary<WeaponRarity, WeaponRarityObject> rarityDB = new Dictionary<WeaponRarity, WeaponRarityObject>();

        private Dictionary<WeaponRarity, float> histogramWeaponRarity = new Dictionary<WeaponRarity, float>();
        #endregion Variables

        #region Unity Methods
        private void Start()
        {
            typeDB.Add(WeaponType.MELEE,        Resources.Load<WeaponTypeObject>(PathName.WeaponTypeObjectPath + "/" + GameObjectName.Melee));
            typeDB.Add(WeaponType.LONGRANGE,    Resources.Load<WeaponTypeObject>(PathName.WeaponTypeObjectPath + "/" + GameObjectName.LongRange));
            typeDB.Add(WeaponType.MAGIC,        Resources.Load<WeaponTypeObject>(PathName.WeaponTypeObjectPath + "/" + GameObjectName.Magic));

            rarityDB.Add(WeaponRarity.Normal,       Resources.Load<WeaponRarityObject>(PathName.WeaponRarityObjectPath + "/" + GameObjectName.Normal));
            rarityDB.Add(WeaponRarity.Rare,         Resources.Load<WeaponRarityObject>(PathName.WeaponRarityObjectPath + "/" + GameObjectName.Rare));
            rarityDB.Add(WeaponRarity.Epic,         Resources.Load<WeaponRarityObject>(PathName.WeaponRarityObjectPath + "/" + GameObjectName.Epic));
            rarityDB.Add(WeaponRarity.Unique,       Resources.Load<WeaponRarityObject>(PathName.WeaponRarityObjectPath + "/" + GameObjectName.Unique));
            rarityDB.Add(WeaponRarity.Legendary,    Resources.Load<WeaponRarityObject>(PathName.WeaponRarityObjectPath + "/" + GameObjectName.Legendary));
            rarityDB.Add(WeaponRarity.Mythic,       Resources.Load<WeaponRarityObject>(PathName.WeaponRarityObjectPath + "/" + GameObjectName.Mythic));

            for (int ii = 0; ii < 6; ii++)
            {
                if (ii == 0)
                    histogramWeaponRarity.Add((WeaponRarity)ii, rarityDB[(WeaponRarity)ii].prob);
                else
                    histogramWeaponRarity.Add((WeaponRarity)ii, rarityDB[(WeaponRarity)ii].prob + histogramWeaponRarity[(WeaponRarity)ii - 1]);
            }

            
        }
        #endregion Unity Methods

        #region Helper Methods
        /// <summary>
        /// 무기 타입과 희귀도로 무기 리스트를 찾는 함수
        /// </summary>
        /// <param name="type"></param>
        /// <param name="rarity"></param>
        /// <returns></returns>
        public WeaponClip GetWeapon(WeaponType type, WeaponRarity rarity)
        {
            if (type == WeaponType.None)
                return null;

            foreach (WeaponClip clip in DataManager.WeaponData().weaponClips)
            {
                if (clip.rarity == rarity && clip.type == type)
                    return clip;
            }

            return null;
        }

        /// <summary>
        /// 무기를 확률에 따라 
        /// </summary>
        /// <returns></returns>
        public WeaponClip GetRandomWeapon()
        {
            WeaponRarity selectedRarity     = WeaponRarity.None;
            WeaponType selectedType         = WeaponType.None;


            int randAccuracy = 10000000;
            int rand = Random.Range(0, randAccuracy);
            // 무기 희귀도를 정한다.
            for (int ii = 0; ii < histogramWeaponRarity.Count; ii++)
            {
                if (rand < randAccuracy * histogramWeaponRarity[(WeaponRarity)ii])
                {
                    selectedRarity = (WeaponRarity)ii;
                    break;
                }
            }


            // 무기 종류를 정한다.
            rand = Random.Range(0, 3);
            selectedType = (WeaponType)rand;

            return GetWeapon(selectedType, selectedRarity);
        }
        #endregion Helper Methods
    }

}

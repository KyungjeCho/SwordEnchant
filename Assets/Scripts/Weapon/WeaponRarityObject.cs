using SwordEnchant.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SwordEnchant.WeaponSystem
{
    [CreateAssetMenu(fileName = "New Weapon Rarity", menuName = "Data/WeaponRarityObject")]
    public class WeaponRarityObject : ScriptableObject
    {
        #region Varaibles
        [Header("Description")]
        public WeaponRarity weaponRarity;

        public string rarityName = string.Empty;
        [Multiline(10)]
        public string description = string.Empty;

        [Header("UI")]
        public Color color;

        [Header("Probablity")]
        public float prob;

        [Header("Sell Price")]
        public bool canSell;
        public float price;
        #endregion Varaibles
    }
}


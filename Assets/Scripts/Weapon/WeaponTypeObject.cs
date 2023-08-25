using SwordEnchant.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.WeaponSystem
{
    [CreateAssetMenu(fileName = "New Weapon Type", menuName ="Data/WeaponTypeObject")]
    public class WeaponTypeObject : ScriptableObject
    {
        #region Variables
        [Header("Description")]
        public WeaponType weaponType;
        
        public string typeName = string.Empty;
        public string description = string.Empty;

        [Header("UI")]
        public Sprite icon = null; // 무기 타입의 UI 아이콘
        public Color color;

        [Header("Weapon Power")]
        public ModifiableFloat damage = new ModifiableFloat();
        
        private int grade = 0;

        public int Grade => grade;


        #endregion Variables

        public void OnValidate()
        {
            damage.BaseValue = 0f;

            grade = 0;
        }
    }
}



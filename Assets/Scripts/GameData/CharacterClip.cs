using SwordEnchant.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Data
{
    public class CharacterClip
    {
        #region Variables

        public int realID = 0;

        public string characterName             = string.Empty;
        public string characterPath             = string.Empty;
        public string characterFullPath         = string.Empty;

        public GameObject characterPrefab       = null;

        public float maxHp;
        public float defence;
        public float damage;
        public float size;
        public float speed;
        public float cooldown;
        public float count;
        public float luck;
        public float criticalProb;
        public float criticalDamage;

        public WeaponList defaultWeapon = WeaponList.None;

        public CharacterClip() { }

        #endregion Variables

        public void PreLoad()
        {
            characterFullPath = characterPath + characterName;
            if (characterFullPath != string.Empty && characterPrefab == null)
            {
                characterPrefab = ResourceManager.Load(characterFullPath) as GameObject;

                //if (PoolManager.Instance.isContain(projectilePrefab) == false)
                //    PoolManager.Instance.CreatePool(projectilePrefab);
            }
        }

        public void ReleaseMonster()
        {
            if (characterPrefab != null)
            {
                characterPrefab = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// 
        public GameObject Instantiate(Vector2 Pos)
        {
            if (characterPrefab == null)
            {
                PreLoad();
            }

            return null;
        }
    }

}

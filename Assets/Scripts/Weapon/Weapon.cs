using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Weapon
{
    public abstract class Weapon
    {
        #region Variables
        public int grade = 0;
        public WeaponList weaponData;
        public Sprite icon;

        private float weaponTimer;
        #endregion Variables

        public abstract void UpdateWeapon(float deltaTime);

        public virtual void GenerateProjectile()
        {

        }
    }

}

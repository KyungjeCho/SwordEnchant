using SwordEnchant.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Item
{
    public class ChestItem : BaseItem
    {
        public override void Use()
        {
            UIManager.Instance.OpenWeaponChestPanel();
        }
    }
}



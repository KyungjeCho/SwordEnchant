using SwordEnchant.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Item
{
    public class SoulItem : BaseItem
    {
        [Header("--- Soul Amount ---")]
        public int soulAmount;

        public override void Use()
        {
            GameManager.Instance.GetSoul(soulAmount);
        }
    }
}


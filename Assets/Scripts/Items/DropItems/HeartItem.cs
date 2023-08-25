using SwordEnchant.Characters;
using SwordEnchant.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Item
{
    public class HeartItem : BaseItem
    {
        [Header("--- Heal Amount ---")]
        [Range(0f, 1f)] public float healAmount;

        public override void Use()
        {
            PlayerHealth ph = GameManager.Instance.playerTr.GetComponent<PlayerHealth>();
            ph.health += ph.TotalHealth * healAmount;
            ph.UpdateHealthBar();

            if (ph.health > ph.TotalHealth * 0.3f)
            {
                UIManager.Instance.CloseBloodEffImg();
            }
        }
    }
}


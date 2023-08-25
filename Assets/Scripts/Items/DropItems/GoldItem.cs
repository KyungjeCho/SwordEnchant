using SwordEnchant.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Item
{
    public class GoldItem : BaseItem
    {
        #region Variables
        [Header("--- Gold Amount ---")]
        public int minGold;
        public int maxGold;
        public SoundList soundIndex;

        #endregion Variables

        // Update is called once per frame
        void Update()
        {

        }

        public override void Use()
        {
            int totalGold = Random.Range(minGold, maxGold);

            GameManager.Instance.GetGold(totalGold);

            SoundManager.Instance.PlayOneShotEffect((int)soundIndex, GameManager.Instance.playerTr.position, 1f);
        }
    }
}



using SwordEnchant.Item;
using SwordEnchant.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpItem : BaseItem
{
    #region Variables
    [Header("--- Exp Amount ---")]
    public int exp;
    public SoundList soundIndex;

    #endregion Variables

    public override void Use()
    {
        GameManager.Instance.GetExp(exp);

        SoundManager.Instance.PlayOneShotEffect((int)soundIndex, GameManager.Instance.playerTr.position, 1f);
    }
}

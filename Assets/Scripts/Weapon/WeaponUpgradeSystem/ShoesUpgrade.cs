using SwordEnchant.Managers;
using SwordEnchant.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoesUpgrade : BaseWeaponUpgrade
{
    public List<CharacterBuff> buffs = new List<CharacterBuff>();
    #region Constructor
    public ShoesUpgrade()
    {
        maxGrade = 5;

        data = new WeaponUpgradeData[maxGrade];

        data[0] = new WeaponUpgradeData(0f, 0f, 0f, 0f, 0f, 0f, 0f);
        data[1] = new WeaponUpgradeData(0f, 0f, 0f, 0f, 0f, 0f, 0f);
        data[2] = new WeaponUpgradeData(0f, 0f, 0f, 0f, 0f, 0f, 0f);
        data[3] = new WeaponUpgradeData(0f, 0f, 0f, 0f, 0f, 0f, 0f);
        data[4] = new WeaponUpgradeData(0f, 0f, 0f, 0f, 0f, 0f, 0f);

        buffs.Add(new CharacterBuff(0.1f));
        buffs.Add(new CharacterBuff(0.1f));
        buffs.Add(new CharacterBuff(0.1f));
        buffs.Add(new CharacterBuff(0.1f));
        buffs.Add(new CharacterBuff(0.1f));

    }
    #endregion Constructor

    public override void Upgrade(int grade, WeaponStats stats)
    {
        base.Upgrade(grade, stats);

        Transform playerTr = GameManager.Instance.playerTr;
        CharacterStat playerStat = playerTr.GetComponent<CharacterStat>();

        playerStat.characterObject.Stats.speed.AddModifier(buffs[grade - 1]);
    }

    public override void Downgrade(int grade, WeaponStats stats)
    {
        base.Downgrade(grade, stats);

        //Transform playerTr = GameManager.Instance.playerTr;
        //CharacterStat playerStat = playerTr.GetComponent<CharacterStat>();

        //playerStat.characterObject.Stats.speed.AddModifier(buffs[grade - 1]);
    }
}

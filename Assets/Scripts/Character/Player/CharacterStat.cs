using SwordEnchant.Data;
using SwordEnchant.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    #region Variables
    public CharacterObject characterObject;

    public bool isInitialized = false;
    #endregion Variables

    public void Initialize()
    {
        if (isInitialized)
            return;
        characterObject.Stats.maxHp.AddModifier(new CharacterBuff(20 * BasePlayerStat.GetGrade(PlayerStatAttribute.MaxHp)));
        characterObject.Stats.defence.AddModifier(new CharacterBuff(2 * BasePlayerStat.GetGrade(PlayerStatAttribute.Defence)));
        characterObject.Stats.damage.AddModifier(new CharacterBuff(2 * BasePlayerStat.GetGrade(PlayerStatAttribute.Damage)));
        characterObject.Stats.size.AddModifier(new CharacterBuff(0.05f * BasePlayerStat.GetGrade(PlayerStatAttribute.Size)));
        characterObject.Stats.speed.AddModifier(new CharacterBuff(0.4f * BasePlayerStat.GetGrade(PlayerStatAttribute.Speed)));
        characterObject.Stats.cooldown.AddModifier(new CharacterBuff(-0.05f * BasePlayerStat.GetGrade(PlayerStatAttribute.Cooldown)));
        characterObject.Stats.luck.AddModifier(new CharacterBuff(0.5f * BasePlayerStat.GetGrade(PlayerStatAttribute.Luck)));
        characterObject.Stats.criticalProb.AddModifier(new CharacterBuff(0.1f * BasePlayerStat.GetGrade(PlayerStatAttribute.CriticalProb)));
        characterObject.Stats.criticalDamage.AddModifier(new CharacterBuff(0.1f * BasePlayerStat.GetGrade(PlayerStatAttribute.CriticalDamage)));

        isInitialized = true;
    }
}

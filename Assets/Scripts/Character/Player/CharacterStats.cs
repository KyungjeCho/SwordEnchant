using SwordEnchant.Data;
using SwordEnchant.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterStats
{
    public ModifiableFloat maxHp;
    public ModifiableFloat defence;
    public ModifiableFloat damage;
    public ModifiableFloat size;
    public ModifiableFloat speed;
    public ModifiableFloat cooldown;
    public ModifiableFloat count;
    public ModifiableFloat luck;
    public ModifiableFloat criticalProb;
    public ModifiableFloat criticalDamage;

    public CharacterList characterIndex = CharacterList.None;

    public Action<CharacterStats> OnChangedStats;

    public CharacterStats(CharacterList characterIndex)
    {
        if (characterIndex == CharacterList.None)
        {
            Debug.LogWarning("잘못된 CharacterIndex 입니다. : " + characterIndex);
        }

        this.characterIndex = characterIndex;
        Initialize();
    }

    public void Initialize()
    {
        CharacterClip clip = DataManager.CharacterData().characterClips[(int)characterIndex];


        maxHp = new ModifiableFloat(OnModifiedValue);
        defence = new ModifiableFloat(OnModifiedValue);
        damage = new ModifiableFloat(OnModifiedValue);
        speed = new ModifiableFloat(OnModifiedValue);
        size = new ModifiableFloat(OnModifiedValue);
        cooldown = new ModifiableFloat(OnModifiedValue);
        count = new ModifiableFloat(OnModifiedValue);
        luck = new ModifiableFloat(OnModifiedValue);
        criticalDamage = new ModifiableFloat(OnModifiedValue);
        criticalProb = new ModifiableFloat(OnModifiedValue);

        maxHp.BaseValue = clip.maxHp;
        defence.BaseValue = clip.defence;
        damage.BaseValue = clip.damage;
        speed.BaseValue = clip.speed;
        size.BaseValue = clip.size;
        cooldown.BaseValue = clip.cooldown;
        count.BaseValue = clip.count;
        luck.BaseValue = clip.luck;
        criticalDamage.BaseValue = clip.criticalDamage;
        criticalProb.BaseValue = clip.criticalProb;
    }

    public void ClearModifier()
    {
        maxHp.ClearModifier();
        defence.ClearModifier();
        damage.ClearModifier();
        speed.ClearModifier();
        size.ClearModifier();
        cooldown.ClearModifier();
        count.ClearModifier();
        luck.ClearModifier();
        criticalDamage.ClearModifier();
        criticalProb.ClearModifier();
    }
    private void OnModifiedValue(ModifiableFloat value)
    {
        OnChangedStats?.Invoke(this);
    }
}

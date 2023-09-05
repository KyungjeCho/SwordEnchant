using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PlayerStatAttribute
{ 
    None = -1,
    MaxHp = 0,
    Defence = 1,
    Damage = 2,
    Size = 3,
    Speed = 4,
    Cooldown = 5,
    Luck = 6,
    CriticalProb = 7,
    CriticalDamage = 8,
}

[Serializable]
public class BasePlayerStat
{
    public string statName;
    public PlayerStatAttribute statAtt;
    public Sprite icon;
    public int grade;


    public static int GetGrade(PlayerStatAttribute attr)
    {
        switch (attr)
        {
            case PlayerStatAttribute.MaxHp:
                if (PlayerPrefs.HasKey(PlayerPrefsKey.MaxHp))
                    return PlayerPrefs.GetInt(PlayerPrefsKey.MaxHp);
                else
                    return 0;
            case PlayerStatAttribute.Defence:
                if (PlayerPrefs.HasKey(PlayerPrefsKey.Defence))
                    return PlayerPrefs.GetInt(PlayerPrefsKey.Defence);
                else
                    return 0;
            case PlayerStatAttribute.Damage:
                if (PlayerPrefs.HasKey(PlayerPrefsKey.Damage))
                    return PlayerPrefs.GetInt(PlayerPrefsKey.Damage);
                else
                    return 0;
            case PlayerStatAttribute.Size:
                if (PlayerPrefs.HasKey(PlayerPrefsKey.Size))
                    return PlayerPrefs.GetInt(PlayerPrefsKey.Size);
                else
                    return 0;
            case PlayerStatAttribute.Speed:
                if (PlayerPrefs.HasKey(PlayerPrefsKey.Speed))
                    return PlayerPrefs.GetInt(PlayerPrefsKey.Speed);
                else
                    return 0;
            case PlayerStatAttribute.Cooldown:
                if (PlayerPrefs.HasKey(PlayerPrefsKey.Cooldown))
                    return PlayerPrefs.GetInt(PlayerPrefsKey.Cooldown);
                else
                    return 0;
            case PlayerStatAttribute.Luck:
                if (PlayerPrefs.HasKey(PlayerPrefsKey.Luck))
                    return PlayerPrefs.GetInt(PlayerPrefsKey.Luck);
                else
                    return 0;
            case PlayerStatAttribute.CriticalProb:
                if (PlayerPrefs.HasKey(PlayerPrefsKey.CriticalProb))
                    return PlayerPrefs.GetInt(PlayerPrefsKey.CriticalProb);
                else
                    return 0;
            case PlayerStatAttribute.CriticalDamage:
                if (PlayerPrefs.HasKey(PlayerPrefsKey.CriticalDamage))
                    return PlayerPrefs.GetInt(PlayerPrefsKey.CriticalDamage);
                else
                    return 0;
        }

        return 0;
    }
    public void SaveData()
    {
        PlayerPrefs.SetInt(statName, grade);
    }
    public void LoadData()
    {
        grade = PlayerPrefs.GetInt(statName);
    }
}

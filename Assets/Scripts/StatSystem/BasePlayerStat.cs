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
                return PlayerPrefs.GetInt(PlayerPrefsKey.MaxHp);
            case PlayerStatAttribute.Defence:
                return PlayerPrefs.GetInt(PlayerPrefsKey.Defence);
            case PlayerStatAttribute.Damage:
                return PlayerPrefs.GetInt(PlayerPrefsKey.Damage);
            case PlayerStatAttribute.Size:
                return PlayerPrefs.GetInt(PlayerPrefsKey.Size);
            case PlayerStatAttribute.Speed:
                return PlayerPrefs.GetInt(PlayerPrefsKey.Speed);
            case PlayerStatAttribute.Cooldown:
                return PlayerPrefs.GetInt(PlayerPrefsKey.Cooldown);
            case PlayerStatAttribute.Luck:
                return PlayerPrefs.GetInt(PlayerPrefsKey.Luck);
            case PlayerStatAttribute.CriticalProb:
                return PlayerPrefs.GetInt(PlayerPrefsKey.CriticalProb);
            case PlayerStatAttribute.CriticalDamage:
                return PlayerPrefs.GetInt(PlayerPrefsKey.CriticalDamage);
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

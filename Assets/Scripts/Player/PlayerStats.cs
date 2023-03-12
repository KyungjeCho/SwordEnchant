using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public Character characterStats;
    public Projectile projectileStats;

    public float    Hp 
    { 
        get
        {
            return hp;
        }
        set 
        { 
            if (value > MaxHp) 
                hp = MaxHp; 
            else 
                hp = value;
        }
    }
    public float    Mp
    {
        get
        {
            return mp;
        }
        set 
        { 
            if (value > MaxMp) 
                hp = MaxMp; 
            else 
                hp = value;
        }
    }

    [Header("Charcter Stats")]
    [SerializeField]
    protected float hp;
    [SerializeField]
    protected float mp;
    public float    MaxHp;
    public float    MaxMp;
    public float    Speed;
    public float    PickUpArea;
    public float    PickUpAmount;
    public float    Luck;
    public float    CharacterSize;
    public float    HpRecoveryAmount;
    public float    HpRecoveryDuration;
    public float    MpRecovery;
    public float    DodgeRate;
    public float    CriticalRate;
    public float    Shield;

    [Header("Projectile Stats(Weapon Stats)")]
    public float    ProjectileSize;
    public float    ProjectileSpeed;
    public float    ProjectileCooldown;
    
    void ResetPlayerStats()
    {
        MaxHp               = characterStats.MaxHp;
        hp                  = MaxHp;
        MaxMp               = characterStats.MaxMana;
        mp                  = 0f;
        Speed               = characterStats.Speed;
        PickUpArea          = characterStats.PickUpArea;
        PickUpAmount        = characterStats.PickUpAmount;
        Luck                = characterStats.Luck;
        CharacterSize       = characterStats.CharacterSize;
        HpRecoveryAmount    = characterStats.HpRecoveryAmount;
        HpRecoveryDuration  = characterStats.HpRecoveryDuration;
        MpRecovery          = characterStats.ManaRecovery;
        DodgeRate           = characterStats.DodgeRate;
        CriticalRate        = characterStats.CriticalRate;
        Shield              = 0f;
    }

    void Start()
    {
        // 선택된 캐릭터 스텟 불러오기

        // 플레이어 스텟 초기화
        ResetPlayerStats();
    }
}

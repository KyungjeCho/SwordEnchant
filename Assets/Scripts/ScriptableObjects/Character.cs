using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Character", menuName ="Scriptable Object/Character", order = int.MaxValue)]
public class Character : ScriptableObject
{
    [Header("Character Description")]
    public int Id;
    public string Name;
    [TextArea(3, 5)]
    public string Description;

    [Header("Character Stats")]
    [Range(1f, 10f)]
    public float Speed;
    [Range(50f, 200f)]
    public float MaxHp;
    [Range(20f, 100f)]
    public float MaxMana;
    [Range(1f, 10f)]
    public float PickUpArea;
    [Range(1f, 3f)]
    public float PickUpAmount;
    [Range(1f, 2f)]
    public float Luck;
    [Range(0.1f, 3f)]
    public float CharacterSize;
    
    public float HpRecoveryAmount;
    public float HpRecoveryDuration;
    public float ManaRecovery;
    public float DodgeRate;
    public float CriticalRate;
}

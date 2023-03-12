using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Coin
{
    Bronze,
    Silver,
    Gold,
    Emerald,
    Sapphire,
    Ruby,
    Diamond
}

[CreateAssetMenu(fileName ="Monster Data", menuName ="Scriptable Object/Monster Data", order = int.MaxValue)]
public class Monster : ScriptableObject
{
    [Header ("Description")]
    public int ID;
    public string Name;
    [TextArea (3, 5)]
    public string Description;

    [Space (10f)]
    [Header ("Enemy Stats")]
    [Range(5f, 500f)]
    public float MaxHp;
    [Range (1f, 15f)]
    public float Damage;

    [Range (0f, 1f)]
    public float LifeSteal;
    public Coin DropCoin;

    [Range (0f, 10f)]
    public float Speed;
}

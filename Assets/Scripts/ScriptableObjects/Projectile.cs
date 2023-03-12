using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Projectile", menuName ="Scriptable Object/Projectile", order = int.MaxValue)]
public class Projectile : ScriptableObject
{
    public float ProjectileSpeed;
    public float ProjectileSize;
    public float ProjectileCooldown;
    public float ProjectileDamage;
    public float ProjectileCriticalDamage;
}

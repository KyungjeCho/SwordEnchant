using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Projectile
{
    public class ProjectileManagerDB : MonoSingleton<ProjectileManagerDB>
    {
        public List<BaseProjectileManager> db = new List<BaseProjectileManager>();

    }
}

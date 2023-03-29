using UnityEngine;

namespace SwordEnchant.Util
{
    public class Formula
    { 
        private static float DamageRandom(bool isCritical)
        {
            if (isCritical)
                return 1.0f;
            else
                return Random.Range(0.75f, 1.0f);
        }

        public static float TotalDamage(float damage, float defence, bool isCritical)
        {
            float criticalRate = 1.0f;
            if (isCritical)
                criticalRate = 2.0f;

            float totalDamage = ((damage * DamageRandom(isCritical)) - defence) * criticalRate;

            if (totalDamage <= 0)
                totalDamage = 0.0f;

            return totalDamage;
        }
    }
}
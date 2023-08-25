using UnityEngine;

namespace SwordEnchant.Util
{
    public class Formula
    { 
        private static float DamageRandom()
        {
            return Random.Range(0.75f, 1.0f);
        }

        public static float TotalDamage(float damage, float criticalDamage, float defence, bool isCritical)
        {
            float totalDamage = ((damage * DamageRandom()) - defence);

            if (isCritical)
                totalDamage *= criticalDamage;

            if (totalDamage <= 0)
                totalDamage = 0.0f;

            return totalDamage;
        }

        public static bool IsCritical(float criticalProb)
        {
            return Random.Range(0f, 1f) < criticalProb;
        }
    }
}
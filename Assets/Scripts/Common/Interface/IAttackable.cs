using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Core
{
    public interface IAttackable
    {
        // AttackBehaviour CurrentAttackBehaviour
        // {
        //     get;
        // }

        void OnExecuteAttack(int attackIndex);
    }
}

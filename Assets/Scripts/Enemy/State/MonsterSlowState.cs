using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSlowState : MonoBehaviour, IMonsterState
{
    private MonsterController _monsterController;

    public void Handle(MonsterController monsterController)
    {
        if (!_monsterController)
            _monsterController = monsterController;

        
    }
}


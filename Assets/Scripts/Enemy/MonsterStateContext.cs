using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateContext
{
    public IMonsterState CurrentState { get; set; }

    private readonly MonsterController _monsterController;

    public MonsterStateContext(MonsterController monsterController)
    {
        _monsterController = monsterController;
    }

    public void Transition()
    {
        CurrentState.Handle(_monsterController);
    }

    public void Transition(IMonsterState state)
    {
        CurrentState = state;
        CurrentState.Handle(_monsterController);
    }
}

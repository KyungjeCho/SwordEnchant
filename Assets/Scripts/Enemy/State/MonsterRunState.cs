using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRunState : MonoBehaviour, IMonsterState
{
    private MonsterController _monsterController;

    public void Handle(MonsterController monsterController)
    {
        
        if (!_monsterController)
            _monsterController = monsterController;

        GameObject target = _monsterController.TargetPlayer;

        // x flip
        if (target.transform.position.x - transform.position.x > 0)
            transform.localScale = new Vector3(-1f, 1f, 1f);
        else
            transform.localScale = new Vector3(1f, 1f, 1f);

        // move
        _monsterController._rigidbody2d.velocity = _monsterController.MonsterData.Speed * (target.transform.position - transform.position).normalized * Time.deltaTime  * 10f;
    }
}


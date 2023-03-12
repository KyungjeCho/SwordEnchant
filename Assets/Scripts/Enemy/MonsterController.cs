using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour, IDamagable
{
    public Monster MonsterData;

    public GameObject TargetPlayer;
    
    [HideInInspector]
    public Rigidbody2D _rigidbody2d;


    private IMonsterState _idleMonster, _runMonster, _damagedMonster, _slowMonster, _stunMonster, _dieMonster;
    private MonsterStateContext _monsterStateContext;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();

        _monsterStateContext = new MonsterStateContext(this);

        _idleMonster    = gameObject.AddComponent<MonsterIdleState>();
        _runMonster     = gameObject.AddComponent<MonsterRunState>();
        _damagedMonster = gameObject.AddComponent<MonsterDamagedState>();
        _slowMonster    = gameObject.AddComponent<MonsterSlowState>();
        _stunMonster    = gameObject.AddComponent<MonsterStunState>();
        _dieMonster     = gameObject.AddComponent<MonsterDieState>();
        
        FindTargetPlayer();
        _monsterStateContext.Transition(_runMonster);
    }

    void FixedUpdate() 
    {
        if (_monsterStateContext.CurrentState == _runMonster)
        {
            // 달리기
            RunMonster();
        }    
    }

    void FindTargetPlayer()
    {
        if (TargetPlayer)
            return;

        TargetPlayer = GameObject.Find("Player");
    }

    public void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        
        _monsterStateContext.Transition(_damagedMonster);
    }

    public void RunMonster()
    {
        if (!TargetPlayer)
            FindTargetPlayer();
        
        _monsterStateContext.Transition(_runMonster);
    }
}

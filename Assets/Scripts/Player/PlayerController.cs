using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Player Data 
    public Animator animator;
    public Rigidbody2D _rigidbody2D;
    public Vector2 CurrentDirection { get; private set; }

    private IPlayerState _moveState, _idleState, _attackState, _dieState;

    private PlayerStateContext _playerStateContext;
    
    void Start()
    {
        //animator            = this.GetComponent<Animator>();
        _rigidbody2D        = this.GetComponent<Rigidbody2D>();

        _playerStateContext = new PlayerStateContext(this);
        
        _moveState          = gameObject.AddComponent<PlayerMoveState>();
        _idleState          = gameObject.AddComponent<PlayerIdleState>();
        _attackState        = gameObject.AddComponent<PlayerAttackState>();
        _dieState           = gameObject.AddComponent<PlayerDieState>();

        _playerStateContext.Transition(_idleState);
    }

    void OnEnable() 
    {
        BattleEventBus.Subscribe(BattleEventType.START, StartPlayer);    

        BattleEventBus.Subscribe(BattleEventType.DIE, DiePlayer);
    }

    void OnDisable() 
    {
        BattleEventBus.Unsubscribe(BattleEventType.START, StartPlayer);    

        BattleEventBus.Unsubscribe(BattleEventType.DIE, DiePlayer);
    }

    public void MovePlayer(Vector2 direction)
    {
        CurrentDirection = direction;
        _playerStateContext.Transition(_moveState);
    }

    public void IdlePlayer()
    {
        _playerStateContext.Transition(_idleState);
    }

    public void AttackMonster()
    {
        _playerStateContext.Transition(_attackState);
    }

    public void DiePlayer()
    {
        _playerStateContext.Transition(_dieState);
    }

    public void StartPlayer()
    {

    }
}

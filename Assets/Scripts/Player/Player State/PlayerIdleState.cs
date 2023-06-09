using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : MonoBehaviour, IPlayerState
{
    private PlayerController _playerController;

    public void Handle(PlayerController playerController)
    {
        if (!_playerController)
            _playerController = playerController;

        _playerController.animator.SetBool("Is Running", false);

        _playerController._rigidbody2D.velocity = Vector2.zero;
    }

}

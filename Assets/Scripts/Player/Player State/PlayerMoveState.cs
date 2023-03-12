using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : MonoBehaviour, IPlayerState
{
    private PlayerController _playerController;


    public void Handle(PlayerController playerController)
    {
        if (!_playerController)
            _playerController = playerController;

        playerController.animator.SetBool("Is Running", true);

        // move
        playerController._rigidbody2D.velocity = playerController.CurrentDirection;
    }

}

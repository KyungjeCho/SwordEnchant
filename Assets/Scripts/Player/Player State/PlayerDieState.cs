using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDieState : MonoBehaviour, IPlayerState
{
    private PlayerController _playerController;

    public void Handle(PlayerController playerController)
    {
        if (!_playerController)
            _playerController = playerController;

        playerController.animator.SetTrigger("Dead");
    }

}

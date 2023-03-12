using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientState : MonoBehaviour
{
    private PlayerController _playerController;

    // Start is called before the first frame update
    void Start()
    {
        _playerController = (PlayerController) FindObjectOfType(typeof(PlayerController));
    }

    // Update is called once per frame
    void OnGUI()
    {
        if (GUILayout.Button("Idle Player"))
            _playerController.IdlePlayer();
        if (GUILayout.Button("Attack Player"))
            _playerController.AttackMonster();
        if (GUILayout.Button("Die Player"))
            _playerController.DiePlayer();
            
    }
}

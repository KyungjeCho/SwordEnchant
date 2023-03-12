using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientEventBus : MonoBehaviour
{
    private bool _isButtonEnabled;

    void Start()
    {
        gameObject.AddComponent<HUDController>();
        gameObject.AddComponent<CountdownTimer>();
        gameObject.AddComponent<PlayerController>();

        _isButtonEnabled = true;
    }

    void OnEnable()
    {
        BattleEventBus.Subscribe(BattleEventType.PAUSE, Restart);
    }

    void OnDisable()
    {
        BattleEventBus.Unsubscribe(BattleEventType.PAUSE, Restart);
    }

    private void Restart()
    {
        _isButtonEnabled = true;
    }

    void OnGUI()
    {
        if (_isButtonEnabled)
        {
            if (GUILayout.Button("Start Countdown"))
            {
                _isButtonEnabled = false;
                BattleEventBus.Publish(BattleEventType.COUNTDOWN);
            }
        }
    }
}

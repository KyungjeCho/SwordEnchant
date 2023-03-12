using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    private float _currentTime;
    private float duration = 3.0f;

    void OnEnable()
    {
        BattleEventBus.Subscribe(BattleEventType.COUNTDOWN, StartTimer);
    }

    void OnDisable()
    {
        BattleEventBus.Unsubscribe(BattleEventType.COUNTDOWN, StartTimer);
    }

    private void StartTimer()
    {
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        _currentTime = duration;

        while (_currentTime > 0)
        {
            yield return new WaitForSeconds(1f);
            _currentTime --;
        }

        BattleEventBus.Publish(BattleEventType.START);
    }

    void OnGUI()
    {
        GUI.color = Color.blue;
        GUI.Label(new Rect(125, 0, 100, 20), "COUNTDOWN: " + _currentTime);
    }
}

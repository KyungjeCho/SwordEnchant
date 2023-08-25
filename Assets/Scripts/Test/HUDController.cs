using SwordEnchant.EventBus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    private bool _isDisplayOn;

    void OnEnable() 
    {
        BattleEventBus.Subscribe(BattleEventType.START, DisplayHUD);    
    }

    void OnDisable() 
    {
        BattleEventBus.Unsubscribe(BattleEventType.START, DisplayHUD);    
    }

    private void DisplayHUD()
    {
        _isDisplayOn = true;
    }

    void OnGUI()
    {
        if (_isDisplayOn)
        {
            if (GUILayout.Button("Stop Race"))
            {
                _isDisplayOn = false; BattleEventBus.Publish(BattleEventType.PAUSE);
            }
        }
    }
}

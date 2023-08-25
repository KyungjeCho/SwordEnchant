using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SwordEnchant.EventBus
{
    public class BattleEventBus
    {
        private static readonly IDictionary<BattleEventType, UnityEvent>
        Events = new Dictionary<BattleEventType, UnityEvent>();

        public static void Subscribe(BattleEventType eventType, UnityAction listener)
        {
            UnityEvent thisEvent;

            if (Events.TryGetValue(eventType, out thisEvent))
            {
                thisEvent.AddListener(listener);
            }
            else
            {
                thisEvent = new UnityEvent();
                thisEvent.AddListener(listener);
                Events.Add(eventType, thisEvent);
            }
        }

        public static void Unsubscribe(BattleEventType type, UnityAction listener)
        {
            UnityEvent thisEvent;

            if (Events.TryGetValue(type, out thisEvent))
            {
                thisEvent.RemoveListener(listener);
            }
        }

        public static void Publish(BattleEventType type)
        {
            UnityEvent thisEvent;

            if (Events.TryGetValue(type, out thisEvent))
            {
                thisEvent.Invoke();
            }
        }
    }
}


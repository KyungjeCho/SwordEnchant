using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SwordEnchant.EventBus
{
    public class SpawnEventBus
    {
        private static readonly IDictionary<int, UnityEvent>
        Events = new Dictionary<int, UnityEvent>();

        public static void Subscribe(int time, UnityAction listener)
        {
            UnityEvent thisEvent;

            if (Events.TryGetValue(time, out thisEvent))
            {
                thisEvent.AddListener(listener);
            }
            else
            {
                thisEvent = new UnityEvent();
                thisEvent.AddListener(listener);
                Events.Add(time, thisEvent);
            }
        }

        public static void Unsubscribe(int time, UnityAction listener)
        {
            UnityEvent thisEvent;

            if (Events.TryGetValue(time, out thisEvent))
            {
                thisEvent.RemoveListener(listener);
            }
        }

        public static void Publish(int time)
        {
            UnityEvent thisEvent;

            if (Events.TryGetValue(time, out thisEvent))
            {
                thisEvent.Invoke();

                thisEvent.RemoveAllListeners();
            }
        }
    }
}


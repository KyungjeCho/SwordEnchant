using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static bool ShuttingDown = false;
    private static object Lock = new object();
    private static T instance;

    public static T Instance
    {
        get
        {
            if (ShuttingDown)
            {
                Debug.LogWarning("[MonoSingleton] Instance '" + typeof(T) +
                    "' already destoryed. Returning null");
                return null;
            }

            lock (Lock)
            {
                if (instance == null)
                {
                    instance = (T)FindObjectOfType(typeof(T));

                    if (instance == null)
                    {
                        var singletonObject = new GameObject();
                        instance = singletonObject.AddComponent<T>();
                        singletonObject.name = typeof(T).ToString() + " (MonoSingleton)";

                        DontDestroyOnLoad(singletonObject);
                    }
                }

                return instance;
            }
        }
    }

    private void OnDisable()
    {
        //ShuttingDown = true;
        instance = null;
    }
    private void OnApplicationQuit()
    {
        //ShuttingDown = true;
    }

    private void OnDestroy()
    {
        //ShuttingDown = true;
        instance = null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public int healthUp = 30;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<ActiveItemMove>().RootItemEvent.AddListener(TriggerEffect);
    }

    void TriggerEffect()
    {
        // Todo 
        GameObject.Find("PlayerBody").GetComponent<PlayerStats>().Hp += (float)healthUp;
    }
}

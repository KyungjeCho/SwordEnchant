using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerHealth : MonoBehaviour
{
    public UnityEvent onPlayerDead;

    private PlayerStats playerStat;

    // Start is called before the first frame update
    void Start()
    {
        playerStat = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStat.Hp <= 0)
            Dead();
    }

    private void Dead()
    {
        onPlayerDead.Invoke();
    }
}

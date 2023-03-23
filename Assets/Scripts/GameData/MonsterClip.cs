using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterClip
{
    public int realID = 0;

    public string monsterName = string.Empty;
    public string monsterPath = string.Empty;
    public string monsterFullPath = string.Empty;

    public int health;
    public float speed;
    public int damage;
    public int defence;
    public float size;

    public MonsterClip() { }

    public void PreLoad()
    {
        // 나중에 프리펩과 연동하기 위해
    }
}

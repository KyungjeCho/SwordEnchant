using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public GameObject   TestSample;
    public GameObject   Slime;
    public GameObject   KingSlime;
    public GameObject   Squirrel;
    public GameObject   Goblin;
    public GameObject   GoldenGoblin;
    public GameObject   Skeleton;
    public GameObject   SkeletonKnight;
    public GameObject   Skelking;
    public GameObject   Bat;
    public GameObject   BloodBat;
    public GameObject   Orc;
    public GameObject   Drake;
    
    public GameObject   Player;
    public Timer        Timer;

    private GameObject  SpawnMonster;
    private int     SpawnAmount;
    private float   SpawnDuration;
    private bool    IsSpawn;
    private bool    IsPlayerDead;

    // Start is called before the first frame update
    void Start()
    {
        SpawnMonster    = Squirrel;
        SpawnAmount     = 1;
        SpawnDuration   = 5f;
        IsSpawn         = false;
        IsPlayerDead    = false;

        //StartCoroutine(StartCooldown());
    }

    // Update is called once per frame
    void Update()
    {
        // spawn 
        if (IsSpawn)
        {
            // todo
            for(int i = 0; i < SpawnAmount; i++)
                GenerateMonster();

            //StartCoroutine(StartCooldown());
        }

        // wave 1
        if (Timer.minutes < 1)
        {
            
        }

        // wave 2
        else if(Timer.minutes < 3)
        {
            SpawnMonster = Slime;
            SpawnAmount = 3;
        }
        // wave 3
        else if(Timer.minutes < 5)
        {
            SpawnMonster = Goblin;
            SpawnAmount = 5;
        }
        // wave 4
        else if(Timer.minutes < 8)
        {
            SpawnMonster = Skeleton;
        }
        // wave 5
        else if (Timer.minutes < 11)
        {
            SpawnMonster = SkeletonKnight;
            SpawnAmount = 10;
        }
        // wave 6
        else if (Timer.minutes < 14)
        {
            SpawnMonster = Orc;
        }
        // wave 7
        else if (Timer.minutes < 17)
        {
            SpawnMonster = BloodBat;
        }
        // wave 8
        else if (Timer.minutes < 20)
        {
            SpawnMonster = Goblin;
        }
        // wave 9   
        else if (Timer.minutes < 23)
        {
            SpawnMonster = Bat;
        }
        // wave 10
        else if (Timer.minutes < 25)
        {
            SpawnMonster = SkeletonKnight;
        }
        // wave 11
        else if (Timer.minutes < 27)
        {
            SpawnMonster = KingSlime;
        }
        // wave 12
        else if (Timer.minutes < 30)
        {
            
        }
    }

    public void GenerateMonster()
    {
        float x = 0;
        float y = 0;

        while(Mathf.Abs(x) < 8 && Mathf.Abs(y) < 8)
        {
            x = Random.Range(-15, 15);
            y = Random.Range(-15, 15);
        }
        Vector3 position = new Vector3(Player.transform.position.x + x, Player.transform.position.y + y, 0);
        Instantiate(SpawnMonster, position, Quaternion.identity);
    }

    void BigWaveGenerate(int n)
    {
        for(int i = 0; i < n; i++)
            GenerateMonster();
    }

    IEnumerator StartCooldown()
    {
        IsSpawn = false;
        yield return new WaitForSeconds(SpawnDuration);
        IsSpawn = true;
    }

    public void PlayerDead()
    {

    }
}

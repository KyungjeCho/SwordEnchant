using SwordEnchant.Characters;
using SwordEnchant.EventBus;
using SwordEnchant.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SwordEnchant.Managers
{
    [Serializable]
    public class TimeDuration
    {
        public float time;
        public float duration;
    }

    public class MonsterManager : MonoBehaviour
    {
        private Transform monsterRoot = null;
        private float timer = 0.0f;
        public float duration;
        public int spawnCount = 1;


        private float directionTimer = 0.0f;
        public float directionDur = 5f;

        public List<TimeDuration> timeToDur = new List<TimeDuration>();
        public List<int> timeList;

        private Transform playerTr;

        public GameObject testObject;
        public GameObject testObject_Rushing;
        public GameObject spawnObject;

        public List<GameObject> monsterPrefabs = new List<GameObject>();

        public List<GameObject> bossMonsterPrefabs = new List<GameObject>();

        public List<GameObject> directionMonsterPrefabs = new List<GameObject>();

        // Start is called before the first frame update

        private void OnEnable()
        {
            timeList = new List<int>();

            timeList.Add(0);
            timeList.Add(1);
            timeList.Add(5);
            timeList.Add(7);
            timeList.Add(9);
            timeList.Add(10);
            timeList.Add(15);
            timeList.Add(16);
            timeList.Add(18);
            timeList.Add(20);

            SpawnEventBus.Subscribe(timeList[0], Time0min);
            SpawnEventBus.Subscribe(timeList[1], Time1min);
        }

        private void OnDisable()
        {
            SpawnEventBus.Unsubscribe(timeList[0], Time0min);
            SpawnEventBus.Unsubscribe(timeList[1], Time1min);
        }
        void Start()
        {
            if (monsterRoot == null)
            {
                monsterRoot = new GameObject("MonsterRoot").transform;
                monsterRoot.SetParent(transform);
            }

            if (testObject == null)
                testObject = Resources.Load("Prefabs/Monsters/TestEnemy_Tracking") as GameObject;

            if (testObject_Rushing == null)
                testObject_Rushing = Resources.Load("Prefabs/Monsters/TestEnemy_Directional") as GameObject;

            foreach(GameObject go in monsterPrefabs)
            {
                PoolManager.Instance.CreatePool(go, 50);
            }

            playerTr = GameObject.Find("Player").transform;

            duration = timeToDur[0].duration;
            //duration = 0.5f;
            spawnObject = monsterPrefabs[0];
        }

        private void Update()
        {

            for (int i = 0; i < timeList.Count; i++)
            {
                if (GameManager.Instance.ElapsedTime > timeList[i] * 60)
                {
                    SpawnEventBus.Publish(timeList[i]);
                }
            }
            timer += Time.deltaTime;
            if (timer >= duration)
            {
                for (int i = 0; i < spawnCount; i++)
                    MonsterSpawn();

                timer = 0f;
            }

            directionTimer += Time.deltaTime;
            if (directionTimer >= directionDur)
            {
                OneDirectionMonsterSpawn();
                directionTimer = 0f;
            }
        }

        public void MonsterSpawn()
        {
            int index = Random.Range(0, monsterPrefabs.Count);
            Poolable po = PoolManager.Instance.Pop(monsterPrefabs[index]);

            po.gameObject.GetComponent<EnemyController>().ResetHealth();
            
            float degree = Random.Range(0f, 360f);

            float r = 10f;

            po.transform.position = MathHelper.DegreeToVector3(degree, r) + playerTr.position;
        }

        public void OneDirectionMonsterSpawn()
        {
            float degree = Random.Range(0f, 360f);

            float r = 10f;

            Vector2 startPos = MathHelper.DegreeToVector3(degree, r) + playerTr.position;

            int index = Random.Range(0, directionMonsterPrefabs.Count);

            for(int i = 0; i < 5; i++)
            {
                Poolable po = PoolManager.Instance.Pop(directionMonsterPrefabs[index]);
                po.transform.position = startPos + Random.insideUnitCircle;
            }
            
        }
        #region Time Events
        public void Time0min()
        {
            duration = 2f;

            spawnObject = monsterPrefabs[0];
            spawnCount = 1;
        }
        public void Time1min()
        {
            duration = 1.5f;
            spawnObject = monsterPrefabs[1];
        }

        public void Time5min()
        {
            duration = 1f;

            spawnObject = monsterPrefabs[1];
            spawnCount = 2;
        }

        public void Time7min()
        {
            duration = 0.5f;

        }

        public void Time9min()
        {
            spawnCount = 3;
        }

        public void Time10min()
        {

        }

        public void Time15min()
        {

        }

        public void Time16min()
        {

        }

        public void Time18min()
        {

        }

        public void Time20min()
        {

        }
        #endregion Time Events
    }
}


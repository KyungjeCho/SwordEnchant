using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Managers
{
    public class MonsterManager : MonoBehaviour
    {
        private Transform monsterRoot = null;

        // Start is called before the first frame update
        void Start()
        {
            if (monsterRoot == null)
            {
                monsterRoot = new GameObject("MonsterRoot").transform;
                monsterRoot.SetParent(transform);
            }
        }

        //public GameObject MonsterSpawn(int index, Vector3 position)
        //{
        //    MonsterClip clip = 
        //}
    }
}


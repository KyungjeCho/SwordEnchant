using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Managers
{
    public class WeaponDataManager : MonoBehaviour
    {
        public Transform weaponRoot = null;

        void Start()
        {
            if (weaponRoot == null)
            {
                weaponRoot = new GameObject("WeaponRoot").transform;
                weaponRoot.SetParent(transform);
            }
        } 

        public GameObject GetGameObjectAtPool(int index, Vector3 position)
        {

            return null;
        }

    }

}

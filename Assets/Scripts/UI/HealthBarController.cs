using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SwordEnchant.UI
{
    public class HealthBarController : MonoBehaviour
    {
        public float height = 1.0f;

        public Image frontImg;

        private Transform playerTr;


        // Start is called before the first frame update
        void Start()
        {
            playerTr = GameObject.Find(GameObjectName.Player).transform;

        }

        // Update is called once per frame
        void Update()
        {
            if (playerTr == null)
                return;

            transform.position = playerTr.position + Vector3.up * height;
        }
    }
}


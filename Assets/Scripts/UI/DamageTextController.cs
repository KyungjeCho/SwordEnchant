using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SwordEnchant.UI
{
    public class DamageTextController : MonoBehaviour
    {

        // Start is called before the first frame update
        void Start()
        {
            Destroy(gameObject, 2f);
        }

        // Update is called once per frame
        void Update()
        {
            transform.position += Vector3.up * Time.deltaTime;
        }
    }
}


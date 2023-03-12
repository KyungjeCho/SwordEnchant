using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnchantingNumber : MonoBehaviour
{
    public Text EnchantingNumberText;

    public Sword sword;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowInfo();
    }

    void ShowInfo()
    {
        EnchantingNumberText.text = sword.enhancementNumber + "강";
    }
}

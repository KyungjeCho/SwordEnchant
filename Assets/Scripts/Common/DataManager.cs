using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DataManager : MonoSingleton<DataManager>
{
    [SerializeField]
    public static int Gold;

    public TextMeshProUGUI GoldText;

    void Start()
    {
        
    }

    void Update()
    {
        ShowInfo();
    }

    
    void ShowInfo()
    {
        if (GoldText != null)
            GoldText.text = Gold.ToString();
    }
}

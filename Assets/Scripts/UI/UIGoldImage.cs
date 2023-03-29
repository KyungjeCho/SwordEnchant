using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIGoldImage : MonoBehaviour
{
    public RectTransform    goldImageRectTrans;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeWidth();   
    }

    void ChangeWidth()
    {
        //int goldDigits = DataManager.Gold.ToString().Length;

        //goldImageRectTrans.sizeDelta 
        //    = new Vector2(300 + 60 * (goldDigits - 1), 170);
    }
}

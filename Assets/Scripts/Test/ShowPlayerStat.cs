using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowPlayerStat : MonoBehaviour
{
    public Text PlayerStatText;
    public PlayerStats PlayerStat;

    private string AllStatStr;

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
        AllStatStr = "";
        AllStatStr =    "SPEED : \t"   + PlayerStat.Speed  + "\n";
        AllStatStr +=   "HP :\t"       + PlayerStat.Hp     + "\n";
        AllStatStr +=   "MAXHP :\t"    + PlayerStat.MaxHp  + "\n";
        //AllStatStr +=   "HP :\t"       + PlayerStat.Hp     + "\n";
        //AllStatStr +=   "HP :\t"       + PlayerStat.Hp     + "\n";
        //AllStatStr +=   "HP :\t"       + PlayerStat.Hp     + "\n";
        //AllStatStr +=   "HP :\t"       + PlayerStat.Hp     + "\n";

        PlayerStatText.text = AllStatStr;
    }
}

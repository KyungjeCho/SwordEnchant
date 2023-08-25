using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharEnhanceSlotNodeController : MonoBehaviour
{
    
    #region Variables
    public Image icon;

    public List<StarSlotController> starSlots = new List<StarSlotController>();

    public Text contextTxt;

    public BasePlayerStat stat;
    #endregion Variables
    

    public void UpdateStat()
    {
        if (stat == null)
            return;

        icon.sprite = stat.icon;
        contextTxt.text = stat.statName;
        UpdateStar();

    }

    public void UpdateStar()
    {
        for (int i = 0; i < 5; i++)
        {
            if (i < stat.grade)
                starSlots[i].SetStarEnable();
            else
                starSlots[i].SetStarDisable();
        }
    }
}

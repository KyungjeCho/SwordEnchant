using SwordEnchant.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoSingleton<LobbyManager>
{
    #region Variables
    public int soul = 0;
    #endregion Variables

    private void Start()
    {
        LoadData();
        UIManager.Instance.UpdateSoulTxt();

        SoundManager.Instance.PlayBGM((int)SoundList.TheFinalBattle);
    }

    #region Helper Methods
    public void SaveData()
    {
        PlayerPrefs.SetInt(SaveDataKey.Soul, soul);
    }

    public void LoadData()
    {
        soul = PlayerPrefs.GetInt(SaveDataKey.Soul);
    }
    #endregion Helper Methods
}

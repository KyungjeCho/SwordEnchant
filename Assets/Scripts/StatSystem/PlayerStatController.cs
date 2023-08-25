using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using SwordEnchant.Managers;

public class PlayerStatController : MonoBehaviour
{
    public Text titleTxt;
    public Image iconImage;
    public Text requiredTxt;

    public List<BasePlayerStat> stats = new List<BasePlayerStat>();
    public List<CharEnhanceSlotNodeController> slots = new List<CharEnhanceSlotNodeController>();

    public BasePlayerStat SelectedStat = null;

    public Button UpgradeBtn = null;
    public Button ResetGradeBtn;

    public List<int> RequiredSoul = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        if (UpgradeBtn == null)
            return;

        UpgradeBtn.onClick.AddListener(UpgradeStat);

        if (ResetGradeBtn == null)
            return;

        ResetGradeBtn.onClick.AddListener(ResetGrade);

        for (int i = 0; i < stats.Count; i++)
        {
            slots[i].UpdateStat();
        }

        UpdateInfo();
    }

    private void OnEnable()
    {
        LoadData();

        for (int i = 0; i < stats.Count; i++)
        {
            slots[i].stat = stats[i];
            slots[i].UpdateStat();
        }

        for (int i = 0; i < slots.Count; i++)
        {
            GameObject slotGO = slots[i].gameObject;
            AddEvent(slotGO, EventTriggerType.PointerClick, (data) => { OnClick(slotGO, (PointerEventData)data); });
        }

        SelectedStat = stats[0];
    }

    private void OnDisable()
    {
        foreach (BasePlayerStat stat in stats)
            stat.SaveData();
    }

    public BasePlayerStat GetStat(PlayerStatAttribute index)
    {
        if (index == PlayerStatAttribute.None)
            return null;

        foreach(BasePlayerStat stat in stats)
        {
            if (stat.statAtt == index)
                return stat;
        }

        return null;
    }

    public void SaveData()
    {
        foreach (BasePlayerStat stat in stats)
            stat.SaveData();
    }

    public void LoadData()
    {
        foreach (BasePlayerStat stat in stats)
            stat.LoadData();
    }

    public void ResetGrade()
    {
        foreach(BasePlayerStat stat in stats)
        {
            stat.grade = 0;
            stat.SaveData();
        }

        for (int i = 0; i < stats.Count; i++)
        {
            slots[i].UpdateStat();
        }
    }
    protected void AddEvent(GameObject go, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = go.GetComponent<EventTrigger>();
        if (!trigger)
        {
            Debug.LogWarning("No EventTrigger component found!");
            return;
        }

        EventTrigger.Entry eventTrigger = new EventTrigger.Entry { eventID = type };
        eventTrigger.callback.AddListener(action);
        trigger.triggers.Add(eventTrigger);
    }
    public void OnClick(GameObject go, PointerEventData data)
    {
        SelectedStat = go.GetComponent<CharEnhanceSlotNodeController>().stat;

        UpdateInfo();
    }

    public void UpgradeStat()
    {
        if (SelectedStat == null )
            return;

        if (SelectedStat.grade >= 5)
            return;

        if (RequiredSoul[SelectedStat.grade] > LobbyManager.Instance.soul)
            return;

        LobbyManager.Instance.soul -= RequiredSoul[SelectedStat.grade];
        SelectedStat.grade += 1;

        UIManager.Instance.UpdateSoulTxt();

        for (int i = 0; i < stats.Count; i++)
        {
            slots[i].UpdateStat();
        }

        SaveData();
        LobbyManager.Instance.SaveData();
    }

    public void UpdateInfo()
    {
        titleTxt.text = SelectedStat.statName;
        iconImage.sprite = SelectedStat.icon;
        if (SelectedStat.grade < 5)
            requiredTxt.text = $"{LobbyManager.Instance.soul} / {RequiredSoul[SelectedStat.grade]}";
        else
            requiredTxt.text = "MAX";
    }
}

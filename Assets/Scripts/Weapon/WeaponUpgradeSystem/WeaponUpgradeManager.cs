using SwordEnchant.Managers;
using SwordEnchant.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUpgradeManager : MonoSingleton<WeaponUpgradeManager>
{
    #region Variables
    [HideInInspector]
    public WeaponObject SelectedWeaponObject = null;
    public WeaponUpgradeDB db;
    public WeaponEnhanceProb prob;

    public SlotListUI WeaponListPanelObj;
    public OpenClosePanelUI ContextTxtObj;
    public OpenClosePanelUI InfoPanelObj;
    public OpenClosePanelUI UpgradeBtnObj;

    public Text TitleText;
    public Text SuccessTxt;
    public Text FailureTxt;
    public Text DestroyTxt;
    public Text RequiredGoldTxt;

    public bool isOpenInfoPanel = false;

    private Image panelBackgroundImg;
    #endregion Variables


    #region Unity Methods
    private void Start()
    {
        panelBackgroundImg = GetComponent<Image>();
    }
    private void OnEnable()
    {
        SelectedWeaponObject = null;
        UpdateUI();

        WeaponListPanelObj.MoveIndexPos(0);
        ContextTxtObj.OpenPanel();
        if (panelBackgroundImg == null)
            panelBackgroundImg = GetComponent<Image>();
        panelBackgroundImg.color = new Color(1f, 1f, 1f, 100f/ 255f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion Unity Methods

    #region Methods

    public void ClickUpgradeBtn()
    {
        if (SelectedWeaponObject.Grade >= db.db[(WeaponList)SelectedWeaponObject.weaponIndex].maxGrade)
            return;

        if (db.RequiredGold[SelectedWeaponObject.Grade] > GameManager.Instance.Gold)
            return;

        GameManager.Instance.GetGold(-db.RequiredGold[SelectedWeaponObject.Grade]);

        float r = Random.Range(0f, 1f);

        if (r < prob.probs[SelectedWeaponObject.Grade].successProb)
        {
            SelectedWeaponObject.Grade += 1;
            WeaponUpgrade();
        }
        else if (r < prob.probs[SelectedWeaponObject.Grade].failureProb)
        {

        }
        else
        {

        }
        

        Debug.Log(SelectedWeaponObject.Grade);
        UpdateUI();
    }

    public void WeaponUpgrade()
    {
        if (SelectedWeaponObject == null)
            return;

        db.db[(WeaponList)SelectedWeaponObject.weaponIndex].Upgrade(SelectedWeaponObject.Grade, SelectedWeaponObject.Stats);
    }

    public void UpdateUI()
    {
        if (SelectedWeaponObject == null)
        {
            //SelectedWeaponImg.color = new Color(1f, 1f, 1f, 0f);
            TitleText.text = "-강 -> -강";
            SuccessTxt.text = "성공 : ";
            FailureTxt.text = "실패 : ";
            DestroyTxt.text = "파괴 : ";
            RequiredGoldTxt.text = "0 / 0";
        }
        else
        {
            //SelectedWeaponImg.color = new Color(1f, 1f, 1f, 1f);
            //SelectedWeaponImg.sprite = SelectedWeaponObject.icon;

            TitleText.text = $"{SelectedWeaponObject.Grade}강 -> {SelectedWeaponObject.Grade + 1}강";
            SuccessTxt.text = $"성공 : {prob.probs[SelectedWeaponObject.Grade].successProb * 100}%";
            FailureTxt.text = $"실패 : {prob.probs[SelectedWeaponObject.Grade].failureProb * 100}%";
            DestroyTxt.text = $"파괴 : {prob.probs[SelectedWeaponObject.Grade].destroyProb * 100}%";

            if (SelectedWeaponObject.Grade == db.db[SelectedWeaponObject.weaponIndex].maxGrade)
                RequiredGoldTxt.text = $"0 / 0";
            else
                RequiredGoldTxt.text = $"{GameManager.Instance.Gold} / {db.RequiredGold[SelectedWeaponObject.Grade]}";
        }
    }

    public void OpenInfoPanel()
    {
        if (isOpenInfoPanel)
            return;

        WeaponListPanelObj.MoveIndexPos(1);
        ContextTxtObj.ClosePanel();
        InfoPanelObj.OpenPanel();
        UpgradeBtnObj.OpenPanel();

        isOpenInfoPanel = true;
    }

    public void ClosePanel()
    {
        WeaponListPanelObj.MoveIndexPos(2);

        if (isOpenInfoPanel == true)
        {
            InfoPanelObj.ClosePanel();
            UpgradeBtnObj.ClosePanel();
        }
        else
        {
            ContextTxtObj.ClosePanel();
        }

        panelBackgroundImg.color = new Color(1f, 1f, 1f, 0f);
        isOpenInfoPanel = false;

        StartCoroutine(CoDelaySetActive());
    }

    IEnumerator CoDelaySetActive()
    {
        yield return new WaitForSeconds(1.0f);

        gameObject.SetActive(false);
    }
    #endregion Methods
}

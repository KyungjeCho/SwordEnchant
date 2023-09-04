using SwordEnchant.Managers;
using SwordEnchant.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    public Button[] upgradeBtn;

    public WeaponInventory inventory;
    public WeaponObjectDB weaponDB;
    private WeaponList[] weaponLists = new WeaponList[3] { WeaponList.None, WeaponList.None, WeaponList.None } ;

    public GameObject upgradeUI;
    public StaticInventoryUI inventoryUI;

    public WeaponUpgradeDB upgradeDB;

    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();

        upgradeBtn[0].onClick.AddListener(ClickBtn0);
        upgradeBtn[1].onClick.AddListener(ClickBtn1);
        upgradeBtn[2].onClick.AddListener(ClickBtn2);
    }

    public void UpdateUI()
    {
        weaponLists = new WeaponList[3] { WeaponList.None, WeaponList.None, WeaponList.None };
        int maxWeaponCount = 0;
        for (int i = 0; i < weaponDB.weaponObjects.Length; i++)
        {
            if (weaponDB.weaponObjects[i].Grade == weaponDB.weaponObjects[i].maxGrade)
            {
                maxWeaponCount++;
            }
        }

        int selectWeaponCount = 0;

        if (weaponDB.weaponObjects.Length == maxWeaponCount + selectWeaponCount)
        {
            
        }

        else
        {
            for (int i = 0; i < 3; i++)
            {
                if (weaponDB.weaponObjects.Length == maxWeaponCount + selectWeaponCount)
                {
                    break;
                }

                List<WeaponList> emptyWeaponList = new List<WeaponList>();

                for(int ii = 0; ii < weaponDB.weaponObjects.Length; ii++)
                {
                    if (weaponDB.weaponObjects[ii].Grade == weaponDB.weaponObjects[ii].maxGrade)
                        continue;
                    if (weaponLists.Contains(weaponDB.weaponObjects[ii].weaponIndex))
                        continue;

                    emptyWeaponList.Add(weaponDB.weaponObjects[ii].weaponIndex);
                }
                if (emptyWeaponList.Count == 0)
                {
                    break;
                }
                

                int index = Random.Range(0, emptyWeaponList.Count);

                weaponLists[i] = emptyWeaponList[index];
                Debug.Log(weaponLists[i]);
                upgradeBtn[i].transform.GetChild(0).GetComponent<Image>().sprite = WeaponDataManager.Instance.GetWeaponObject(weaponLists[i]).icon;

                selectWeaponCount++;
            }
        }
    }

    public void ClickBtn0()
    {
        ClickBtn(0);
    }
    public void ClickBtn1()
    {
        ClickBtn(1);
    }
    public void ClickBtn2()
    {
        ClickBtn(2);
    }

    public void ClickBtn(int num)
    {
        // 만약 인벤토리에 weaponLists[num]이 없을 경우 
        // 인벤토리에 추가
        if (inventory.IsContain(weaponLists[num]) == false)
        {
            inventory.AddWeapon(weaponLists[num]);
        }
        // 있을 경우 weaponLists[num] 강화
        else
        {
            WeaponObject weaponObject = WeaponDataManager.Instance.GetWeaponObject(weaponLists[num]);
            if (weaponObject.Grade >= weaponObject.maxGrade)
                return;

            weaponObject.Grade += 1;
            upgradeDB.db[weaponLists[num]].Upgrade(weaponObject.Grade, weaponObject.Stats);
        }
        inventoryUI.UpdateInventoryUI();
        upgradeUI.gameObject.SetActive(false);
    }
}

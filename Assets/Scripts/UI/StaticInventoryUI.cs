using SwordEnchant.Managers;
using SwordEnchant.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaticInventoryUI : MonoBehaviour
{
    public GameObject[] staticSlots = null;

    public WeaponInventory inventory;

    private void Awake()
    {
        UpdateInventoryUI();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateInventoryUI()
    {
        for (int ii = 0; ii < staticSlots.Length; ii++)
        {
            //if (inventory.slots[ii].isEmpty == false)
            //{
            //    staticSlots[ii].transform.GetChild(0).GetComponent<Image>().sprite =
            //        WeaponDataManager.Instance.GetWeaponObject(inventory.slots[ii].weaponIndex).icon;
            //    staticSlots[ii].transform.GetChild(0).GetComponent<Image>().color =
            //        new Color(1, 1, 1, 1);
            //}

            staticSlots[ii].transform.GetChild(0).GetComponent<Image>().sprite = inventory.slots[ii].isEmpty == false ? WeaponDataManager.Instance.GetWeaponObject(inventory.slots[ii].weaponIndex).icon : null;
            staticSlots[ii].transform.GetChild(0).GetComponent<Image>().color = inventory.slots[ii].isEmpty == false ? new Color(1, 1, 1, 1) : new Color(1, 1, 1, 0);

        }
    }
}

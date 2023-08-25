using SwordEnchant.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SwordEnchant.WeaponSystem
{
    public enum ChestOpenState
    { 
        READY,
        OPENNING,
        OPEN,
    }

    public class WeaponChestSystem : MonoBehaviour
    {
        [Header("--- Weapon Object ---")]
        public WeaponObjectDB db;
        public WeaponInventory inventory;
        public Image weaponIconImg;
        public Sprite goldSprite;
        public GameObject weaponInfoPanel;

        [Header("--- Weapon Info Panel ---")]
        public Image iconImg;
        public Text weaponNameTxt;
        public Text weaponContextTxt;

        private ChestOpenState state;

        private void OnEnable()
        {
            state = ChestOpenState.READY;

            
        }

        private void Update()
        {
            if (state == ChestOpenState.READY)
            {
                if (Input.GetMouseButton(0) /*|| Input.GetTouch(0).phase == TouchPhase.Began*/)
                {
                    if (db == null || inventory == null)
                        return;

                    int index;

                    if (inventory.GetFullSlotCount() >= db.weaponObjects.Length)
                    {
                        // Gold ȹ��
                        weaponIconImg.sprite = goldSprite;
                        GameManager.Instance.GetGold(333);

                        iconImg.sprite = goldSprite;
                        weaponNameTxt.text = "��� �ָӴ�";
                        weaponContextTxt.text = "���ڿ��� ��� �ָӴϰ� ���Դ�! ��¦ ��ڴ�.";
                    }
                    else
                    {
                        index = Random.Range(0, db.weaponObjects.Length);
                        while (inventory.IsContain(db.weaponObjects[index]))
                        {
                            index = Random.Range(0, db.weaponObjects.Length);
                        }
                        WeaponObject wo = db.weaponObjects[index];
                        weaponIconImg.sprite = wo.icon;

                        inventory.AddWeapon(wo);

                        iconImg.sprite = wo.icon;
                        weaponNameTxt.text = wo.Clip.weaponName;
                        weaponContextTxt.text = wo.Clip.weaponName;
                    }
                    weaponInfoPanel.SetActive(true);
                    state = ChestOpenState.OPENNING;
                    StartCoroutine(DelayForChangingState());
                }
            }

            if (state == ChestOpenState.OPEN)
            {
                if (Input.GetMouseButton(0) /*|| Input.GetTouch(0).phase == TouchPhase.Began*/)
                {
                    weaponInfoPanel.SetActive(false);
                    UIManager.Instance.CloseWeaponChestPanel();
                }
            }
        }

        IEnumerator DelayForChangingState()
        {
            yield return new WaitForSeconds(0.2f);

            state = ChestOpenState.OPEN;
        }
    }

}

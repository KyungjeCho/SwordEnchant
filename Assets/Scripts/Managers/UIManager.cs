using SwordEnchant.EventBus;
using SwordEnchant.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SwordEnchant.Managers
{
    public class UIManager : MonoSingleton<UIManager>
    {
        #region Lobby Scene
        #region Battle Enter Button
        [Header("--- Battle Enter Button ---")]
        public Button BattleEnterBtn;

        public void EnterBattleScene()
        {
            SceneManager.LoadScene(SceneManagement.Battle);
        }
        #endregion Dungen Enter Button


        #region Soul Text
        [Header("--- Soul Text ---")]
        public Text SoulTxt;

        public void UpdateSoulTxt()
        {
            SoulTxt.text = LobbyManager.Instance.soul.ToString();
        }
        #endregion Soul Text
        #endregion Lobby Scene

        #region Battle Scene
        #region Option Controll Panel
        [Header("--- Option Controll Panel ---")]
        public GameObject OptionPanelObj;
        public Button CogBtn;
        public Button OptionReturnBtn;
        public Button LobbyBtn;


        public Slider BGMVolSlider;
        public Slider EffectVolSlider;
        public Slider UIVolSlider;

        public void OpenOptionPanel()
        {
            if (OptionPanelObj != null)
                OptionPanelObj.SetActive(true);
            BattleEventBus.Publish(BattleEventType.PAUSE);
            SoundManager.Instance.Stop(true);
            InitSliders();
        }

        public void CloseOptionPanel()
        {
            if (OptionPanelObj != null)
                OptionPanelObj.SetActive(false);
            BattleEventBus.Publish(BattleEventType.RESTART);

            //SoundManager.Instance.PlayBGM((int)SoundList.Cleanup_29);
            UpdateSliders();
        }

        public void InitSliders()
        {
            BGMVolSlider.value = SoundManager.Instance.GetBGMVolume(true);
            EffectVolSlider.value = SoundManager.Instance.GetEffectVolume(true);
            UIVolSlider.value = SoundManager.Instance.GetUIVolume(true);
        }
        public void UpdateSliders()
        {
            SoundManager.Instance.SetBGMVolume(BGMVolSlider.value);
            SoundManager.Instance.SetEffectVolume(EffectVolSlider.value);
            SoundManager.Instance.SetUIVolume(UIVolSlider.value);
        }
        #endregion Option Controll Panel

        #region Warning Panel 
        [Header("--- Warning Panel ---")]
        public GameObject WarningPanelObj;
        public Button CheckBtn;
        public Button WarningReturnBtn;

        public void OpenWarningPanel()
        {
            if (WarningPanelObj != null)
                WarningPanelObj.SetActive(true);
            BattleEventBus.Publish(BattleEventType.PAUSE);
        }

        public void CloseWarningPanel()
        {
            if (WarningPanelObj != null)
                WarningPanelObj.SetActive(false);
        }

        public void ReturnToLobby()
        {
            BattleEventBus.Publish(BattleEventType.QUIT);
            SceneManager.LoadScene("LobbyScene");
        }
        #endregion Warning Panel

        #region Weapon Upgrade Panel
        [Header("--- Weapon Upgrade Panel ---")]
        public GameObject EnhancePanelObj;
        public Button UpgradeBtn;
        public Button EnhanceReturnBtn;
        
        public void OpenUpgradePanel()
        {
            if (EnhancePanelObj != null)
                EnhancePanelObj.SetActive(true);
            BattleEventBus.Publish(BattleEventType.PAUSE);
        }
        public void CloseEnhancePanel()
        {
            //if (EnhancePanelObj != null)
            //    EnhancePanelObj.SetActive(false);

            WeaponUpgradeManager.Instance.ClosePanel();
            BattleEventBus.Publish(BattleEventType.RESTART);
        }
        #endregion Weapon Upgrade Panel

        #region Weapon Chest Open Panel
        [Header("--- Weapon Chest Open Panel ---")]
        public GameObject WeaponChestPanelObj;
        public Button ChestReturnBtn;

        public void OpenWeaponChestPanel()
        {
            if (WeaponChestPanelObj != null)
                WeaponChestPanelObj.SetActive(true);
            BattleEventBus.Publish(BattleEventType.PAUSE);
        }

        public void CloseWeaponChestPanel()
        {
            if (WeaponChestPanelObj != null)
                WeaponChestPanelObj.SetActive(false);
            BattleEventBus.Publish(BattleEventType.RESTART);
        }
        #endregion Weapon Chest Open Panel

        #region Damage Text Create
        [Header("--- Damage Text ---")]
        public GameObject damageTextObj;
        public Transform damageTextRoot;

        public void CreateDamageText(Vector3 hitPoint, int hitDamage)
        {
            if (damageTextObj == null)
                return;

            GameObject go = Instantiate(damageTextObj, hitPoint, Quaternion.identity, damageTextRoot);
            go.GetComponentInChildren<TMP_Text>().text = hitDamage.ToString();
        }
        #endregion Damage Text Create

        #region Gold Soul Panel
        [Header("--- Gold Soul Info Panel ---")]
        public Text goldText;
        public Text soulText;

        public void UpdateGold()
        {
            if (goldText != null)
                goldText.text = GameManager.Instance.Gold.ToString();
        }

        public void UpdateSoul()
        {
            if (soulText != null)
                soulText.text = GameManager.Instance.Soul.ToString();
        }
        #endregion Gold Soul Panel

        #region Game Over Panel
        [Header("--- Game Over Panel ---")]
        public GameObject GameOverPanelObj;
        public Button ReturnToLobbyBtn;

        public void OpenGameOverPanel()
        {
            if (GameOverPanelObj != null)
                GameOverPanelObj.SetActive(true);
        }
        #endregion Game Over Panel
        #region Timer 
        [Header("--- Timer ---")]
        public TMP_Text timerText;

        public void UpdateTimer()
        {
            if (timerText == null)
                return;

            float elapsedTime = GameManager.Instance.ElapsedTime;
            int min = ((int)elapsedTime / 60 % 60);
            int sec = ((int)elapsedTime % 60);

            timerText.text = string.Format("{0:00}:{1:00}", min, sec);
        }
        #endregion Timer

        #region WeaponInventory Slot Create
        [Header("--- Weapon Inventory Slot ---")]
        public GameObject   slotNodePrefab;
        public Transform    slotRoot;

        public SlotNodeController CreateSlot()
        {
            GameObject go = Instantiate(slotNodePrefab, slotRoot) as GameObject;

            return go.GetComponent<SlotNodeController>();
        }
        #endregion WeaponInventory Slot Create

        #region Blood Effect Image
        [Header("--- Blood Effect ---")]
        public Image bloodEffImg;

        public void OpenBloodEffImg()
        {
            bloodEffImg.gameObject.SetActive(true);
        }

        public void CloseBloodEffImg()
        {
            bloodEffImg.gameObject.SetActive(false);
        }
        #endregion Blood Effect Image


        #endregion Battle Scene

        #region Helper Methods
        public void PlayButtonClickSound()
        {
            SoundManager.Instance.PlayOneShotEffect((int)SoundList.pickupCoin, Camera.main.transform.position, 1f);
        }
        #endregion Helper Methods

        #region Unity Method

        void Start()
        {
            // Lobby Scene UI
            if (BattleEnterBtn != null)
                BattleEnterBtn.onClick.AddListener(EnterBattleScene);

            // Battle Scene UI

            // Option Panel Open Cog
            if (CogBtn != null)
                CogBtn.onClick.AddListener(OpenOptionPanel);

            if (OptionReturnBtn != null)
                OptionReturnBtn.onClick.AddListener(CloseOptionPanel);

            if (UpgradeBtn != null)
                UpgradeBtn.onClick.AddListener(OpenUpgradePanel);

            if (LobbyBtn != null)
                LobbyBtn.onClick.AddListener(OpenWarningPanel);

            if (WarningReturnBtn != null)
                WarningReturnBtn.onClick.AddListener(CloseWarningPanel);

            if (CheckBtn != null)
                CheckBtn.onClick.AddListener(ReturnToLobby);

            if (ReturnToLobbyBtn != null)
                ReturnToLobbyBtn.onClick.AddListener(ReturnToLobby);

            if (EnhanceReturnBtn != null)
                EnhanceReturnBtn.onClick.AddListener(CloseEnhancePanel);

            if (ChestReturnBtn != null)
                ChestReturnBtn.onClick.AddListener(CloseWeaponChestPanel);
            
        }

        private void OnEnable()
        {
            BattleEventBus.Subscribe(BattleEventType.START, InitUI);
        }

        private void OnDisable()
        {
            BattleEventBus.Unsubscribe(BattleEventType.START, InitUI);
        }

        private void InitUI()
        {
            UpdateGold();
            UpdateSoul();
        }
        #endregion Unity Method
    }
}

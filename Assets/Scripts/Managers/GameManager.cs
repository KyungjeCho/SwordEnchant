using SwordEnchant.EventBus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SwordEnchant.Managers
{
    public class GameManager : MonoSingleton<GameManager>
    {
        #region Variables
        [Header("Player")]
        public Transform playerTr;

        public Scanner scanner;

        public FixedJoystick joystick;

        private int gold = 0;
        private int soul = 0;
        private float exp = 0;
        private float maxExp = 3;
        private int level = 1;

        private float elapsedTime = 4 * 60f + 45f;
        #endregion Variables

        #region Properties
        public int Gold => gold;
        public int Soul => soul;

        public float MaxExp => maxExp;
        public float Exp 
        {
            get
            {
                return exp;
            }
            set
            {
                exp += value;
                
                if (exp > maxExp)
                {
                    level++;
                    exp -= maxExp;
                    maxExp *= 1.5f;
                }
                UIManager.Instance.UpdateExpBar();
            }
        }
        public float ElapsedTime => elapsedTime;
        #endregion Properties

        #region Unity Methods
        private void Start()
        {
            BattleEventBus.Publish(BattleEventType.START);

            scanner = GetComponent<Scanner>();

            if (joystick == null)
                joystick = GameObject.Find("Canvas/Fixed Joystick")?.GetComponent<FixedJoystick>();
        }
        private void OnEnable()
        {
            BattleEventBus.Subscribe(BattleEventType.COUNTDOWN, CountdownBattle);
            BattleEventBus.Subscribe(BattleEventType.START, StartBattle);
            BattleEventBus.Subscribe(BattleEventType.RESTART, RestartBattle);
            BattleEventBus.Subscribe(BattleEventType.PAUSE, PauseBattle);
            BattleEventBus.Subscribe(BattleEventType.FINISH, FinishBattle);
            BattleEventBus.Subscribe(BattleEventType.DIE, Die);
            BattleEventBus.Subscribe(BattleEventType.QUIT, QuitBattle);

            if (playerTr == null)
                playerTr = GameObject.Find("Player").transform;
        }

        private void OnDisable()
        {
            BattleEventBus.Unsubscribe(BattleEventType.COUNTDOWN, CountdownBattle);
            BattleEventBus.Unsubscribe(BattleEventType.START, StartBattle);
            BattleEventBus.Unsubscribe(BattleEventType.RESTART, RestartBattle);
            BattleEventBus.Unsubscribe(BattleEventType.PAUSE, PauseBattle);
            BattleEventBus.Unsubscribe(BattleEventType.FINISH, FinishBattle);
            BattleEventBus.Unsubscribe(BattleEventType.QUIT, QuitBattle);
        }

        private void FixedUpdate()
        {
            elapsedTime += Time.fixedDeltaTime;

            UIManager.Instance.UpdateTimer();
        }

        #endregion Unity Methods
        private void CountdownBattle()
        {

        }
        private void StartBattle()
        {
            Time.timeScale = 0.0f;
            elapsedTime = 0f;
            gold = 0;
            LoadData();

            BattleEventBus.Publish(BattleEventType.RESTART);
            //SoundManager.Instance.PlayBGM((int)SoundList.Cleanup_29);

            playerTr.GetComponent<CharacterStat>().Initialize();

            joystick.gameObject.SetActive(true);
        }

        private void RestartBattle()
        {
            Time.timeScale = 1.0f;

            joystick.gameObject.SetActive(true);
        }

        private void PauseBattle()
        {
            Time.timeScale = 0.0f;

            joystick.gameObject.SetActive(false);
        }
        private void Die()
        {
            SaveData();

            joystick.gameObject.SetActive(false);
        }
        private void QuitBattle()
        {
            Time.timeScale = 1.0f;
            SaveData();
            Destroy(GameObject.Find($"@Pool_Root"));

            playerTr.GetComponent<CharacterStat>().isInitialized = false;

            joystick.gameObject.SetActive(false);
        }
        private void FinishBattle()
        {
            SaveData();

            // 로비 화면으로 로딩
            SceneManager.LoadScene("LobbyScene");
            Destroy(GameObject.Find($"@Pool_Root"));

            playerTr.GetComponent<CharacterStat>().isInitialized = false;

            joystick.gameObject.SetActive(false);
        }

        public void SaveData()
        {
            PlayerPrefs.SetInt(SaveDataKey.Soul, soul);
        }

        public void LoadData()
        {
            soul = PlayerPrefs.GetInt(SaveDataKey.Soul);
        }

        public void GetGold(int amount)
        {
            gold += amount;

            UIManager.Instance.UpdateGold();
        }

        public void GetSoul(int amount)
        {
            soul += amount;

            UIManager.Instance.UpdateSoul();
        }

        
    }
}


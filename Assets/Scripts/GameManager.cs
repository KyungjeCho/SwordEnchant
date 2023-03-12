using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] public long gold;
    [SerializeField] public long goldIncreseAmount;

    [SerializeField] public Text goldText;
    [SerializeField] public Text enhancementText;

    [SerializeField] public Text costText;
    [SerializeField] public Text nextEnhanceInfoMain;

    [SerializeField] public Sword Sword;

    [SerializeField] public GameObject PrefabCoin;
    [SerializeField] public GameObject PrefabEnchanting;

    public ResultWord successWord;
    public ResultWord keepWord;
    public ResultWord fallWord;
    public ParticleSystem enchantingParticle;
    public ParticleSystem starParticle;
    public ParticleSystem successParticle;

    public ParticleSystem bottomArrowParticle;
    public GameObject MainPanel;
    public GameObject QuitCanvas;

    private bool isAction = false;
    private bool isCheck = false;

    private void Update() 
    {
        ShowInfo();
        MoneyIncrease();

        if (Input.GetMouseButtonDown(0) && isCheck)
        {
            if (EventSystem.current.IsPointerOverGameObject() == false)
            {
                CheckResult();
            }
        }

        if(Input.GetKey(KeyCode.Escape))
        {
            QuitCanvas.SetActive(true);
        }
    }

    public void MoneyIncrease()
    {
        if (Input.GetMouseButtonDown(0) && !isAction)
        {
            if (EventSystem.current.IsPointerOverGameObject() == false)
            {
                gold += goldIncreseAmount;
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Instantiate(PrefabCoin, mousePosition, Quaternion.identity);
            }
        }
    }

    public void ShowInfo()
    {
        if (gold == 0)
            goldText.text = "0";
        else
            goldText.text = gold.ToString("###,###");

        enhancementText.text = Sword.enhancementNumber.ToString() + "강";

        costText.text = "강화비용: " + Sword.CurrentCost().ToString() + "원";

        nextEnhanceInfoMain.text = Sword.enhancementNumber.ToString() + "강 > " + (Sword.enhancementNumber + 1).ToString() + "강";
    }

    public void EnhanceSword(int result)
    {
        if (gold >= Sword.CurrentCost())
        {
            gold -= Sword.CurrentCost();

            switch(result)
            {
                case (3):
                    Debug.Log("0");
                    Sword.enhancementNumber ++;
                    goldIncreseAmount += Sword.efficient[Sword.enhancementNumber - 1];
                    break;
                case (2):
                    Debug.Log("1");
                    break;
                case (1):
                    Debug.Log("3");
                    Sword.enhancementNumber --;
                    goldIncreseAmount -= Sword.efficient[Sword.enhancementNumber];
                    break;
                case (0):
                    Debug.Log("4");
                    Sword.enhancementNumber = 0;
                    goldIncreseAmount = 1;
                    break;
            }
        }
    }

    public void GenerateEnchanting()
    {
        // 돈과 비용 확인 
        if (gold < Sword.CurrentCost())
            return;
        
        // 강화 확률 돌리기
        int result = Sword.RandomEnhancement();
        isAction = true;

        // 강화 이펙트 -> 결과 보여주기
        PlayEnchantingAnimation();

        StartCoroutine(IDelaySecondsCoroutine(result));
    }

    public void TestParticle()
    {
        StartCoroutine(TurnPanelOffOn());
        enchantingParticle.Play();
        Sword.PlayAnimation("Enchanting");
    }

    public void PlayEnchantingAnimation()
    {
        MainPanel.SetActive(false);
        enchantingParticle.Play();
        Sword.PlayAnimation("Enchanting");
    }

    public void TestSuccessParticle()
    {
        successWord.ShowResult();
        starParticle.Play();
        successParticle.Play();
    }

    public void TestKeepParticle()
    {
        keepWord.ShowResult();
    }

    public void TestFallParticle()
    {
        fallWord.ShowResult();
        bottomArrowParticle.Play();
    }

    IEnumerator TurnPanelOffOn()
    {
        MainPanel.SetActive(false);

        yield return new WaitForSeconds(3.0f);

        MainPanel.SetActive(true);

        yield return null;
    }

    IEnumerator IDelaySecondsCoroutine(int result)
    {
        yield return new WaitForSeconds(3f);

        // todo: result 에 따라 다른 이펙트 플레이
        isCheck = true;
        if (result == 3)
            TestSuccessParticle();
        else if (result == 2)
            TestKeepParticle();
        else if (result == 1)
            TestFallParticle();
            
        EnhanceSword(result);
        yield return null;
    }

    public void CheckResult()
    {
        successWord.BlindResult();
        keepWord.BlindResult();
        fallWord.BlindResult();
        MainPanel.SetActive(true);
        isAction = false;
        isCheck = false;
        enchantingParticle.Stop();
        successParticle.Stop();
        starParticle.Stop();
        bottomArrowParticle.Stop();
        Sword.PlayAnimation("Idle");
    }

    public void QuitGame()
    {
        // todo: save
        
        Application.Quit();
    }
}

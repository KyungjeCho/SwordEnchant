using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinMove1 : MonoBehaviour
{
    public float DistanceThreshold;
    public int GoldAmount;
    public float Speed;

    public GameObject Player;
    public GameObject MoneyTextPrefab;

    private bool isAbleToMove;
    private bool isAbleToGet;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        isAbleToMove = false;
        isAbleToGet = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (CalculateDistance() <= DistanceThreshold && !isAbleToMove)
        {
            isAbleToMove = true;
        }

        if (isAbleToMove)
        {
            transform.position = Vector3.Lerp(transform.position, Player.transform.position, Speed * Time.deltaTime);
        }
    }

    private float CalculateDistance()
    {
        return Vector2.Distance(this.transform.position, Player.transform.position);
    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player" && isAbleToGet)
        {
            isAbleToGet = false;
            // 골드 상승
            //PlayerStat playerStat = Player.GetComponent<PlayerStat>();
            //playerStat.Money += GoldAmount;
            //DataManager.Gold += GoldAmount;
            // 
            GameObject MoneyText = Instantiate(MoneyTextPrefab, transform.position, transform.rotation);
            MoneyText.GetComponent<MoneyText>().Reset();
            MoneyText.GetComponent<MoneyText>().SetText(GoldAmount);
            
            PlaySound();
            // fadeout
            StartCoroutine(Fadeout());
        }
    }

    public IEnumerator Fadeout()
    {
        float alpha = 0f;
        while (alpha < 1f)
        {
            alpha += 0.01f;
            yield return new WaitForSeconds(0.0f);
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f - alpha);
        }

        this.gameObject.SetActive(false);
        Destroy(this);
        yield return null;
    }

    void PlaySound()
    {
        audioSource.Play();
    }
}

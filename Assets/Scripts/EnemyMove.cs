using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public GameObject Target;
    public GameObject DropItem;
    public AudioManager AM;
    public Sprite DeadImage;

    private Rigidbody2D rigid;
    private SpriteRenderer spriteRenderer;
    private EnemyStat stat;
    private Animator animator;
    private AudioSource audioSource;

    private bool isAvailable;
    private bool isDead;
    
    // Start is called before the first frame update
    void Start()
    {
        rigid           = GetComponent<Rigidbody2D>();
        stat            = GetComponent<EnemyStat>();
        spriteRenderer  = GetComponent<SpriteRenderer>();
        animator        = GetComponent<Animator>();
        audioSource     = GetComponent<AudioSource>();

        isAvailable         = true;
        isDead              = false;
        audioSource.clip    = AM.EnemyHit;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAvailable)
        {
            if (Target.transform.position.x - transform.position.x > 0)
                transform.localScale = new Vector3(-1f, 1f, 1f);
            else    
                transform.localScale = new Vector3(1f, 1f, 1f);

            rigid.velocity = stat.Speed * (Target.transform.position - transform.position).normalized * Time.deltaTime  * 10f;
            
        }
            

        if (stat.Hp <= 0 && !isDead)
        {
            isDead = true;
            // 골드나 경험치 생성
            Instantiate(DropItem, transform.position, Quaternion.identity);

            // 죽는 스프라이트로 변경
            animator.SetTrigger("Dead");
            // Fade out Coroutine
            StartCoroutine(Fadeout());
        }
    }

    public void OnDamaged(float damage)
    {
        Vector3 d = transform.position - Target.transform.position;
        // rigid.velocity = new Vector2(0f, 0f);
        StartCoroutine(Knockback(20f, 10f));
                
        audioSource.Play();
        stat.Hp -= damage;
    }

    
    public IEnumerator Knockback(float duration, float power)
    {
        float timer = 0f;
        isAvailable = false;

        while (timer <= duration)
        {
            timer += Time.deltaTime;
            //yield return new WaitForSeconds(0.01f);
            rigid.AddRelativeForce(power * (transform.position - Target.transform.position).normalized);
        }    

        isAvailable = true;

        yield return 0;
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

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            // OnDamaged
            PlayerMove playerMove = other.transform.GetComponent<PlayerMove>();
            playerMove.OnDamaged(stat.Att);
        }    
    }

    public void PlayerDead()
    {
        isAvailable = false;
        Debug.Log("Dead");
    }
}

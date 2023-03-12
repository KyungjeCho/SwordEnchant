using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D     m_rigid;
    private PlayerStats      m_stat;

    private SpriteRenderer  m_renderer;
    private Blink           blink;
    private AudioSource     audioSource;
    public  Joystick        MobileJoystick;

    [SerializeField]
    private float h;
    [SerializeField]
    private float v;

    private float alpha;
    private bool isBlinkWalking = false;
    public  int FaceDirection = 1;
    public  Slider HpSlider;
    public  AudioManager AM;

    void Start()
    {
        m_rigid     = GetComponent<Rigidbody2D>();
        m_stat      = GetComponent<PlayerStats>();
        m_renderer  = GetComponent<SpriteRenderer>();
        blink       = GetComponent<Blink>();
        audioSource = GetComponent<AudioSource>();

        transform.position  = Vector2.zero;
        audioSource.clip    = AM.PlayerHit;
    }

    // Update is called once per frame
    void Update()
    {
        // PC INPUT
        //h           = Input.GetAxisRaw("Horizontal");
        //v           = Input.GetAxisRaw("Vertical");
        
        // MOBILE INPUT
        h           = MobileJoystick.Horizontal;
        v           = MobileJoystick.Vertical;

        if (h < 0)
            FaceDirection = -1;
        else if(h > 0)
            FaceDirection = 1;

        /*
        transform.localScale = new Vector3((float)FaceDirection, 1f, 1f);

        // blink
        blink.BlinkAnim();

        // Update & Show Hp bar
        ShowHp();
        */
    }

    void FixedUpdate()
    {
        Vector2 moveVec = new Vector2(h, v).normalized;
        m_rigid.velocity = m_stat.Speed * moveVec;
    }

    public void OnDamaged(float damage)
    {
        // 데미지 맞음
        m_stat.Hp -= damage;

        // 잠시 무적 -> 코루틴 호출
        int playerInvincibleLayer = LayerMask.NameToLayer("PlayerInvincible");
        gameObject.layer = playerInvincibleLayer;
        // Audio Play
        audioSource.Play();
        blink.Reset();
    }

    private void ShowHp()
    {
        HpSlider.value = GetHpRatio();
    }

    private float GetHpRatio()
    {
        return m_stat.Hp / m_stat.MaxHp;
    }
}

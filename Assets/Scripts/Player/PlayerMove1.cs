using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove1 : MonoBehaviour
{
    private Rigidbody2D     m_rigid;
    private PlayerStats     m_stat;
    private Joystick        mobileJoystick;

    private PlayerController _playerController;

    [SerializeField]
    private float h;
    [SerializeField]
    private float v;

    public  int FaceDirection = 1;

    void Start()
    {
        m_rigid         = GetComponent<Rigidbody2D>();
        m_stat          = GetComponent<PlayerStats>();
        mobileJoystick  = GameObject.Find("Floating Joystick").GetComponent<Joystick>();
        _playerController = this.GetComponent<PlayerController>();
    }

    void Update()
    {
        // PC INPUT
        //h           = Input.GetAxisRaw("Horizontal");
        //v           = Input.GetAxisRaw("Vertical");
        
        // MOBILE INPUT
        h           = mobileJoystick.Horizontal;
        v           = mobileJoystick.Vertical;

        if (h < 0)
            FaceDirection = -1;
        else if(h > 0)
            FaceDirection = 1;
    }

    void FixedUpdate()
    {
        if (h == 0 && v == 0)
        {
            _playerController.IdlePlayer();
        }
        else
        {
            Vector2 _moveVec = new Vector2(h, v).normalized;
            _playerController.MovePlayer(m_stat.Speed * _moveVec);
        }
    }
}

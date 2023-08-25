using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    [Range(0.0f, 1.0f)]
    [SerializeField] private float m_speed = 0.1f;

    private Vector3 m_target;

    private float currentNum = 0.0f;
    public float maxNum = 1.0f;
    public float minNum = -1.0f;

    // Start is called before the first frame update
    void Awake()
    {
        m_target = new Vector3(0f, 0f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        Vector3 a = transform.position;
        Vector3 b = m_target;
        transform.position = Vector3.Lerp(a, b, m_speed);
    }

    public void SetTarget(Vector2 _target)
    {
        m_target = new Vector3(_target.x, _target.y, transform.position.z);
    }

    public void SetMerchandiseTarget()
    {
        m_target = new Vector3(-7.4f, 0.0f, transform.position.z);
    }

    public void SetEnhanceTarget()
    {
        m_target = new Vector3(0f, 0f, transform.position.z);
    }

    public void MoveLeft()
    {
        currentNum--;
        m_target = new Vector3(7.4f * currentNum, 0f, transform.position.z);
    }
    public void MoveRight()
    {
        currentNum++;
        m_target = new Vector3(7.4f * currentNum, 0f, transform.position.z);
    }
    
}

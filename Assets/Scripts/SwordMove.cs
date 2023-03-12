using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMove : MonoBehaviour
{
    public PlayerMove Player;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        if (Player.FaceDirection < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            animator.SetTrigger("Left");
        }
        else
        {
            animator.SetTrigger("Right");
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Enemy")
        {
            EnemyMove s = other.transform.GetComponent<EnemyMove>();
            s.OnDamaged(5f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetRunningAnimation()
    {
        animator.SetBool("Is Running", true);
    }

    public void SetIdleAnimation()
    {
        animator.SetBool("Is Running", false);
    }

    public void SetAttackAnimation()
    {
        animator.SetTrigger("Attack");
    }

    public void SetDeadAnimaion()
    {
        animator.SetTrigger("Dead");
    }
}

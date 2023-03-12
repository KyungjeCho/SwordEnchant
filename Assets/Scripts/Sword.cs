using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [Range(0, 26)]
    [SerializeField] public int enhancementNumber;

    [SerializeField] public int[] enhancementCosts;

    [SerializeField] public float[] enhancementSuccessProb;

    [SerializeField] public float[] enhancementKeepProb;

    [SerializeField] public float[] enhancementFallProb;

    [SerializeField] public float[] enhancementDestoryProb;

    [SerializeField] public int[] efficient;

    Animator animator;

    public enum State
    {
        Success,
        Keep,
        Fall,
        Destroy,
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ;
        }
    }

    public int RandomEnhancement()
    {
        float value = Random.Range(0, 100);
        float[] p = {
            enhancementSuccessProb[enhancementNumber], 
            enhancementKeepProb[enhancementNumber],
            enhancementFallProb[enhancementNumber],
            enhancementDestoryProb[enhancementNumber]
        };

        float cumulative = 0f;
        int target = -1;

        for(int i = 0; i < 4; i++) 
        {
            cumulative += p[i];
            if (value <= cumulative)
            {
                target = 3 - i;
                break;
            }
        }
        return target;
    }

    public int CurrentCost() => enhancementCosts[enhancementNumber];

    public void PlayAnimation(string triggerName)
    {
        animator.SetTrigger(triggerName);
    }
}

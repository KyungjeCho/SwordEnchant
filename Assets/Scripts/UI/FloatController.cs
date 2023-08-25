using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FloatController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RectTransform tr = GetComponent<RectTransform>();
        
        tr.DOLocalMoveY(tr.rect.y + 1f, 1.0f)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.InOutSine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

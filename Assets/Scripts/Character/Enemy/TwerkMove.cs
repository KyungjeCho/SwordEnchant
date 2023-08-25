using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwerkMove : MonoBehaviour
{
    #region Variables
    public bool isTwerk = true;

    private float timer;

    public float duration = 2f;
    public float speed = 10f;
    private int way = 1;
    #endregion Variables

    // Start is called before the first frame update
    void OnEnable()
    {
        isTwerk = true;
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += way * Time.deltaTime * speed;

        if (timer > duration)
        {
            way *= -1;
        }
        if (timer < -duration)
        {
            way *= -1;
        }
        transform.eulerAngles = new Vector3(0f, 0f, timer);
    }
}

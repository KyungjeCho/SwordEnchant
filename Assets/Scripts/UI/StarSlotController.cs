using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSlotController : MonoBehaviour
{
    public GameObject StarImgObj;

    // Start is called before the first frame update
    void Start()
    {
        //SetStarDisable();
    }

    public void SetStarEnable()
    {
        StarImgObj.gameObject.SetActive(true);
    }

    public void SetStarDisable()
    {
        StarImgObj.gameObject.SetActive(false);
    }
}

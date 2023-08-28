using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRes : MonoBehaviour
{
    public static Vector2 top;
    public static Vector2 bottom;
    public static Vector2 left;
    public static Vector2 right;

    private void Start()
    {
        CalcCameraSize();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        CalcCameraSize();
    }

    public void CalcCameraSize()
    {
        top = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width * 0.5f, Screen.height));
        bottom = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width * 0.5f, 0f));
        left = Camera.main.ScreenToWorldPoint(new Vector2(0f, Screen.height * 0.5f));
        right = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height * 0.5f));


    }
}

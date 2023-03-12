using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    private float timer;

    public float minutes;

    public float seconds;

    public TextMeshProUGUI DisplayText;

    public bool isPause;

    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPause)
            timer += Time.deltaTime;
        UpdateTimerDisplay();
    }

    public void ResetTimer()
    {
        timer = 0f;
        isPause = false;
    }

    public void UpdateTimerDisplay()
    {
        minutes = Mathf.FloorToInt(timer / 60);
        seconds = Mathf.FloorToInt(timer % 60);

        string currentTime = string.Format("{00:00} : {1:00}", minutes, seconds);
        DisplayText.text = currentTime;
    }
}

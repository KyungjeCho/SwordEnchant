using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_ : MonoSingleton<GameManager_>
{
    void Start()
    {
        // Scene Start , Initiate All Object

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        Timer timer = GetComponent<Timer>();
        timer.isPause = true;
    }

    public void ResumeGame()
    {
        Timer timer = GetComponent<Timer>();
        timer.isPause = false;
    }

    public void QuitScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}

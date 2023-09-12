using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    public float time = 0.0f;
    public GameObject paddle;
    public GameObject gameOver;
    public Text timeText;
    private float playerLife;

    private bool gamePlay = false;

    private void Start()
    {
        Time.timeScale = 0.0f;
        gamePlay = false;
    }

    private void Update()
    {
        if (gamePlay)
        {
            time -= Time.deltaTime;
            timeText.text = time.ToString("N0");
            lifeCheck();
            if (time <= 0.0f)
            {
                GameOver();
            }
        }
        
        
    }


    public void GoMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void GoStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void OnOffPopUP(GameObject gameObject)
    {
        if (gameObject.activeSelf == false)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void lifeCheck()
    {
        playerLife = paddle.GetComponent<PaddleController>().life;
        if(playerLife > 3.0f)
        {
            playerLife = 3.0f;
        }
        if (playerLife == 3.0f)
        {
            life1.SetActive(true);
            life2.SetActive(true);
            life3.SetActive(true);
        }
        else if(playerLife == 2.0f)
        {
            life3.SetActive(false);
        }
        else if(playerLife == 1.0f)
        {
            life2.SetActive(false);
        }
        else if (playerLife <= 0.0f)
        {
            life1.SetActive(false);
            GameOver();
        }
    }
    public void Pause()
    {
        gamePlay = false;
        Time.timeScale = 0.0f;
    }
    public void Resume()
    {
        gamePlay = true;
        Time.timeScale = 1.0f;
    }

    public void GameStart()
    {
        time = 120.0f;
        Time.timeScale = 1.0f;
        gamePlay = true;
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;
        gameOver.SetActive(true);
        gamePlay = false;
    }


    public void GameExit()
    {
        Application.Quit();
    }

}

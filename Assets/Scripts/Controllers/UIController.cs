using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    
    // Start is called before the first frame update
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

    public void GameExit()
    {
        Application.Quit();
    }

}

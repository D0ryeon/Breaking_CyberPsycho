using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadline : MonoBehaviour
{
    public GameObject Ball;
    public GameObject Life;
    public GameObject startGame;
    public GameObject endGame;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball_Sprite")
        {

            Debug.Log("retry");
            startGame.SetActive(true);
            Ball.transform.localPosition = new Vector3(0f,0f,0f);
            Life.GetComponent<PaddleController>().removeLife();
            if (Life.GetComponent<PaddleController>().life <= 0)
            {
                Time.timeScale = 0f;
            }
        }
    }
}

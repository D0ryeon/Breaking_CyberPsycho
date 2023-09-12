using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    SpriteRenderer sr;
    public BrickData brickData;
    int BrickHp;
    int BrickScore;

   

    private void Start()
    {
        BrickHp = brickData.Hp;
        BrickScore = brickData.Score;
        sr = this.GetComponent<SpriteRenderer>();
       

    }

    private void Update()
    {

    }
        public void PrintBrick()
    {
        Debug.Log("���̸�::" + brickData.BrickName);
        Debug.Log("��Hp::" + brickData.Hp);
        Debug.Log("������::" + brickData.Color);
    }

 


    private void OnCollisionEnter2D(Collision2D other)
    {
       
        if (other != null)
        {
            Debug.Log(other.gameObject.name);

          
            if (other.gameObject.name == "Ball_Sprite")
            {
                switch (BrickHp)
                {
                    case > 4:
                        sr.color = Color.black;
                        break;
                    case  4:
                        sr.color = Color.blue;
                        break;
                    case 3:
                        sr.color = Color.red;
                        break;
                    case 2:
                        sr.color = Color.white;
                        break;
                    case  1:
                        Destroy(gameObject);
                        StageManager.BrickCount--;
                        StageManager.score += BrickScore;

                       

                        break;             
                }            
                BrickHp--;

                Debug.Log(BrickHp);
                
            }
        }
    }


}



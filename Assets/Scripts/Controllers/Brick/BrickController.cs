using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    public BrickData brickData;
    int BrickHp;



    private void Start()
    {
         BrickHp = brickData.Hp;

    }

    private void Update()
    {

    }
        public void PrintBrick()
    {
        Debug.Log("블럭이름::" + brickData.BrickName);
        Debug.Log("블럭Hp::" + brickData.Hp);
        Debug.Log("블럭색갈::" + brickData.Color);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
       
        if (other != null)
        {
            Debug.Log(other.gameObject.name);

          
            if (other.gameObject.name == "Ball")
            {
              
                Debug.Log("충돌");
                if (BrickHp == 1)
                {
                    Debug.Log("DestroyBrick");
                    Destroy(gameObject);                   
                }
                BrickHp--;

                Debug.Log(BrickHp);
                
            }
        }
    }
}

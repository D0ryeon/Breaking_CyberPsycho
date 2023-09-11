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
        Debug.Log("���̸�::" + brickData.BrickName);
        Debug.Log("��Hp::" + brickData.Hp);
        Debug.Log("������::" + brickData.Color);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
       
        if (other != null)
        {
            Debug.Log(other.gameObject.name);

          
            if (other.gameObject.name == "Ball")
            {
              
                Debug.Log("�浹");
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

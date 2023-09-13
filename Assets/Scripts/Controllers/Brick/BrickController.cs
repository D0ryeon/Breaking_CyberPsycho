using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BrickController : MonoBehaviour
{
    SpriteRenderer sr;
    public BrickData brickData;
    public GameObject PItem;


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
                        BrickDestroy(other.transform);





                        break;             
                }            
                BrickHp--;

                Debug.Log(BrickHp);
                
            }
        }
    }

    public void PrintBrick()
    {
        Debug.Log("ºí·°ÀÌ¸§::" + brickData.BrickName);
        Debug.Log("ºí·°Hp::" + brickData.Hp);
        Debug.Log("ºí·°»ö°¥::" + brickData.Color);
    }

     void BrickDestroy(Transform ColTr)
    {
        ItemGenerator(ColTr.position);
        Destroy(gameObject);
        SoundManager.Instance.BlockBrokenSound();
        StageManager.BrickCount--;
        StageManager.score += BrickScore;
    }
    void ItemGenerator(Vector2 CoITr)
    {
        int rand = Random.Range(0, 10000);
        if(rand < 1000)
        {
            string currentName = "";
            switch (rand % 3)
            {
                case 0: currentName = "Item1"; break;
                case 1: currentName = "Item2"; break;
                case 2: currentName = "Item3"; break;

            }
             GameObject item = Instantiate(PItem, CoITr,Quaternion.identity);
             item.name = currentName;

            item.GetComponent<Rigidbody2D>().AddForce(Vector2.down*0.008f);            
        }
    }

}



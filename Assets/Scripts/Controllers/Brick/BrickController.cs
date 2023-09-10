using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    public BrickData brickData;
    public StageManager newBrick;



    private void Start()
    {
      
        newBrick = GetComponent<StageManager>();
    }
    public void PrintBrick()
    {
        Debug.Log("블럭이름::" + brickData.BrickName);
        Debug.Log("블럭Hp::" + brickData.Hp);
        Debug.Log("블럭색갈::" + brickData.Color);
    }
    

    private void BrickDistroid(Collider other)
    {
        int BrickHp = brickData.Hp;
        if (other.gameObject.name == "Ball")
        {
            if (BrickHp <= 0)
            {
                Debug.Log("DestroyBrick");

                Destroy(this.gameObject);

                newBrick.Stage1BrickCount--;
            }
            BrickHp--;
        }
    }
}

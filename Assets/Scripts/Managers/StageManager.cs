using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BrickType { Normal, Red, Blue,Boss }
public class StageManager : MonoBehaviour
{
    [SerializeField]
    private List<BrickData> brickDatas;
    [SerializeField]
    private GameObject brickPrefab;
    public float xOffset = 2f;

    [Header("Stage1")]
    [SerializeField]
    private GameObject Stag1Brick;

    public int Stage1BrickCount  ;



   
    void Start()
    {
       
        Stage1();
       
    }
    void Update()       
    {
        Stage1BrickCount = Stag1Brick.transform.childCount;
        if (Stag1Brick.transform.childCount == 0)
        {
            Time.timeScale = 0; // stage1 end
        }
    }


        public BrickController SpawnBrick(BrickType type)
    {

        var newBrick = Instantiate(brickPrefab).GetComponent<BrickController>();
        newBrick.transform.SetParent(Stag1Brick.transform);
        newBrick.brickData = brickDatas[(int)type];
        newBrick.name = newBrick.brickData.BrickName;
        return newBrick;
    }

    public void Stage1()
    {

        int brickCount = brickDatas.Count;
        float currentX = -10f;
        float currentY = 0;
       
        for (int i = 0; i < brickCount; i++)
        {
            for (int j = 0; j < 9; j++)
            {

                currentX += xOffset;
                brickPrefab.GetComponent<SpriteRenderer>().color = brickDatas[i].Color;
                brickPrefab.GetComponent<SpriteRenderer>().sprite = brickDatas[i].sprite;
                Vector3 newPosition = new Vector3(currentX, currentY, this.transform.position.z);
                brickPrefab.transform.position = newPosition;

                var brick = SpawnBrick((BrickType)i);
               
                brick.PrintBrick();

            }

            currentY++;
            currentX = -10f;
        }
     
    }

   
}

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
    private GameObject stage1;

    public int Stage1BrickCount;



   
    void Start()
    {
        Stage1();
    }


    public BrickController SpawnBrick(BrickType type)
    {

        var newBrick = Instantiate(brickPrefab).GetComponent<BrickController>();
        newBrick.transform.SetParent(stage1.transform);
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
                Vector3 newPosition = new Vector3(currentX, currentY, this.transform.position.z);
                brickPrefab.transform.position = newPosition;

                var brick = SpawnBrick((BrickType)i);
                Stage1BrickCount++;
                brick.PrintBrick();

            }

            currentY++;
            currentX = -10f;
        }
    }
}

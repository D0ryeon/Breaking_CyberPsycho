using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BrickType { Boss, Blue,Red,Normal }
public class StageManager : MonoBehaviour
{
    [SerializeField]
    private List<BrickData> brickDatas;
    [SerializeField]
    private GameObject brickPrefab;
   
    public float xOffset = 2f;
    void Start()
    {
        int brickCount = brickDatas.Count;
        float currentX = -10f;
        float currentY = 0;

        for (int i = 0; i < brickCount; i++)
        {
            for (int j = 0; j < 9; j++)
            {
               
                currentX += xOffset;
                // 새로운 위치 설정
                Vector3 newPosition = new Vector3(currentX, currentY, this.transform.position.z);

                brickPrefab.transform.position = newPosition;
                var brick = SpawnBrick((BrickType)i);
                brick.PrintBrick();

            }
       
            currentY++;
            currentX = -10f;
        }
    }

    public BrickController SpawnBrick(BrickType type)
    {
        
        var newBrick = Instantiate(brickPrefab).GetComponent<BrickController>();
        newBrick.transform.SetParent(this.transform);
        newBrick.brickData = brickDatas[(int)type];
        newBrick.name = newBrick.brickData.BrickName;
        return newBrick;
    }
}

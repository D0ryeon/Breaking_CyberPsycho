using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BrickType { Normal, Red, Blue, Boss }
public class StageManager : MonoBehaviour
{
    [SerializeField]
    private List<BrickData> brickDatas;
    [SerializeField]
    private GameObject brickPrefab;
   
    public float xOffset = 10f;
    [SerializeField]
    private float currentX = -10f;
    void Start()
    {
        
        for (int i = 0; i < brickDatas.Count; i++)
        {
            for (int j = 1; j < 2; j++)
            {
                currentX += xOffset;
                // 새로운 위치 설정
                Vector3 newPosition = new Vector3(currentX, this.transform.position.y, this.transform.position.z);
                this.transform.position = newPosition;
                var brick = SpawnBrick((BrickType)i);
                brick.PrintBrick();
            }                        
           
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

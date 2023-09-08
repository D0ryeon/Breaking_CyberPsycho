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
   
    public float xOffset = 0.1f;

    private float currentX = 0f;
    void Start()
    {
        
        for (int i = 0; i < brickDatas.Count; i++)
        {
           
           var brick = SpawnBrick((BrickType)i);
            brick.PrintBrick();

            currentX += xOffset;

            // 새로운 위치 설정
            Vector3 newPosition = new Vector3(currentX, this.transform.position.y, this.transform.position.z);
            this.transform.position = newPosition;
        }
    }

    public BrickController SpawnBrick(BrickType type)
    {
        
        var newBrick = Instantiate(brickPrefab, new Vector3(2, 0, 0), Quaternion.identity).GetComponent<BrickController>();
        newBrick.transform.SetParent(this.transform);
        newBrick.brickData = brickDatas[(int)type];
        newBrick.name = newBrick.brickData.BrickName;
        return newBrick;
    }
}

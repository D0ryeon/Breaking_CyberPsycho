using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
public BrickData brickData;

    public void PrintBrick()
    {
        Debug.Log("���̸�::" + brickData.BrickName);
        Debug.Log("��Hp::" + brickData.Hp);
    }
}

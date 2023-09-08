using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
public BrickData brickData;

    public void PrintBrick()
    {
        Debug.Log("블럭이름::" + brickData.BrickName);
        Debug.Log("블럭Hp::" + brickData.Hp);
    }
}

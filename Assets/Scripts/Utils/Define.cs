using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum BrickState
    {
        Active,
        UnActive
    }

    public enum Scene
    {
        Start,
        Main
    }

    public enum BrickHP
    {
        Normal,
        Red,
        Blue,
        Boss
    }

    public enum Stage
    {
        One,
        Two,
        Three
    }

   public enum ItemType
    {
        PlayerLife,
        GameTime,
        BallSpeed,
        PaddleSize,
        BallCount,
        End,
    }

    public enum UIEvent
    {
        Click,
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    public int score { get; set; }
    public string name { get; set; }

    public Score(int score, string name)
    {
        this.score = score;
        this.name = name;
    }
}

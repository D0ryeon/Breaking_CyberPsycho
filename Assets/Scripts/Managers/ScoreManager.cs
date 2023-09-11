using System.Collections.Generic;

public class Score
{
    public int score { get; set; }
    public string name { get; set; }
}


public class ScoreManager
{
    private const string SCORE_FILE_NAME = "PlayerScore";

    public void SaveScore(Score score)
    {
        FileIO.SaveJsonFile<Score>(score, SCORE_FILE_NAME);
    }

    public Score GetHighScore()
    {
        List<Score> scoreList = FileIO.LoadJsonFile<List<Score>>(SCORE_FILE_NAME);

        if (scoreList.Count == 0)
            return null;

        Score highScore = null;
        int highScoreNum = 0;
        foreach (Score scoreObj in scoreList)
        {
            if (highScoreNum < scoreObj.score)
                highScoreNum = scoreObj.score;
        }

       foreach (Score scoreObj in scoreList)
        {
            if (highScoreNum == scoreObj.score)
                highScore = scoreObj;
        }

        return highScore;
    }

    public List<Score> GetTopFiveScore()
    {
        List<Score> scoreList = FileIO.LoadJsonFile<List<Score>>(SCORE_FILE_NAME);
        
        scoreList.Sort((x, y) => {
            return x.score.CompareTo(y.score);
        });


        List<Score> topFiveScoreList = new List<Score>();
        if (scoreList.Count >= 5)
        {
            topFiveScoreList = scoreList.GetRange(0, 5);
        }
        else
        {
            foreach (Score scoreObj in scoreList)
                topFiveScoreList.Add(scoreObj);
        }

        return topFiveScoreList;
    }
}

using System.Collections.Generic;

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

        if (scoreList == null || scoreList.Count == 0)
            return new Score();

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

    public List<Score> GetTopSevenScore()
    {
        List<Score> scoreList = FileIO.LoadJsonFile<List<Score>>(SCORE_FILE_NAME);
        
        if (scoreList == null || scoreList.Count == 0)
            return null;

        scoreList.Sort((x, y) => {
            return y.score.CompareTo(x.score);
        });


        List<Score> topSevenScoreList = new List<Score>();
        if (scoreList.Count >= 7)
        {
            topSevenScoreList = scoreList.GetRange(0, 7);
        }
        else
        {
            foreach (Score scoreObj in scoreList)
                topSevenScoreList.Add(scoreObj);
        }

        return topSevenScoreList;
    }
}

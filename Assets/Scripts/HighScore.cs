using System;
using System.Collections.Generic;

[System.Serializable]
public struct HighScore
{
    public int score;
    public string datetime;
    public float timeElapsed;
    public int scoreFromBonuses;

    public HighScore(int score, string datetime, float timeElapsed, int scoreFromBonuses)
    {
        this.score = score;
        this.datetime = datetime;
        this.timeElapsed = timeElapsed;
        this.scoreFromBonuses = scoreFromBonuses;
    }
}

[System.Serializable]
public class HighScoresList
{
    public List<HighScore> highScores;

    public HighScoresList()
    {
        highScores = new List<HighScore>();
    }
}

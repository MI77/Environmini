using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI gameOverPanelScoreText;
    [SerializeField]
    private TextMeshProUGUI highScoreText;
    [SerializeField]
    private TextMeshProUGUI targetScoreText;
    [SerializeField]
    private TextMeshProUGUI bonusScoreText;
    [SerializeField]
    private string defaultScoreText = "Score: ";
    [SerializeField]
    private string defaultTargetText = "Target: ";
    [SerializeField]
    private string defaultHighScoreText = "High score: ";
    [SerializeField]
    private GameObject highScoreMenuContainer;
    [SerializeField]
    private GameObject highScoreMenuPrefab;

    public SettingsSO settings;

    private HighScoresList highScoresList;

    private void Awake()
    {
        //get the highscores from playerprefs
        string json = PlayerPrefs.GetString("highScoresList");
        highScoresList = JsonUtility.FromJson<HighScoresList>(json);

        if (highScoresList != null)
        {
            // add an entry to the highscores menu for each highscore
            //TODO : apply some alternate-row shading
            var numScores = Math.Min(highScoresList.highScores.Count-1, 9);
            for (int i = 0; i <= numScores; i++)
            {
                var menuEntry = Instantiate(highScoreMenuPrefab, highScoreMenuContainer.transform);
                menuEntry.transform.Find("Date").GetComponent<TextMeshProUGUI>().text = highScoresList.highScores[i].datetime.ToString();
                menuEntry.transform.Find("Score").GetComponent<TextMeshProUGUI>().text = highScoresList.highScores[i].score.ToString();
                menuEntry.transform.Find("BonusPoints").GetComponent<TextMeshProUGUI>().text = highScoresList.highScores[i].scoreFromBonuses.ToString();
                menuEntry.transform.Find("ElapsedTime").GetComponent<TextMeshProUGUI>().text = Math.Round(highScoresList.highScores[i].timeElapsed, 0).ToString();

            }
        }
        

    }
    private void Start()
    {
        if(highScoresList != null)
            highScoreText.text = defaultHighScoreText + highScoresList.highScores[0].score.ToString();
    }
    public void ResetUILabels()
    {
        scoreText.text = defaultScoreText;
        targetScoreText.text = defaultTargetText + settings.startingTargetScore;
        bonusScoreText.text = "";
    }

    public void UpdateScore(int newScore)
    {
        scoreText.text = defaultScoreText + newScore;
        gameOverPanelScoreText.text = "Final " + defaultScoreText + newScore;
    }
    public void UpdateBonusScore(int bonusScore)
    {
        bonusScoreText.text = bonusScore.ToString();
    }

    public void UpdateTarget(int targetScore)
    {
        targetScoreText.text = defaultTargetText + targetScore;
    }

    public void UpdateHighScore(int newScore)
    {
        int currentHighScore;

        if (highScoresList != null)
            currentHighScore = highScoresList.highScores[0].score;
        else
        {
            // hack! Forcing currentHighScore to be lower so the next check is true
            currentHighScore = newScore-1;
            highScoresList = new HighScoresList();
        }

        if (newScore > currentHighScore)
        {
            gameOverPanelScoreText.text = "New High " + defaultScoreText + newScore;
            highScoreText.text = defaultHighScoreText + newScore;
        }

        // add the new score and resort the list
        int bonusScore = Int32.Parse(bonusScoreText.text);
        highScoresList.highScores.Add(
            new HighScore(
                newScore,
                DateTime.Now.ToString(),
                Time.timeSinceLevelLoad,
                bonusScore
            )
        );
        
        highScoresList.highScores.Sort((x, y) => y.score - x.score);

        // save the list
        var json = JsonUtility.ToJson(highScoresList);
        PlayerPrefs.SetString("highScoresList", json);
        PlayerPrefs.Save();
    }
}

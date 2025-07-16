using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    public Text MyscoreText;
    public static int ScoreAmount;

    public Text DaysSurvivedText;
    public static int DaysSurvived;

    private int lastScore;
    private int lastDaysSurvived;

    public GameObject gameOver;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI mostDaysSurvivedText;



    void Start()

    {
        // Initialize UI text for score and days survived at game start
        MyscoreText.text = "Score : " + ScoreAmount;
        UpdateHighScoreText();

        DaysSurvivedText.text = "Days Survived : " + DaysSurvived;
        UpdateMostDaysSurvived();

    }

    public void Update()
    {
        // While game over screen is not active, update the displayed score and days survived if they have changed
        if (!gameOver.activeSelf)
        {
            if (ScoreAmount != lastScore)
            {
                MyscoreText.text = "Score : " + ScoreAmount;
                lastScore = ScoreAmount;
            }

            if (DaysSurvived != lastDaysSurvived)
            {
                DaysSurvivedText.text = "Days Survived : " + DaysSurvived;
                lastDaysSurvived = DaysSurvived;
            }
        }
        else
        {
            // When game over screen is active, check if the player set a new high score or most days survived record
            CheckHighScore();
            CheckMostDaysSurvived();
        }
    }
    void CheckHighScore()
    {
        // Get saved high score from PlayerPrefs, compare to current score and update if current is higher
        int HighScore = PlayerPrefs.GetInt("HighScore", 0);
        Debug.Log("Highscore: " + HighScore);
        if(ScoreAmount > HighScore)
        {
            PlayerPrefs.SetInt("HighScore", ScoreAmount);
            UpdateHighScoreText();


        }
    }

    void CheckMostDaysSurvived()
	{
        // Get saved record for days survived, compare and update if current value is higher
        int MostDays = PlayerPrefs.GetInt("DaysSurvived", 0);

        if(DaysSurvived > MostDays)
		{
            PlayerPrefs.SetInt("DaysSurvived", DaysSurvived);
            Debug.Log("DaysSurvived: " + MostDays);
            UpdateMostDaysSurvived();
        }
	}

    void UpdateHighScoreText()
    {
        // Update the high score UI text with the value saved in PlayerPrefs
        highScoreText.text = $"{PlayerPrefs.GetInt("HighScore", 0)}";
    }

    void UpdateMostDaysSurvived()
	{
        // Update the most days survived UI text with the value saved in PlayerPrefs
        mostDaysSurvivedText.text = $"{PlayerPrefs.GetInt("DaysSurvived", 0)}";
    }

}
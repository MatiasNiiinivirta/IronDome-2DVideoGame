using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text MyscoreText;
    public static int ScoreAmount;
    private CanvasGroup canvasGroup;


    void Start()
    
    {
        // Get the CanvasGroup component for controlling UI visibility and interactivity
        canvasGroup = GetComponent<CanvasGroup>();
        bool isVisible = PlayerPrefs.GetInt("ScoreVisible", 0) == 0;
        SetScoreVisible(isVisible);

        ScoreAmount = 0;
        MyscoreText.text = "Score: " + ScoreAmount;
        
    }

    public void Update()
    {
        // Called once per frame - updates the score display
        if (!DayNightCycle.isNight)
		{
            // During daytime, show normal score
            MyscoreText.text = "Score: " + ScoreAmount;
        }
        else
		{
            // During night, show double score notification
            MyscoreText.text = "2X Score: " + ScoreAmount;
        }
    
    }

    public void SetScoreVisible(bool isVisible)
    {
        // Set UI visibility by controlling CanvasGroup's alpha (opacity)
        canvasGroup.alpha = isVisible ? 1 : 0;
        // Enable or disable interaction with the UI elements
        canvasGroup.interactable = isVisible;
        // Enable or disable raycast blocking to prevent clicks when hidden
        canvasGroup.blocksRaycasts = isVisible; 
    }

}

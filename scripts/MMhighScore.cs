using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MMhighScore : MonoBehaviour
{
     
    public Text highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        // Retrieve the saved "HighScore" value from player preferences (default to 0 if not found)
        int HighScore = PlayerPrefs.GetInt("HighScore", 0);
        // Update the UI text element to display the retrieved high score
        highScoreText.text = $"{PlayerPrefs.GetInt("HighScore", 0)}";

    }

}
